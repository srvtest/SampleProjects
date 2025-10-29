using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using static Entity.Enums;
using Newtonsoft.Json;
using CCGrpcService;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using LoggerService;

namespace CCFileValidator.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FileValidatorController : ControllerBase
    {
        #region Variable Declation
        bool isValidate = true;
        public static int batchSize;
        public static string connString;
        public static string csvFileName;
        public static string logFileName;
        public static string nLogConfig;
        public static string grpcServiceURL;
        private readonly IHostingEnvironment _env;
        private string filePath;
        private string fileName;
        int numberOfBatches;
        public string fileId;
        public int rCode = Convert.ToInt32(ResponseCode.ApplicationSuccess);
        public string rMessage = Constant.successMsg;
        Response response;
        LoggerManager objLoggerManager;
        #endregion

        public FileValidatorController(IHostingEnvironment env)
        {
            _env = env;
        }
        [HttpGet]
        [Route("~/api/ReadCSVFile")]
        public async Task<Response> ReadCSVFile()
        {
            try
            {
                logFileName = _env.ContentRootPath + logFileName;
                #region Read Transation Record
                FileData objFileData = ReadFile();
                #endregion

                #region File Validate
                FileValidation(objFileData);
                #endregion

                if (isValidate && objFileData.lstTransaction != null && objFileData.lstTransaction.Count() > 0)
                {
                    filePath = _env.ContentRootPath + csvFileName;
                    fileName = Path.GetFileName(filePath);
                    Response res = InsertFileDetail(fileName, objFileData.lstTransaction.Count());
                    if (res != null)
                    {
                        if (res.Code == Convert.ToInt32(ResponseCode.ApplicationSuccess))
                        {
                            string fileId = (string)res.Data;
                            CreateChunks(objFileData.lstTransaction, fileId);
                        }
                        else
                        {
                            rCode = res.Code;
                            rMessage = res.Message;
                        }
                    }
                    else
                    {
                        rCode = Convert.ToInt32(ResponseCode.ApplicationError);
                        rMessage = Constant.errorInDBMsg;
                    }
                }
                else
                {
                    rCode = Convert.ToInt32(ResponseCode.ApplicationError);
                    rMessage = Constant.errorFileValidationMsg;
                }
            }
            catch (Exception ex)
            {
                rCode = Convert.ToInt32(ResponseCode.ApplicationError);
                rMessage = ex.Message;
            }
            finally
            {
                response = new Response();
                response.Code = rCode;
                response.Message = rMessage;
            }
            return response;
        }

        /// <summary>
        /// Method to insert the file Detail in the DB
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="TotalRecords"></param>
        /// <returns></returns>
        private Response InsertFileDetail(string FileName, int TotalRecords)
        {
            Response response = new Response();
            string fileId;
            //int effectedRows;
            try
            {
                string fileGUID = Convert.ToString(Guid.NewGuid());
                using (var con = new NpgsqlConnection(connString))
                {
                    con.Open();
                    var sql = "\"CardService\".InsertFileDetail";
                    using var cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("fileguid", fileGUID);
                    cmd.Parameters.AddWithValue("filename", FileName);
                    cmd.Parameters.AddWithValue("totalrecords", TotalRecords);
                    fileId = Convert.ToString(cmd.ExecuteScalar());
                    //effectedRows = cmd.ExecuteNonQuery();
                }
                if (!string.IsNullOrEmpty(fileId))
                {
                    rCode = Convert.ToInt32(ResponseCode.ApplicationSuccess);
                    rMessage = Constant.successMsg;
                    response.Data = Convert.ToString(fileId);
                }
                else
                {
                    rCode = Convert.ToInt32(ResponseCode.ApplicationError);
                    rMessage = Constant.errorInDBMsg;
                }
            }
            catch (NpgsqlException ex)
            {
                rCode = Convert.ToInt32(ResponseCode.ApplicationError);
                rMessage = ((Npgsql.PostgresException)ex).MessageText;
            }
            finally
            {
                response.Code = rCode;
                response.Message = rMessage;
            }
            return response;
        }

        /// <summary>
        /// Method to Read CSV File
        /// </summary>
        private FileData ReadFile()
        {
            FileData objFileData = new FileData();
            objFileData.lstTransaction = new List<CCTransactions>();
            filePath = _env.ContentRootPath + csvFileName;
            using (StreamReader rd = new StreamReader(filePath))
            {
                bool isheader = true;
                while (!rd.EndOfStream)
                {
                    String[] value = null;
                    value = rd.ReadLine().Split(',');
                    if (!isheader && !rd.EndOfStream)
                    {
                        CCTransactions cCTransections = new CCTransactions();
                        cCTransections.cardNumber = Convert.ToString(value[0]);
                        cCTransections.amount = Convert.ToDecimal(value[1]);
                        cCTransections.tranType = Convert.ToString(value[2]);
                        cCTransections.merchantDetail = Convert.ToString(value[3]);
                        cCTransections.uniqueId = Convert.ToString(value[4]);
                        cCTransections.dateOfTransection = Convert.ToDateTime(value[5]);
                        objFileData.lstTransaction.Add(cCTransections);
                    }
                    else
                    {
                        if (isheader)
                        {
                            objFileData.totalNumberofDrRecord = Convert.ToInt32(value[1]);
                            objFileData.totalNumberofCrRecord = Convert.ToInt32(value[2]);
                            isheader = false;
                        }
                        if (rd.EndOfStream)
                        {
                            objFileData.totalNumberofRecord = Convert.ToInt32(value[0]);
                        }
                    }
                }
            }
            return objFileData;
        }

        /// <summary>
        /// Method to Validation on File
        /// </summary>
        private void FileValidation(FileData objFileData)
        {
            if (objFileData != null && objFileData.lstTransaction != null && objFileData.lstTransaction.Count() > 0)
            {
                objLoggerManager = new LoggerManager();
                if (objFileData.totalNumberofDrRecord != objFileData.lstTransaction.Where(x => x.tranType.ToUpper() == Convert.ToString(TranType.DEBIT)).Count())
                {
                    objLoggerManager.LogWarn(Constant.errorValidationDrMsg);
                    isValidate = false;
                }
                if (objFileData.totalNumberofCrRecord != objFileData.lstTransaction.Where(x => x.tranType.ToUpper() == Convert.ToString(TranType.CREDIT)).Count())
                {
                    objLoggerManager.LogWarn(Constant.errorValidationCrMsg);
                    isValidate = false;
                }
                if (objFileData.totalNumberofRecord != objFileData.lstTransaction.Count)
                {
                    objLoggerManager.LogWarn(Constant.errorValidationTotalRecordMsg);
                    isValidate = false;
                }
            }
        }

        /// <summary>
        /// Method to create the groups on the basis of batch Size
        /// </summary>
        /// <param name="transactions"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        private async Task CreateChunks(List<CCTransactions> transactions, string fileId)
        {
            var tasks = new List<Task<IEnumerable<string>>>();
            try
            {
                numberOfBatches = Convert.ToInt32(Math.Ceiling(decimal.Divide(transactions.Count, batchSize)));
                //numberOfBatches = (int)Math.Ceiling((double)transactions.Count() / batchSize);
                for (int i = 0; i < numberOfBatches; i++)
                {

                    var currentRecords = transactions.Skip(i * batchSize).Take(batchSize).ToList();
                    string jData = JsonConvert.SerializeObject(currentRecords);
                    List<string> lstString = new List<string>();
                    lstString.Add(jData);
                    lstString.Add(fileId);
                    ThreadPool.QueueUserWorkItem(BackgroundTaskWithObject, lstString);
                }
            }
            catch (Exception ex)
            {
                objLoggerManager = new LoggerManager();
                objLoggerManager.LogError(Constant.errorInChunkCreation + "for the file" + fileId + "/n" + ex.Message);
            }
        }

        /// <summary>
        /// Thread Implementation
        /// </summary>
        /// <param name="stateInfo"></param>
        static async void BackgroundTaskWithObject(Object stateInfo)
        {
            try
            {
                List<string> jData = (List<string>)stateInfo;
                if (jData != null && jData.Count > 0)
                {
                    /*it is using to call service without SSL*/
                    AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                    var channel = GrpcChannel.ForAddress(FileValidatorController.grpcServiceURL);
                    var grpcclient = new grpcServicce.grpcServicceClient(channel);
                    var response = grpcclient.processDataAsync(new processDataRequest { JsonData = jData[0], FileId = jData[1] });
                    if (response != null && response.ResponseAsync.Result != null)
                    {
                        if (!string.IsNullOrEmpty(response.ResponseAsync.Result.Message))
                        {
                            LoggerManager objLoggerManager = new LoggerManager();
                            objLoggerManager.LogInfo(Convert.ToString("Response for the file " + jData[1] + " Response Message : " + response.ResponseAsync.Result.Message));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerManager objLoggerManager = new LoggerManager();
                objLoggerManager.LogError(Constant.errorInGRPCCalling + ex.Message);
            }
        }

        #region Unused Code
        private void ReadExcelUsingOledb()
        {
            try
            {
                filePath = _env.ContentRootPath + csvFileName;
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + filePath + ";Extended Properties=Excel 8.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "TestTable");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                //dataGridView1.DataSource = DtSet.Tables[0];
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

        }

        //private async Task<IEnumerable<string>> CreateChunks(List<CCTransactions> transactions, string fileId)
        //{
        //    var tasks = new List<Task<IEnumerable<string>>>();
        //    numberOfBatches = (int)Math.Ceiling((double)transactions.Count() / batchSize);
        //    for (int i = 0; i < numberOfBatches; i++)
        //    {
        //        var currentRecords = transactions.Skip(i * batchSize).Take(batchSize).ToList();
        //        string jData = JsonConvert.SerializeObject(currentRecords);
        //        AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        //        //var channel = GrpcChannel.ForAddress("http://localhost:5001");
        //        var channel = GrpcChannel.ForAddress(FileValidatorController.grpcServiceURL);
        //        var grpcclinet = new grpcServicce.grpcServicceClient(channel);
        //        var reply = await grpcclinet.processDataAsync(new processDataRequest { JsonData = jData, FileId = fileId });
        //    }
        // (await Task.WhenAll(tasks)).SelectMany(u => u);
        //    return tasks[0].Result;
        //}
        #endregion

    }
}
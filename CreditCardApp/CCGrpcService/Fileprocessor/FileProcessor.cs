using Entity;
using LoggerService;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Entity.Enums;

namespace CCGrpcService.Fileprocessor
{
    public class FileProcessor
    {
        public static string connString;
        public static string transactionserviceurl;
        private string jsonData;
        private string fileId;
        public int rCode = Convert.ToInt32(ResponseCode.ApplicationSuccess);
        public string rMessage;
        LoggerManager objLoggerManager;
        Response response;

        public async Task<Response> ProcessFileGroups(List<string> request)
        {            
            try
            {
                if (request != null && request.Count > 1)
                {
                    if (!string.IsNullOrEmpty(request[0]))
                        jsonData = request[0];
                    if (!string.IsNullOrEmpty(request[1]))
                        fileId = request[1];
                    IEnumerable<string> m_oEnum = new string[] { };
                    List<CCTransactions> lstCCTransactions = JsonConvert.DeserializeObject<List<CCTransactions>>(jsonData);
                    foreach (var item in lstCCTransactions)
                    {
                        try
                        {
                            InsertRecord(item, fileId);
                        }
                        catch (Exception exx)
                        {
                            objLoggerManager = new LoggerManager();
                            objLoggerManager.LogError(Constant.errorInDBMsg + "for the Record id " + item.uniqueId + " for the file" + fileId + "/n" + exx.Message);
                            rMessage += Constant.errorInDBMsg + "for the Record id " + item.uniqueId + " for the file" + fileId + "/n" + exx.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objLoggerManager = new LoggerManager();
                objLoggerManager.LogError(Constant.errorInGRPCToFileProcessorCalling + " for the file" + fileId + "/n" + ex.Message);
                rCode = Convert.ToInt32(ResponseCode.ApplicationError);
                rMessage += Constant.errorInGRPCToFileProcessorCalling + " for the file" + fileId + "/n" + ex.Message;
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
        private void InsertRecord(CCTransactions objCCTransactions, string fileId)
        {
            string cardNo;
            try
            {
                string transactionID = Convert.ToString(Guid.NewGuid());
                using (var con = new NpgsqlConnection(connString))
                {
                    con.Open();
                    var sql = "\"CardService\".InsertRecord";
                    using var cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("cardnumber", NpgsqlTypes.NpgsqlDbType.Varchar, objCCTransactions.cardNumber);
                    cmd.Parameters.AddWithValue("amount", NpgsqlTypes.NpgsqlDbType.Money, objCCTransactions.amount);
                    cmd.Parameters.AddWithValue("trantype", NpgsqlTypes.NpgsqlDbType.Varchar, objCCTransactions.tranType);
                    cmd.Parameters.AddWithValue("merchant", NpgsqlTypes.NpgsqlDbType.Varchar, objCCTransactions.merchantDetail);
                    cmd.Parameters.AddWithValue("uniqueid", NpgsqlTypes.NpgsqlDbType.Varchar, objCCTransactions.uniqueId);
                    cmd.Parameters.AddWithValue("dateoftransaction", NpgsqlTypes.NpgsqlDbType.Date, objCCTransactions.dateOfTransection);
                    cmd.Parameters.AddWithValue("fileid", NpgsqlTypes.NpgsqlDbType.Varchar, fileId);
                    cmd.Parameters.AddWithValue("transactionid", NpgsqlTypes.NpgsqlDbType.Varchar, transactionID);
                    cmd.Parameters.AddWithValue("status", NpgsqlTypes.NpgsqlDbType.Varchar, Convert.ToString(RecordStatus.InProgress));
                    cardNo = Convert.ToString(cmd.ExecuteScalar());
                }
                if (string.IsNullOrEmpty(cardNo))
                {
                    objLoggerManager = new LoggerManager();
                    objLoggerManager.LogError(Constant.errorInDBMsg + " for the Record id " + objCCTransactions.uniqueId + " for the file " + fileId);
                }
            }
            catch (NpgsqlException ex)
            {
                objLoggerManager = new LoggerManager();
                objLoggerManager.LogError(Constant.errorInDBMsg + " for the Record id " + objCCTransactions.uniqueId + " for the file " + fileId + ex.Message);
                throw;
            }
        }
    }
}

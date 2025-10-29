using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using static Entity.@enum;

namespace CCFileProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessorController : ControllerBase
    {
        public static string connString = string.Empty;
        public static string logfileName = string.Empty;

        /// <summary>
        /// Method to insert the file Detail in the DB
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="TotalRecords"></param>
        /// <returns></returns>
        //private Response InsertRecord(string cardnumber, string amount, string type, string merchant, string uniqueid, string dateoftransaction, string fileId)
        private Response InsertRecord(CCTransactions objCCTransactions, string fileId)
        {
            Response response = new Response();
            string cardNo;
            try
            {
                string transactionID = Convert.ToString(Guid.NewGuid());
                using (var con = new NpgsqlConnection(connString))
                {
                    con.Open();
                    var sql = "\"CardService\".InsertRecord'";
                    // ('" + objCCTransactions.cardNumber + "','" + objCCTransactions.amount + "','" + objCCTransactions.tranType + "','" + objCCTransactions.merchantDetail + "','" + objCCTransactions.uniqueId + "','" + objCCTransactions.dateOfTransection + "','" + fileId + "','" + transactionID + "','In Process')";
                    using var cmd = new NpgsqlCommand(sql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("cardnumber", objCCTransactions.cardNumber);
                    cmd.Parameters.AddWithValue("amount", objCCTransactions.amount);
                    cmd.Parameters.AddWithValue("trantype", objCCTransactions.tranType);
                    cmd.Parameters.AddWithValue("merchant", objCCTransactions.merchantDetail);
                    cmd.Parameters.AddWithValue("uniqueid", objCCTransactions.uniqueId);
                    cmd.Parameters.AddWithValue("dateoftransaction", objCCTransactions.dateOfTransection);
                    cmd.Parameters.AddWithValue("fileid", fileId);
                    cmd.Parameters.AddWithValue("transactionid", transactionID);
                    cmd.Parameters.AddWithValue("status", RecordStatus.InProgress);
                    cardNo = Convert.ToString(cmd.ExecuteScalar());
                }
                                
                if (!string.IsNullOrEmpty(cardNo))
                {
                    response.Code = Convert.ToInt32(ResponseCode.ApplicationSuccess); ;
                    response.Message = Constant.successMsg;
                    response.Data = Convert.ToString(cardNo);
                }
                else
                {
                    response.Code = Convert.ToInt32(ResponseCode.ApplicationError); ;
                    response.Message = Constant.errorInDBMsg;
                }
            }
            catch (NpgsqlException ex)
            {
                response.Code = Convert.ToInt32(ResponseCode.ApplicationError); ;
                response.Message = ((Npgsql.PostgresException)ex).MessageText;
            }
            return response;
        }

        [HttpPost]
        [Route("~/api/ProcessFileGroups")]
        public async Task<IEnumerable<string>> ProcessFileGroups(List<string> request)
        {
            List<string> lstString = new List<string>();
            try
            {
                if (request != null && request.Count > 1)
                {
                    string jsonData = request[0];
                    string fileId = request[1];
                    IEnumerable<string> m_oEnum = new string[] { };
                    List<CCTransactions> lstCCTransactions = JsonConvert.DeserializeObject<List<CCTransactions>>(jsonData);
                    Response response = new Response();
                    foreach (var item in lstCCTransactions)
                    {
                        try
                        {
                            response = InsertRecord(item, fileId);
                        }
                        catch (Exception exx)
                        {

                        }
                        lstString.Add(response.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.Code = Convert.ToInt32(ResponseCode.ApplicationError);
                response.Message = ex.Message;
            }            
            return lstString;
        }


    }
}
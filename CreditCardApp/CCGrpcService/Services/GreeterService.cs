using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CCGrpcService.Fileprocessor;
using Entity;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Npgsql;
using static Entity.Enums;

namespace CCGrpcService
{
    public class grpcService : grpcServicce.grpcServicceBase
    {
        private readonly ILogger<grpcService> _logger;
        public static string logfileName;
        FileProcessor objfileProcessor;
        public grpcService(ILogger<grpcService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method to process the Request coming from the file Validator service 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        //public override async Task<processDataReply> processData(processDataRequest request, ServerCallContext context)
        public override async Task<processDataReply> processData(processDataRequest request, ServerCallContext context)
        {
            try
            {
                if (request != null && !string.IsNullOrEmpty(request.JsonData))
                {
                    List<string> lstRequest = new List<string>();
                    lstRequest.Add(request.JsonData);
                    lstRequest.Add(request.FileId);
                    objfileProcessor = new FileProcessor();
                    Response objResponse= await objfileProcessor.ProcessFileGroups(lstRequest);
                    return (new processDataReply
                    {
                        Message = objResponse.Message 
                    });
                }
                else
                {
                    return (new processDataReply
                    {
                        Message = Constant.errorInFileProcessing
                    });
                }
            }
            catch (Exception ex)
            {
                return (new processDataReply
                {
                    Message = Constant.errorInFileProcessing + " Message : " + ex.Message
                });

            }
        }
    }
}

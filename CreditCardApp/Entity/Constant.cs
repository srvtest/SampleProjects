using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public static class Constant
    {
        public const string successMsg = "Success";
        public const string errorInDBMsg = "Error in DB operation.";
        public const string errorValidationDrMsg = "Number of debit record is not equal with csv file.";
        public const string errorValidationCrMsg = "Number of credit record is not equal with csv file.";
        public const string errorValidationTotalRecordMsg = "Total number of records not matching with csv file.";
        public const string errorFileProcessorServiceURLMsg = "File Processor Service URL is not define.";
        public const string errorFileValidationMsg = "File is not valid. Please check the log file for details.";
        public const string errorInChunkCreation = "Error occured during group creation.";
        public const string errorInGRPCCalling= "Error occured when calling the file processor.";
        public const string errorInGRPCToFileProcessorCalling = "Error in GRPC service to the file processor call.";
        public const string infoFileStartProcessingChunks = "File processor has completed the process of file groups.";
        public const string errorInFileProcessing = "Error occured during the processing in GRPC Server.";
        public const string infoResponseFromGRPC= "Response GRPC Server.";
    }
}

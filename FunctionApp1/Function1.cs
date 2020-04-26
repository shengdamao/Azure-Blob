using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.Storage;
using Azure.Storage.Blobs;


namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([BlobTrigger("dev/{name}", Connection = "datalake-1")]Stream myBlob, string name,
            [Blob("dev/inputblob-special.txt", FileAccess.Read, Connection = "inputBlob-1")] Stream inputBlob,
            ILogger log)
        {
           

            //string connectionString = "DefaultEndpointsProtocol=https;AccountName=shengdadatalake;AccountKey=YbrYMxlPNLub0ZU22OU6MMi78UceZL6mv4pnGysXvRlhElr/phpgacMkDbA5YFZzGaky7w4QUVHnFT9xgLMaFQ==;EndpointSuffix=core.windows.net";

            //// Create a client that can authenticate with a connection string
            //BlobServiceClient service = new BlobServiceClient(connectionString);

            //service.CreateBlobContainer("dev-test");

            StreamReader reader = new StreamReader(myBlob);


            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes " +
                $"\n content: {reader.ReadToEnd()}");

            StreamReader inpubReader = new StreamReader(inputBlob);


            log.LogInformation($"C# Blob trigger function Processed blob\n Name:output1.txt \n Size: {inputBlob.Length} Bytes " +
                $"\n content: {inpubReader.ReadToEnd()}");

        }
    }
}

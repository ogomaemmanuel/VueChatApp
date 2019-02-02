using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VueChatApp.Services.CloudStorage
{
    public class S3StorageService : ICloudStorageService
    {
        private readonly IAmazonS3 _client;
        public S3StorageService(IAmazonS3 client)
        {
            _client = client;
        }

        public async Task<ObjectResult> CreateBucketAsync(string bucketName)
        {
                if (await AmazonS3Util.DoesS3BucketExistAsync(_client, bucketName)==false) {
                    var putBucketRequest = new PutBucketRequest() {
                        BucketName = bucketName,
                        UseClientRegion = true
                    };
                    var respose = await _client.PutBucketAsync(putBucketRequest);
                return new OkObjectResult("Bucket created successfully");
                }
            return new BadRequestObjectResult("Bucket already created");
            }

        public async Task UploadFileAsync(string bucketName, string filePath)
        {
            try
            {
                var fileTransferUtility = new TransferUtility();
                await fileTransferUtility.UploadAsync(filePath, bucketName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UploadFileAsync(string bucketName, byte[] buffer,string uploadedFileName)
        {
            try
            {
                var fileTransferUtility = new TransferUtility();
                using (var filestream = new MemoryStream(buffer)) {
                  await  fileTransferUtility.UploadAsync(filestream, bucketName, uploadedFileName);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    }


using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VueChatApp.Services.CloudStorage
{
    public interface ICloudStorageService
    {
         Task<ObjectResult> CreateBucketAsync(string bucketName);
         Task UploadFileAsync(string bucketName,string filePath);
         Task UploadFileAsync(string bucketName,byte[] filestream, string uploadedFileName);
    }
}

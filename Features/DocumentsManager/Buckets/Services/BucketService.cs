using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueChatApp.Services.CloudStorage;

namespace VueChatApp.Features.Documents.Buckets.Services
{
    public class BucketService : IBucketService
    {
        private readonly ICloudStorageService _cloudStorageService;
        public BucketService(ICloudStorageService cloudStorageService) {
            _cloudStorageService = cloudStorageService;
        }
        public async Task<ObjectResult> CreateBucketAsync(string bucketName)
        {
            return await _cloudStorageService.CreateBucketAsync(bucketName);
        }
    }
}

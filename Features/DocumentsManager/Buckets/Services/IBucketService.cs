using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueChatApp.Features.Documents.Buckets.Services
{
    public interface IBucketService
    {
        Task<ObjectResult> CreateBucketAsync(string BucketName);
    }
}

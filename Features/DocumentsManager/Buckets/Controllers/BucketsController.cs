using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueChatApp.Features.Documents.Buckets.Services;

namespace VueChatApp.Features.Documents.Buckets.Controllers
{
    [Route("api/[controller]")]
    public class BucketsController : Controller
    {
        private readonly IBucketService _bucketService;
        public BucketsController(IBucketService bucketService)
        {
            _bucketService = bucketService;
        }
        [HttpPost("{bucket}")]
        public async Task<IActionResult> Post([FromRoute]string bucket) {
         var result=  await _bucketService.CreateBucketAsync(bucket);
            return result;
        }
    }
}
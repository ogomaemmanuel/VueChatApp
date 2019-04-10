using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueChatApp.Features.DocumentsManager.Documents.Services;

namespace VueChatApp.Features.DocumentsManager.Documents.Controllers
{
    [Route("api/[controller]")]
    public class DocumentsController : Controller
    {
        private readonly IDocumentService documentService;

        public DocumentsController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        [HttpGet("{name}", Name = "GetDocument")]
        public async Task<IActionResult> Get(string name)
        {
            var fileStream =  this.documentService.GetDocumentByName(name);
            return fileStream;
        }
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            await this.documentService.SaveDocument(file);
            return new OkObjectResult("File Successfully created");
        }
        
    }
}
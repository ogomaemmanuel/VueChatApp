using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VueChatApp.Features.DocumentsManager.Documents.Models;

namespace VueChatApp.Features.DocumentsManager.Documents.Services
{
    public interface IDocumentService
    {
         Task SaveDocument(IFormFile formFile);
         FileStreamResult GetDocumentByName(string name);
    }
}

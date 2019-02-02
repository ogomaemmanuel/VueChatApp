using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VueChatApp.Data;
using VueChatApp.Features.DocumentsManager.Documents.Models;

namespace VueChatApp.Features.DocumentsManager.Documents.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly ChatDbContext _chatDbContext;
        public DocumentService(ChatDbContext chatDbContext) {
            _chatDbContext = chatDbContext;
        }
        public FileStreamResult GetDocumentByName(string name)
        {
           var documement=  _chatDbContext.Documents.Where(x => x.Name == name).FirstOrDefault();
            if (documement!=null) {
               var path= $"Uploads/Videos/{documement.Name}{documement.Ext}";
                FileStream fs = File.OpenRead(path);
                    return new FileStreamResult(fs, new MediaTypeHeaderValue(documement.ContentType))
                    {
                        FileDownloadName = $"{ documement.Name }{ documement.Ext }"
                    };
                fs.Close();


            }
            throw new NotImplementedException();
        }

        public Task SaveDocument(IFormFile formFile)
        {

            throw new NotImplementedException();
        }
    }
}

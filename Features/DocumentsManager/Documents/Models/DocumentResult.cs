using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VueChatApp.Features.DocumentsManager.Documents.Models
{
    public class DocumentResult
    {
        public Stream FileAsStream { get; set; }
        public String ContentType { get; set; }
    }
}

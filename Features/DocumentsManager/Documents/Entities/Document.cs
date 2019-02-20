using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueChatApp.Features.DocumentsManager.Documents.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Ext { get; set; }
    }
}

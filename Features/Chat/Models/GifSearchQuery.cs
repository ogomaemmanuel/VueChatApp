using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueChatApp.Features.Chat.Models
{
    public class GifSearchQuery
    {
        public string Q { get; set; }
        public int Limit { get; set; }
        public int Pos { get; set; }

    }
}

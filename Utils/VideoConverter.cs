using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.NodeServices;


namespace VueChatApp.Utils
{
    public class VideoConverter
    {
        private readonly INodeServices _nodeServices;
        public VideoConverter(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }

        public async Task<string> Convert(String sourcePath,String outPath)
        {
            try
            {
                var result=  await _nodeServices.InvokeAsync<string>("Utils/VideoConverter.js",sourcePath,outPath,"mp4");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        
        }
    }
}
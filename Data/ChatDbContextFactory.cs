using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VueChatApp.Data
{
    //see https://go.microsoft.com/fwlink/?linkid=851728

    public class ChatDbContextFactory:IDesignTimeDbContextFactory<ChatDbContext>
    {
        public ChatDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChatDbContext>();
            optionsBuilder.UseSqlite("Data Source=ChatTutorial.db");

            return new ChatDbContext(optionsBuilder.Options);
        }
        
    }
}
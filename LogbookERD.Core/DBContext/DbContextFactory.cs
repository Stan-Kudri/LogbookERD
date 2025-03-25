using Microsoft.EntityFrameworkCore;

namespace LogbookERD.Core.DBContext
{
    public class DbContextFactory
    {
        public AppDBContext Create()
        {
            var builder = new DbContextOptionsBuilder().UseSqlite($"Data Source=app.db");
            var dbContext = new AppDBContext(builder.Options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}

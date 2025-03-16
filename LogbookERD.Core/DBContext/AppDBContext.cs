using Microsoft.EntityFrameworkCore;

namespace LogbookERD.Core.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}

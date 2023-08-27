using Microsoft.EntityFrameworkCore;

namespace SourabhAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options){ }
        public DbSet<Sourabh>Sourabhs { get; set; } 
    }
}

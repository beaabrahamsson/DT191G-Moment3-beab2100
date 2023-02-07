using CDDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace CDDirectory.Data 
{
    public class CDContext : DbContext 
    {
        public CDContext(DbContextOptions<CDContext> options) : base(options) {

        }
        public DbSet<CD> CD { get; set; }
    }
}
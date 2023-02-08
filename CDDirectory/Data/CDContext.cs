using CDDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace CDDirectory.Data 
{
    public class CDContext : DbContext 
    {
        public CDContext(DbContextOptions<CDContext> options) : base(options) {

        }
        public DbSet<CD> CD => Set<CD>();
        public DbSet<Artist> Artist => Set<Artist>();
    }
}
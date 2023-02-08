using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CDDirectory.Models;

namespace CDDirectory.Data 
{
    public class ArtistContext : DbContext 
    {
        public ArtistContext(DbContextOptions<ArtistContext> options) : base(options) {

        }
        public DbSet<CD> CD => Set<CD>();
        public DbSet<Artist> Artist => Set<Artist>();
        
    }
}

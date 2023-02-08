using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CDDirectory.Models;

namespace CDDirectory.Data 
{
    public class UserContext : DbContext 
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) {

        }
        public DbSet<User> User => Set<User>();
    }
}
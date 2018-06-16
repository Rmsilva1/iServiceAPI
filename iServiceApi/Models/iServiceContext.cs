using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iServiceApi.Models
{
    public class IServiceContext : DbContext
    {
        public IServiceContext(DbContextOptions<IServiceContext> options): base(options)
        {
        }                
        public DbSet<Usuario> TodoItems { get; set; }
    }
}


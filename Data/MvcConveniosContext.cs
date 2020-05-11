using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ConveniosContext : DbContext
    {
        public ConveniosContext(DbContextOptions<ConveniosContext> options)
    : base(options)
        {
        }
        public DbSet<convenios> Convenios { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DespesasContext : DbContext
    {
        public DespesasContext(DbContextOptions<DespesasContext> options)
    : base(options)
        {
        }
        public DbSet<despesas> Despesas{ get; set; }
    }
}

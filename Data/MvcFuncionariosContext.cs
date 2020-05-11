using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class FuncionariosContext : DbContext
    {
        public FuncionariosContext(DbContextOptions<FuncionariosContext> options)
    : base(options)
        {
        }
        public DbSet<funcionarios> Funcionarios { get; set; }
    }
}

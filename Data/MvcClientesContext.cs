using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ClientesContext : DbContext
    {
        public ClientesContext(DbContextOptions<ClientesContext> options)
    : base(options)
        {
        }
        public DbSet<clientes> Clientes { get; set; }

    }
}

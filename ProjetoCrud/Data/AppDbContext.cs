using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Models;

namespace ProjetoCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}

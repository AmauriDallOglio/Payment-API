using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Context
{
    public class MeuContext : DbContext
    {
        public MeuContext(DbContextOptions<MeuContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
    }
}

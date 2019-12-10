using Microsoft.EntityFrameworkCore;
using MinhasContas.DAL.Interface.Entities;

namespace MinhasContas.DAL.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder configuration)
        {
            configuration.UseSqlServer("Password=123qwe;Persist Security Info=True;User ID=cih;Initial Catalog=MnhasContas;Data Source=BNU-0772");
        }

    }
}

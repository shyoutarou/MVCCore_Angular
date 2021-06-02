using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCFornecedores.Data.Entities;
using System;

namespace MVCFornecedores.Data
{
    public class FornecedorContext : DbContext
    {
        private readonly IConfiguration _config;

        public FornecedorContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        {
            base.OnConfiguring(bldr);

            bldr.UseSqlServer(_config.GetConnectionString("FornecedorConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Contato>()
            //  .Property(p => p.Price)
            //  .HasColumnType("money");

            //modelBuilder.Entity<Fornecedor>()
            //  .Property(o => o.UnitPrice)
            //  .HasColumnType("money");

            //modelBuilder.Entity<Empresa>()
            //  .HasData(new Empresa()
            //  {
            //      Id_Empresa = 1,
            //      UF = "SP",
            //      NomeFantasia = "Bludata",
            //      CNPJ = "77854081000111"
            //  });
        }
    }
}

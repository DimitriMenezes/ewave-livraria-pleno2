using EwaveLivraria.Domain.EntitiesConfig;
using EwaveLivraria.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwaveLivraria.Domain.Context
{
    public partial class ApplicationContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookInventory> BookInventory { get; set; }
        public DbSet<BookLoan> BookLoan { get; set; }
        public DbSet<Institution> Institution { get; set; }
        public DbSet<LoanStatus> LoanStatus { get; set; }
        public DbSet<User> User { get; set; }

        public ApplicationContext()
        {
        }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new AdministratorConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new BookInventoryConfig());
            modelBuilder.ApplyConfiguration(new BookLoanConfig());
            modelBuilder.ApplyConfiguration(new InstitutionConfig());
            modelBuilder.ApplyConfiguration(new LoanStatusConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}

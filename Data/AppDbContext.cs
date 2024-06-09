using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration; 
using Model;
using System.Reflection;

namespace Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    // ConnectionContext(DbContextOptions<ConnectionContext> options) : DbContext(options)
    {
        public DbSet<Comprador> Compradores { get; set; }        
        public DbSet<Item> Itens { get; set; }
        public DbSet<Lance> Lances { get; set; }

        // public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) {}

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured) {}
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comprador>().ToTable("comprador");
            modelBuilder.Entity<Item>().ToTable("item");
            modelBuilder.Entity<Lance>().ToTable("lance");    

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

/*using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration; 
using Model;

namespace Data
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Comprador> Compradores { get; set; }        
        public DbSet<Item> Itens { get; set; }
        public DbSet<Lance> Lances { get; set; }
        private string ConnectionString { get; set; }
        private readonly IConfiguration _configuration;

        public ConnectionContext(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = configuration.GetConnectionString("Default");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString, new MySqlServerVersion(new Version(8, 0, 21))); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comprador>().ToTable("comprador");
            modelBuilder.Entity<Item>().ToTable("item");
            modelBuilder.Entity<Lance>().ToTable("lance");            
        }
    }
}*/
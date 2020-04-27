using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ComercioAPI.DAL
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext() : base("name=EcommerceDBConnectionString")
        {
            //Database.SetInitializer<EcommerceDbContext>(new CreateDatabaseIfNotExists<EcommerceDbContext>());
            //Database.SetInitializer<EcommerceDbContext>(new DropCreateDatabaseIfModelChanges<EcommerceDbContext>());
            //Database.SetInitializer<EcommerceDbContext>(new DropCreateDatabaseAlways<EcommerceDbContext>());
            //En produccion: Database.SetInitializer<EcommerceDbContext>(null);
            //Customizado:
            Database.SetInitializer<EcommerceDbContext>(new EcommerceDbContextInitializer());

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Elimina la pluralización de las entidades por convención
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }
    }

}
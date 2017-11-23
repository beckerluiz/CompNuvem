using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pizzaria_v1._0.Models
{
    public class Entities : DbContext
    {

        public Entities()
        {
            //Database.SetInitializer<Entities>(new DropCreateDatabaseAlways<Entities>());
            Database.SetInitializer<Entities>(new DropCreateDatabaseIfModelChanges<Entities>());
            //Database.SetInitializer<Entities>(new CreateDatabaseIfNotExists<Entities>());
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
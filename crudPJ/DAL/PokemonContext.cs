using crudPJ.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace crudPJ.DAL
{
    public class PokemonContext : DbContext
    {
        public PokemonContext() : base("PokemonContext")
        {
        }

        public DbSet<Pokemon> Pokemon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
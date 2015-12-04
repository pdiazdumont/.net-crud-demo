using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using crudPJ.Models;

namespace crudPJ.DAL
{
    public class PokemonInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PokemonContext>
    {
        protected override void Seed(PokemonContext context)
        {
            var pokemons = new List<Pokemon>
            {
            new Pokemon{Name="Pikachu",Nickname="Pepe"},
            new Pokemon{Name="Charmander",Nickname="Coco"}
            };
            context.SaveChanges();
        }
    }
}
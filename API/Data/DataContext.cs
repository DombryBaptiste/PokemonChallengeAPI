using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Challenge> Challenges => Set<Challenge>();
        public DbSet<Pokemon> Pokemon => Set<Pokemon>();
        public DbSet<PokemonsOwnedUsers> PokemonsOwnedUsers => Set<PokemonsOwnedUsers>();
    }  
}
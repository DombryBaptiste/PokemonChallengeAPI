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
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     var connectionString = "server=localhost;user=root;password=;database=pokemon";
        //     var serverVersion = new MySqlServerVersion(new Version(8,0,31));
        //     optionsBuilder.UseMySql(connectionString, serverVersion);
        // }
    }  
}
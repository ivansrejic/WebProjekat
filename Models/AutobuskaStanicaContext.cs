using Microsoft.EntityFrameworkCore;

namespace Models
{ 
    public class AutobuskaStanicaContext : DbContext
    { 
        public AutobuskaStanicaContext(DbContextOptions options) : base(options)
        { 
            
        }
        public DbSet<Autobus> Autobusi { get; set;}
       
        public DbSet<Karta> Karte { get; set;}

        public DbSet<Putnik> Putnici { get; set;}
    
    }
}
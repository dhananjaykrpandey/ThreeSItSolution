using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ThreeSItSolution.Models;
namespace ThreeSItSolution.Models
{
    public class Db3SItSoultion:DbContext
    { 
        public DbSet<MContactUs> MContactUs { get; set; }
        public Db3SItSoultion(DbContextOptions<Db3SItSoultion> options)
         : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ArnikaInfotechDBConnection")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<ThreeSItSolution.Models.MEnquiry> MEnquiry { get; set; }
       
    }
}

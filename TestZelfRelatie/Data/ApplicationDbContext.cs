using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TestZelfRelatie.Models;

namespace TestZelfRelatie.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        


        public DbSet<RoutePoint> RoutePoints { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RoutePoint a = new() { Id = 1, Name = "a", OutgoingRelation = new()};
            RoutePoint b = new() { Id=2, Name = "b", OutgoingRelation = new()};
            RoutePoint c = new() { Id=3, Name = "c", OutgoingRelation = new()};
            RoutePoint d = new() { Id=4, Name = "d", OutgoingRelation = new()};
            /*
            a.OutgoingRelation.Add(b);
            a.OutgoingRelation.Add(c);
            b.OutgoingRelation.Add(d);
            b.OutgoingRelation.Add(a);
            c.OutgoingRelation.Add(d);
            c.OutgoingRelation.Add(a);
            d.OutgoingRelation.Add(c);
            d.OutgoingRelation.Add(b);
            */
            modelBuilder.Entity<RoutePoint>().HasData(a);
            modelBuilder.Entity<RoutePoint>().HasData(b);
            modelBuilder.Entity<RoutePoint>().HasData(c);
            modelBuilder.Entity<RoutePoint>().HasData(d);
        }

    }
}
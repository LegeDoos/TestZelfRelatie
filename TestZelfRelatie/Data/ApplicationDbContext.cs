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
        public DbSet<RoutePointV2> RoutePointsV2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // RoutePointV2 relations
            // de "van" kant in de relatie wijst naar een routepoint en word dus gelinkt aan de outgoing relatie vanuit het routepunt gezien
            modelBuilder.Entity<RoutePointRelationV2>().HasOne(rp => rp.RoutePointV2From).WithMany(r => r.OutgoingRelations).OnDelete(DeleteBehavior.NoAction);
            // de "to" kant in de relatie wijst naar een routepoint en word dus gelinkt aan de incloming relatie vanuit het routepunt gezien
            modelBuilder.Entity<RoutePointRelationV2>().HasOne(rp => rp.RoutePointV2To).WithMany(r => r.IncomingRelations).OnDelete(DeleteBehavior.NoAction);

            // data seed route v2
            RoutePointV2 rpA = new RoutePointV2() { Id = 1, Name = "Routepoint a" };
            RoutePointV2 rpB = new RoutePointV2() { Id = 2, Name = "Routepoint b" };
            RoutePointV2 rpC = new RoutePointV2() { Id = 3, Name = "Routepoint c" };
            modelBuilder.Entity<RoutePointV2>().HasData(rpA);
            modelBuilder.Entity<RoutePointV2>().HasData(rpB);
            modelBuilder.Entity<RoutePointV2>().HasData(rpC);
            RoutePointRelationV2 rpr1 = new RoutePointRelationV2() { RoutePointRelationV2Id = 1, Description = "Van a naar b", Distance = 10, RoutePointV2FromId = rpA.Id, RoutePointV2ToId = rpB.Id };
            RoutePointRelationV2 rpr2 = new RoutePointRelationV2() { RoutePointRelationV2Id = 2, Description = "Van b naar a", Distance = 10, RoutePointV2FromId = rpB.Id, RoutePointV2ToId = rpA.Id };
            RoutePointRelationV2 rpr3 = new RoutePointRelationV2() { RoutePointRelationV2Id = 3, Description = "Van a naar c", Distance = 20, RoutePointV2FromId = rpA.Id, RoutePointV2ToId = rpC.Id };
            RoutePointRelationV2 rpr4 = new RoutePointRelationV2() { RoutePointRelationV2Id = 4, Description = "Van c naar a", Distance = 20, RoutePointV2FromId = rpC.Id, RoutePointV2ToId = rpA.Id };
            modelBuilder.Entity<RoutePointRelationV2>().HasData(rpr1);
            modelBuilder.Entity<RoutePointRelationV2>().HasData(rpr2);
            modelBuilder.Entity<RoutePointRelationV2>().HasData(rpr3);
            modelBuilder.Entity<RoutePointRelationV2>().HasData(rpr4);

            // data seed route v1
            RoutePoint a = new() { Id = 1, Name = "a", OutgoingRelation = new()};
            RoutePoint b = new() { Id=2, Name = "b", OutgoingRelation = new()};
            RoutePoint c = new() { Id=3, Name = "c", OutgoingRelation = new()};
            RoutePoint d = new() { Id=4, Name = "d", OutgoingRelation = new()};
            modelBuilder.Entity<RoutePoint>().HasData(a);
            modelBuilder.Entity<RoutePoint>().HasData(b);
            modelBuilder.Entity<RoutePoint>().HasData(c);
            modelBuilder.Entity<RoutePoint>().HasData(d);
        }

    }
}
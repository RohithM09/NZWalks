using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
                
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("6ed3c98e-c86c-4649-a1dc-7497dff26bb7"),
                    Name ="Easy"
                },
                 new Difficulty()
                {
                    Id = Guid.Parse("b47d095c-f4ce-45a9-a047-2a19678d396c"),
                    Name ="Medium"
                },
                  new Difficulty()
                {
                    Id = Guid.Parse("761cbaa8-587d-41f2-a940-8b02b2dbdc33"),
                    Name ="Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("0cd62230-317a-4200-bc4f-d5a02c5286c6"),
                    Name="Auckland",
                    Code="AKL",
                    RegionImageUrl="https://images.pexels.com/photos/36412493/pexels-photo-36412493.jpeg"
                },
                 new Region()
                {
                    Id = Guid.Parse("0a816c33-188b-4a5c-8c0a-b9efe13d20f6"),
                    Name="Northland",
                    Code="NTL",
                    RegionImageUrl=null
                },
                  new Region()
                {
                    Id = Guid.Parse("4f5f23e8-4e76-4d61-9e41-12e50e1a75ac"),
                    Name="Bay of plenty",
                    Code="BOP",
                    RegionImageUrl=null
                },
                   new Region()
                {
                    Id = Guid.Parse("77c450f5-bbe8-44a3-93f8-6643146e55ed"),
                    Name="Wellington",
                    Code="WGN",
                    RegionImageUrl=null
                },
                   new Region()
                {
                    Id = Guid.Parse("969ad4b5-ed4c-496d-bbb5-587999f6eaf3"),
                    Name="Nelson",
                    Code="NSN",
                    RegionImageUrl=null
                },
                   new Region()
                {
                    Id = Guid.Parse("d1852724-7413-48eb-b3b3-851314229a34"),
                    Name="Southland",
                    Code="STL",
                    RegionImageUrl=null
                }



            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}

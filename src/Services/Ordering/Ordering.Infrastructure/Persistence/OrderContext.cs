using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ordering.Domain.Common;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        // private readonly IConfiguration _configuration;
        //
        // public OrderContext(IConfiguration configuration)
        // {
        //     _configuration = configuration;
        // }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options){}

        public DbSet<Order> Orders { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // optionsBuilder
        //     //     .UseSqlServer(_configuration.GetConnectionString("OrderingConnectionString"), options => options.EnableRetryOnFailure());
        //     optionsBuilder
        //         .UseSqlServer("Server=localhost;Database=OrderDb;User Id=sa;Password=1StrongPwdclear;", options => options.EnableRetryOnFailure());
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,4)");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Burda entity frameworkun in memory yaddasinda olan obyektlere baxilir
            // sonra olarin statelerine uygun umumi propertilerine default deyerler 
            //elave edilib daha sonra base deku SaveChangesAsync funksiyasi trigger edilir
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "Parviz";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Parviz";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
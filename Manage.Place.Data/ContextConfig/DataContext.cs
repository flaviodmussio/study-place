using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Manage.Place.Data.EntityConfig;
using Manage.Place.Domain.Interfaces.Repositories;
using Manage.Place.Domain.Entities;

namespace Manage.Place.Data.ContextConfig
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DataContext()
        {
        }

        public DbSet<Places> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());


            //base.OnModelCreating(modelBuilder);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();

            var now = DateTime.Now;
            foreach (var entry in entries
                .Where(entry =>
                    entry.Entity.GetType().GetProperty("DateCreated") != null
                    && entry.Entity.GetType().GetProperty("DateUpdated") != null
                ))
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Property("DateUpdated").CurrentValue = now;
                        break;

                    case EntityState.Added:
                        entry.Property("DateCreated").CurrentValue = now;
                        break;
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();

            return (await base.SaveChangesAsync(true, cancellationToken));
        }
    }
}

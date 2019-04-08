using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pegabicho.domain.Entities.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace pegabicho.infra.ORM
{

    #region Identity

    //    public class AppDbContext : IdentityDbContext<ApplicationUser>
    //    {
    //        public AppDbContext(DbContextOptions options) : base(options)
    //        {
    //            
    //        }
    //    }

    #endregion

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder options)
        {
            #region [ general scheme ]

            options.HasDefaultSchema("Core");

            // # config conventions by metadata model loop
            foreach (var entityType in options.Model.GetEntityTypes())
            {
                // # config equivalent
                // # convention Remove Pluralizing Table Names Covention
                entityType.Relational().TableName = entityType.DisplayName();

                // # config equivalent
                // # convention Remove OneToMany Cascade Delete Convention
                // # convention Remove ManyToMany Cascade Delete Convention
                entityType.GetForeignKeys()
                    .Where(x => !x.IsOwnership && x.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(x => x.DeleteBehavior = DeleteBehavior.Restrict);
            }

            #endregion

            #region [ mappings ]

            // # user


            // # log
            //options.Entity<EntityLog>(new EntityLogMap().Configure);

            #endregion

            base.OnModelCreating(options);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // # enable lazy loading be careful
            //options.UseLazyLoadingProxies();

            options.EnableSensitiveDataLogging();

            base.OnConfiguring(options);
        }

        /// <summary>
        /// Apply some things on entities during the async commit
        /// </summary>
        /// <returns>Override SaveChanges</returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry =>
            entry.Entity.GetType().GetProperty(nameof(EntityBase.CreatedAt)) != null ||
            entry.Entity.GetType().GetProperty(nameof(EntityBase.UpdatedAt)) != null ||
            entry.Entity.GetType().GetProperty(nameof(EntityBase.Id)) != null))
            {
                if (entry.Property(nameof(EntityBase.CreatedAt)) != null)
                    if (entry.State == EntityState.Added)
                        entry.Property(nameof(EntityBase.CreatedAt)).CurrentValue = DateTimeOffset.UtcNow;
                    else if (entry.State == EntityState.Modified)
                        entry.Property(nameof(EntityBase.CreatedAt)).IsModified = false;

                if (entry.Property(nameof(EntityBase.UpdatedAt)) != null)
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        entry.Property(nameof(EntityBase.UpdatedAt)).CurrentValue = DateTimeOffset.UtcNow;

                if (entry.Property(nameof(EntityBase.Id)) != null)
                    if (entry.State == EntityState.Added)
                        if (string.IsNullOrEmpty((string)entry.Property(nameof(EntityBase.Id)).CurrentValue))
                            entry.Property(nameof(EntityBase.Id)).CurrentValue = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}

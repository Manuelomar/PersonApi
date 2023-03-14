using Person.Domain.Entities;
using Person.Domain.Entities.Persons;
using Person.Infrastructure.Context.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Person.Infrastructure.Context
{
    public interface IAgendaDbContext : IDisposable
    {
        public DbSet<T> GetDbSet<T>() where T : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class AgendaDbContext : DbContext, IAgendaDbContext
    {
        public DbSet<Domain.Entities.Persons.Person> Persons { get; set; }

        public AgendaDbContext(DbContextOptions<AgendaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(type.ClrType))
                {
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
                }
            }
        }
        
        public DbSet<T> GetDbSet<T>() where T : BaseEntity => Set<T>();

        public void SetAuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if(entry.State != EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.Deleted = true;
                }
            }
        }
        
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

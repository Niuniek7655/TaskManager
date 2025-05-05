using Accessory.Builder.Outbox.Common;
using Accessory.Builder.Persistence.Core.Common.Logs;
using Microsoft.EntityFrameworkCore;
using Template.Core.Domain.User;
using Template.Infrastructure.Persistence.Configurations;

namespace Template.Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
    protected internal DbSet<AuditTrail>? Audits { get; set; }
        
    protected internal DbSet<User>? Users { get; set; }

    protected internal DbSet<OutboxMessage>? OutboxMessages { get; set; }
        
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }
        
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AuditConfiguration).Assembly);
    }

        
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Domain.User;

namespace TaskManager.Infrastructure.Persistence.Configurations.UserEntitiesConfiguration;

public static class TaskConfiguration
{
    public static void Configuration(OwnedNavigationBuilder<User, Core.Domain.Task.Task> task)
    {
        var clusteredId = "TaskClusteredId";
        task.ToTable("Tasks");
        task.HasKey(s => s.Id).IsClustered(false);
        task.Property(s => s.Id).HasColumnName("Id").ValueGeneratedNever();
        task.Property<long>(clusteredId).UseIdentityColumn();
        task.HasIndex(clusteredId)
            .IsClustered();

        task.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(36);

        task.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(1800);

        task.Property(a => a.Status)
            .IsRequired();

        task.Property(a => a.CreationDate)
            .IsRequired();

        task.Property(a => a.LastUpdateDate)
            .IsRequired();

        var ownerClusteredId = "UserClusteredId";
        task.WithOwner().HasPrincipalKey(ownerClusteredId);
        task.WithOwner().HasForeignKey(ownerClusteredId);
    }
}

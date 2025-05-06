using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Domain.User;
using TaskManager.Infrastructure.Persistence.Configurations.UserEntitiesConfiguration;

namespace TaskManager.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var clusteredId = "UserClusteredId";
        builder.ToTable("Users");
        builder.HasKey(s => s.Id).IsClustered(false);
        builder.Property(s => s.Id).HasColumnName("Id").ValueGeneratedNever();
        builder.Property<long>(clusteredId).UseIdentityColumn();
        builder.HasIndex(clusteredId)
            .IsClustered();

        builder.Property(a => a.FullDomainName)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(a => a.UserType)
            .IsRequired();

        builder.Property(a => a.UserStatus)
            .IsRequired();

        builder.Property(a => a.CreationDate)
            .IsRequired();

        builder.Property(a => a.LastUpdateDate)
            .IsRequired();

        builder.OwnsMany(a => a.Tasks, TaskConfiguration.Configuration);
    }
}
using Domain.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
    {
        builder.ToTable("tasks");
        builder.Property(t => t.Description).HasMaxLength(TaskConstants.MaxDescriptionLength);
        builder.Property(t => t.Title).HasMaxLength(TaskConstants.MaxTitleLength);
    }
}
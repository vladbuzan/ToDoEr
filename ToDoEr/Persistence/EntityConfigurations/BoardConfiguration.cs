using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.ToTable("boards");
        builder.Property(b => b.Name).HasMaxLength(BoardConstants.MaxNameLength);
        builder.Property(b => b.Description).HasMaxLength(BoardConstants.MaxDescriptionLength);
    }
}
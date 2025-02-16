using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.NameTranslation;
using Task = Domain.Entities.Task;

namespace Persistence.Context;

public class ToDoErContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; } = null!;
    public DbSet<Board> Boards { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        var mapper = new NpgsqlSnakeCaseNameTranslator();

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                var storeObjectIdentifier = StoreObjectIdentifier.Create(property.DeclaringType, StoreObjectType.Table);

                if (!storeObjectIdentifier.HasValue)
                    continue;

                var clrName = property.GetColumnName(storeObjectIdentifier.Value);

                if (clrName is null)
                    continue;

                property.SetColumnName(mapper.TranslateMemberName(clrName));
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}
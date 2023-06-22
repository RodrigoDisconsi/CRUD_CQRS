using CRUDCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDCleanArchitecture.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Persona> Personas { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

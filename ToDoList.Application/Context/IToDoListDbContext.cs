using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Context;

public interface IToDoListDbContext
{
    DbSet<ToDoTask> ToDoTasks { get; set; }

    DatabaseFacade Database { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    EntityEntry Remove(object entity);
}

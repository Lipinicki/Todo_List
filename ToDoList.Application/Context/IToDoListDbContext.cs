using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Context;

public interface IToDoListDbContext
{
    DbSet<ToDoTask> TodoTasks { get; set; }

    DatabaseFacade Database { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

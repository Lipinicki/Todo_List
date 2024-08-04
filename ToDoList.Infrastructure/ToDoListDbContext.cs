using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoList.Application.Context;
using ToDoList.Domain.Entities;

namespace Project.EFCore.Infrastructure;

public class ToDoListDbContext : DbContext, IToDoListDbContext
{
    public DbSet<ToDoTask> TodoTasks { get; set; }
    
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

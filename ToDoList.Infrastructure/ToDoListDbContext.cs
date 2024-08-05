using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoList.Application.Context;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure;

public class ToDoListDbContext : DbContext, IToDoListDbContext
{
    public DbSet<ToDoTask> ToDoTasks { get; set; }
    
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Apply entity configuration to migrations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Context;
using ToDoList.Application.Models;
using ToDoList.Domain.Entities;
using ToDoList.Models;

namespace ToDoList.Application.Services;

public class ToDoTaskService : IToDoTaskService
{
    private readonly IToDoListDbContext _dbContext; 

    public ToDoTaskService(IToDoListDbContext ctx)
    {
        _dbContext = ctx;   
    }

    public async Task<int> InsertAsync(InsertUpdateToDoTask insertToDoTask)
    {
        var toDoTask = new ToDoTask
        {
            Title = insertToDoTask.Title,
            Description = insertToDoTask.Description,
            Completed = insertToDoTask.Completed
        };

        await _dbContext.ToDoTasks.AddAsync(toDoTask);
        await _dbContext.SaveChangesAsync();

        return toDoTask.Id;
    }

    public async Task UpdateAsync(int id, InsertUpdateToDoTask updateToDoTask)
    {
        var toDoTask = await _dbContext.ToDoTasks.SingleAsync(t => t.Id == id);

        toDoTask.Title = updateToDoTask.Title;
        toDoTask.Description = updateToDoTask.Description;
        toDoTask.Completed = updateToDoTask.Completed;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var toDoTask = await _dbContext.ToDoTasks.SingleAsync(t => t.Id == id);

        _dbContext.Remove(toDoTask);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<GetToDoTask>> GetAllAsync()
    {
        return await _dbContext.ToDoTasks
            .Select(t => new GetToDoTask
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Completed = t.Completed,
            })
            .ToListAsync();
    }
}

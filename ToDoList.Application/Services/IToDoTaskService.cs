using ToDoList.Application.Models;
using ToDoList.Models;

namespace ToDoList.Application.Services;

public interface IToDoTaskService
{
    Task<int> InsertAsync(InsertUpdateToDoTask insertToDoTask);

    ///<exception cref="InvalidOperationException">There's is no record with the given id.</exception>
    Task UpdateAsync(int id, InsertUpdateToDoTask updateToDoTask);

    ///<exception cref="InvalidOperationException">There's is no record with the given id.</exception>
    Task DeleteAsync(int id);

    Task<List<GetToDoTask>> GetAllAsync();
}

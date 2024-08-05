using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Services;
using ToDoList.Models;

namespace ToDoList.Controllers;

[Route("api/tasks")]
[ApiController]
public class ToDoTaskController : ControllerBase
{
    private readonly IToDoTaskService _toDoTaskService;

    public ToDoTaskController(IToDoTaskService toDoTaskService)
    {
        _toDoTaskService = toDoTaskService;
    }

    /// <summary>
    /// Inserts a new task into the Todo List.
    /// </summary>
    /// <param name="insertTask">The insert data for the new task.</param>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST: /tasks
    ///     {
    ///         "title": "Finish Project Documentation",
    ///         "description": "Complete the documentation for the new feature implementation by Friday.",
    ///         "completed": false
    ///     }
    ///     
    /// The "title", "description", and "completed" fields are all required. If any of these fields are missing or invalid, 
    /// the request will be rejected with a 400 status code.
    /// </remarks>
    /// <response code="201">A new task have been created.</response>
    /// <response code="400">The request body is not in a valid format.</response>
    /// <response code="500">An error occurred on the server while processing the request.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InsertAsync(InsertUpdateToDoTask insertTask)
    {
        int id = await _toDoTaskService.InsertAsync(insertTask);

        return Created("", id);
    }

    /// <summary>
    /// Update a task that is already in the Todo List.
    /// </summary>
    /// <param name="id">The task id.</param>
    /// <param name="updateTask">The update data for the existing task.</param>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT: /tasks/23
    ///     {
    ///         "title": "Prepare Presentation",
    ///         "description": "Create slides for the upcoming client meeting presentation.",
    ///         "completed": true
    ///     }
    ///     
    /// The "title", "description", and "completed" fields are all required. If any of these fields are missing or invalid, 
    /// the request will be rejected with a 400 status code. 
    /// </remarks>
    /// <response code="204">The task has been updated.</response>
    /// <response code="400">The request body is not in a valid format.</response>
    /// <response code="404">There is no task with the given id on the Todo List.</response>
    /// <response code="500">An error occurred on the server while processing the request.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(int id, InsertUpdateToDoTask updateTask)
    {
        try
        {
            await _toDoTaskService.UpdateAsync(id, updateTask);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Delete a task from the Todo List by it's "id".
    /// </summary>
    /// <param name="id">The task id.</param>
    /// <remarks>
    /// Sample request:
    /// 
    ///     DELETE: /tasks/12
    ///     
    /// </remarks>
    /// <response code="204">The task has been deleted.</response>
    /// <response code="400">The request id is not valid.</response>
    /// <response code="404">There is no task with the given id on the Todo List.</response>
    /// <response code="500">An error occurred on the server while processing the request.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _toDoTaskService.DeleteAsync(id);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Returns all the tasks in ToDo List.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET: /tasks
    /// 
    /// </remarks>
    /// <response code="200">The operation was successful.</response>
    /// <response code="500">An error occurred on the server while processing the request.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _toDoTaskService.GetAllAsync());
    }
}

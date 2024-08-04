using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

public class InsertUpdateToDoTask
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public bool Completed { get; set; }
}

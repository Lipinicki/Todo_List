using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;

public class InsertUpdateToDoTask
{
    [Required, MaxLength(100)]
    public string? Title { get; set; }
    [Required, MaxLength(1000)]
    public string? Description { get; set; }
    [Required]
    public bool Completed { get; set; }
}

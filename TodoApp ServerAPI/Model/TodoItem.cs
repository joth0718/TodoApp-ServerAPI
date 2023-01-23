using System.ComponentModel.DataAnnotations;

namespace TodoApp_ServerAPI.Model
{
    public sealed class TodoItem
    {
        [Key] public int TodoItemId { get; set; }

        [Required] public string? Description { get; set; }

        [Required] public TodoStatus TodoStatus { get; set; }

    }
}

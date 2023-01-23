using System.ComponentModel.DataAnnotations;

namespace TodoApp_ServerAPI.Model
{
    public sealed class User
    {
        [Key] public int UserId { get; set; }

    }
}

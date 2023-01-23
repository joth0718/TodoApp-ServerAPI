using TodoApp_ServerAPI.Model;

namespace TodoApp_ServerAPI.Data.Interfaces
{
    public interface IItemRepository
    {
        Task<List<TodoItem>> GetListTodoItem();

        Task<TodoItem> GetTodoItemById(int id);

        Task<bool> CreateTodoItem(TodoItem item);

        Task<bool> UpdateTodoItem(TodoItem item);

        Task<bool> DeleteTodoItemById(int id);
    }
}

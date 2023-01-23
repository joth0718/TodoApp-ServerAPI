using Microsoft.EntityFrameworkCore;
using TodoApp_ServerAPI.Data.Interfaces;
using TodoApp_ServerAPI.Model;

namespace TodoApp_ServerAPI.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TodoItem>> GetListTodoItem()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItemById(int id)
        {
            return (await _context.TodoItems.FirstOrDefaultAsync(todoItem => todoItem.TodoItemId == id)) ?? throw new InvalidOperationException();
        }

        public async Task<bool> CreateTodoItem(TodoItem item)
        {
            try
            {
                await _context.TodoItems.AddAsync(item);
                return await _context.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTodoItem(TodoItem item)
        {
            try
            {
                _context.TodoItems.Update(item);
                return await _context.SaveChangesAsync() >= 1;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<bool> DeleteTodoItemById(int id)
        {
            try
            {
                TodoItem itemToDelete = await GetTodoItemById(id);
                _context.Remove(itemToDelete);

                return await _context.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

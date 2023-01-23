using Microsoft.EntityFrameworkCore;
using TodoApp_ServerAPI.Model;

namespace TodoApp_ServerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TodoItem[] items = new TodoItem[4];
            User[] users = new User[4];

            users[0] = new User { UserId = 1, UserName = "admin" };
            users[1] = new User { UserId = 2, UserName = "Johan" };
            users[2] = new User { UserId = 3, UserName = "Nikolai" };
            users[3] = new User { UserId = 4, UserName = "Johannes" };

            for (var i = 1; i <= 4; i++)
            {
                items[i - 1] = new TodoItem
                {
                    TodoItemId = i,
                    TodoStatus = TodoStatus.Created,
                    Description = $"Task {i} to do"
                };
            }

            modelBuilder.Entity<TodoItem>().HasData(items);
            modelBuilder.Entity<User>().HasData(users);
        }
    }
}

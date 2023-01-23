using Microsoft.EntityFrameworkCore;
using TodoApp_ServerAPI.Data.Interfaces;
using TodoApp_ServerAPI.Model;

namespace TodoApp_ServerAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task<bool> CreateUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                return await _context.SaveChangesAsync() >= 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserName == userName) ?? throw new InvalidOperationException();
        }

        public User GetUserByUserId(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId) ?? throw new InvalidOperationException();
        }
    }
}

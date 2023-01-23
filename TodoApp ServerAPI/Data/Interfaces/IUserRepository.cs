using TodoApp_ServerAPI.Model;

namespace TodoApp_ServerAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);

        Task<User> GetUserByUserName(string userName);

        User GetUserByUserId(int userId);
    }
}

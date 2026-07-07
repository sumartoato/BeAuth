using BeRme.Models;

namespace BeRme.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User?> GetByIdAsync(int id);

        Task<User?> GetByUsernameAsync(string username);

        Task<User> CreateAsync(User user);

        Task<User> UpdateAsync(User user);

        Task DeleteAsync(int id);
    }
}
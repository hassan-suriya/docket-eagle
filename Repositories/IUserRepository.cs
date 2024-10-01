
using Docket_Eagle.Models;

public interface IUserRepository
{
    Task CreateAsync(User entity);
    Task DeleteAsync(string id);
    Task<List<User>> GetAllAsync();
    Task<User> GetByEmail(string email);
    Task<User> GetByIdAsync(string id);
    Task UpdateAsync(string id, User entity);
}
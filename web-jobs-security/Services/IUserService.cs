using web_jobs_security.Models;

namespace web_jobs_security.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> getAll();

        Task<User> getUserById(int id);

        Task<User> getUserByEmail(string email);

        Task<bool> save(User user);

        Task<bool> update(User user);

        Task<bool> delete(int id);
    }
}

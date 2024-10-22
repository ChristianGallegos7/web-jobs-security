using web_jobs_security.DTOs;
using web_jobs_security.Models;

namespace web_jobs_security.Services
{
    public interface ILoginService
    {
        Task<User> Login(LoginRequestDto loginRequestDto);
        
    }
}

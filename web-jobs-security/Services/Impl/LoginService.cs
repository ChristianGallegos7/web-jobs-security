using Microsoft.EntityFrameworkCore;
using web_jobs_security.DTOs;
using web_jobs_security.Models;
using web_jobs_security.Repositories;

namespace web_jobs_security.Services.Impl
{
    public class LoginService : ILoginService
    {
        private readonly Contexto _contexto;

        public LoginService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<User> Login(LoginRequestDto loginRequestDto)
        {
            return await authUser(loginRequestDto.Username, loginRequestDto.Password);
        }

        public async Task<User> authUser(string username, string password)
        {
            var userData = await _contexto.Usuario.Where(usuario => usuario.Estado.Equals("A") && usuario.Email.Equals(username) &&
              usuario.Password.Equals(password)
            ).FirstOrDefaultAsync();

            return userData;
        }
    }
}

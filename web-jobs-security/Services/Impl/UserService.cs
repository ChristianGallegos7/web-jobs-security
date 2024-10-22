using Microsoft.EntityFrameworkCore;
using web_jobs_security.Models;
using web_jobs_security.Repositories;

namespace web_jobs_security.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly Contexto _contexto;

        public UserService(Contexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<IEnumerable<User>> getAll()
        {
            var users = await _contexto.Usuario.Where(x => x.Estado.Equals("A")).ToListAsync();
            return users;
        }

        public async Task<User> getUserByEmail(string email)
        {
            var user = await _contexto.Usuario.Where(x => x.Equals(email) && x.Estado.Equals("A")).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> getUserById(int id)
        {
            var user = await _contexto.Usuario.Where(x => x.Estado.Equals("A") && x.Id.Equals(id)).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> save(User user)
        {
            try
            {
                //Existe correo electronico (usuario) en la base de datos
                var userExists = await getUserByEmail(user.Email);
                if (userExists != null)
                {
                    return false;
                }

                user.Add = DateTime.Now;
                user.Estado = "A";

                _contexto.Add(user);

                return await _contexto.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> update(User user)
        {
            try
            {
                //Existe correo electronico (usuario) en la base de datos
                var userExists = await getUserById(user.Id);
                if (userExists != null)
                {
                    _contexto.Entry(user).State = EntityState.Modified;
                    return await _contexto.SaveChangesAsync() > 0;
                }

                return false;

            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> delete(int id)
        {
            try
            {
                //Existe correo electronico (usuario) en la base de datos
                var userExists = await getUserById(id);
                if (userExists != null)
                {
                    userExists.Estado = "I";
                    _contexto.Entry(userExists).State = EntityState.Modified;
                    return await _contexto.SaveChangesAsync() > 0;
                }

                return false;

            }
            catch
            {
                return false;
            }
        }
    }
}

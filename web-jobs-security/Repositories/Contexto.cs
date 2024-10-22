using Microsoft.EntityFrameworkCore;
using web_jobs_security.Models;

namespace web_jobs_security.Repositories
{
    public class Contexto : DbContext
    {
      
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<User> Usuario { get; set; }

        public DbSet<Rol> Rol { get; set; }
    }
}

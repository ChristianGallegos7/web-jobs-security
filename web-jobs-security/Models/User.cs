using System.ComponentModel.DataAnnotations;

namespace web_jobs_security.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName {  get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string? Phone { get; set; }

        public string Estado { get; set; }

        public DateTime Add { get; set; }

        public int RolId { get; set; }
        
        public virtual Rol Rol { get; set; }

    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace web_jobs_security.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public string Status { get; set; } = null!; 

        public DateTime Add { get; set; }

        public virtual ICollection<User> Usuarios { get; set; } = null!;
    }
}

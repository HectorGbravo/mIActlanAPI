using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Like> LikesLista { get; set; }

    }
}

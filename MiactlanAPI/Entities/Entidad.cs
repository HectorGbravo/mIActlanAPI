using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class Entidad
    {
        [Key]
        public int IdEntidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Entrada> EntradasLista { get; set; }
    }
}

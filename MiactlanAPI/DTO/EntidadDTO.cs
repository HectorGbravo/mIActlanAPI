using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.DTO
{
    public class EntidadDTO
    {
        public int IdEntidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string LatCentral { get; set; }
        public string LngCentral { get; set; }
        public EstadoDTO Estado { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

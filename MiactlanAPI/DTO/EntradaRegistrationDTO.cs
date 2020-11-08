using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.DTO
{
    public class EntradaRegistrationDTO
    {
        public int IdEntrada { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int IdEntidad { get; set; }
        public string IdUsuario { get; set; }
        public List<int> ListaCategorias { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class Entrada
    {
        [Key]
        public int IdEntrada { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public long IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public int IdEntidad { get; set; }
        public Entidad Entidad { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

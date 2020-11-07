using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }
        public int IdEntrada { get; set; }
        public Entrada Entrada { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

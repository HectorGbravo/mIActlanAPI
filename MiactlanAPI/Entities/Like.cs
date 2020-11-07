using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class Like
    {
        [Key]
        public int IdLike { get; set; }
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdEntrada { get; set; }
        public Entrada Entrada { get; set; }
    }
}

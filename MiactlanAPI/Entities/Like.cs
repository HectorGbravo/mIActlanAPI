using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class Like
    {
        [Key]
        public int IdLike { get; set; }
        public string IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public int IdEntrada { get; set; }
        [ForeignKey("IdEntrada")]
        public Entrada Entrada { get; set; }
    }
}

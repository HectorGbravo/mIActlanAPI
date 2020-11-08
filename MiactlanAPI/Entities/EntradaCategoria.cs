using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class EntradaCategoria
    {
        [Key]
        public int IdEntradaCategoria { get; set; }
        public int IdEntrada { get; set; }
        [ForeignKey("IdEntrada")]
        public Entrada Entrada { get; set; }
        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
    }
}

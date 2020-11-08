using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class Archivo
    {
        [Key]
        public int IdArchivo { get; set; }
        public int IdEntrada { get; set; }
        [ForeignKey("IdEntrada")]
        [JsonIgnore]
        public Entrada Entrada { get; set; }
        public string UrlArchivo { get; set; }
        public string MimeType { get; set; }
        [JsonIgnore]
        public ICollection<ArchivoCategoriaArchivo> CategoriasLink { get; set; }
    }
}

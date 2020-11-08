using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class ArchivoCategoriaArchivo
    {
        [Key]
        public int IdArchivoCategoriaArchivo { get; set; }
        public int IdArchivo { get; set; }
        [ForeignKey("IdArchivo")]
        [JsonIgnore]
        public Archivo Archivo { get; set; }
        public int IdCategoriaArchivo { get; set; }
        [ForeignKey("IdCategoriaArchivo")]
        [JsonIgnore]
        public CategoriaArchivo CategoriaArchivo { get; set; }
    }
}

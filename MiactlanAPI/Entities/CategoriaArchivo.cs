using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Entities
{
    public class CategoriaArchivo
    {
        [Key]
        public int IdCategoriaArchivo { get; set; }
        public string CategoriaTagId { get; set; }
        public string Nombre { get; set; }
        [JsonIgnore]
        public ICollection<ArchivoCategoriaArchivo> ArchivosLink { get; set; }
    }
}

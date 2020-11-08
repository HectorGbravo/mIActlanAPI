using MiactlanAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.DTO
{
    public class ArchivoDTO
    {
        public int IdArchivo { get; set; }
        public string UrlArchivo { get; set; }
        public string MimeType { get; set; }
        public List<CategoriaArchivo> CategoriaArchivos { get; set; }
    }
}

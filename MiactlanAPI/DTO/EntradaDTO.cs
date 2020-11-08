using MiactlanAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.DTO
{
    public class EntradaDTO
    {
        public int IdEntrada { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public UsuarioDTO usuario { get; set; }
        public EntidadDTO Entidad { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsLiked { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<ArchivoDTO> Archivos { get; set; }
    }
}

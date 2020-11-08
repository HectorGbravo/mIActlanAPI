using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string LatOrigen { get; set; }
        public string LngOrigen { get; set; }
        public int IdEntidad { get; set; }
        [ForeignKey("IdEntidad")]
        public Entidad Entidad { get; set; }
        public string IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Like> LikesLista { get; set; }
        public ICollection<Comentario> ComentariosLista { get; set; }
        public ICollection<EntradaCategoria> CategoriasLink { get; set; }

    }
}

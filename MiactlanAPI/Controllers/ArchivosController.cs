using AutoMapper;
using MiactlanAPI.Context;
using MiactlanAPI.DTO;
using MiactlanAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchivosController : ControllerBase
    {
        private readonly MiactlanDbContext _context;
        private readonly IMapper _mapper;

        public ArchivosController(MiactlanDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchivoDTO>>> GetArchivos()
        {
            var archivos = await _context.Archivos.Include(x => x.CategoriasLink).ThenInclude(y => y.CategoriaArchivo).ToListAsync();
            var archivosDTO = _mapper.Map<List<ArchivoDTO>>(archivos);
            return archivosDTO;
        }

        [HttpGet]
        [Route("categoria/{categoria}")]
        public async Task<ActionResult<IEnumerable<ArchivoDTO>>> GetArchivosByCategoria(string categoria)
        {
            var categoriaArchivo = await _context.CategoriaArchivos.Where(x => x.Nombre == categoria).FirstOrDefaultAsync();
            var archivosCategoriaArchivos = await _context.ArchivoCategoriaArchivos.Where(x => x.IdCategoriaArchivo == categoriaArchivo.IdCategoriaArchivo).Include(x => x.Archivo).ToListAsync();
            var archivosDTO = new List<ArchivoDTO>();
            foreach(ArchivoCategoriaArchivo archivo in archivosCategoriaArchivos)
            {
                ArchivoDTO archivoDTO = new ArchivoDTO()
                {
                    IdArchivo = archivo.Archivo.IdArchivo,
                    MimeType = archivo.Archivo.MimeType,
                    UrlArchivo = archivo.Archivo.UrlArchivo,
                    CategoriaArchivos = new List<CategoriaArchivo>()
                    {
                        categoriaArchivo
                    }
                };
                archivosDTO.Add(archivoDTO);
            }
            return archivosDTO;
        }
    }
}

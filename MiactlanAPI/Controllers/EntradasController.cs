using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiactlanAPI.Context;
using MiactlanAPI.Entities;
using MiactlanAPI.DTO;
using AutoMapper;
using System.Net.Http;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using MiactlanAPI.Models;
using System.IO;
using MiactlanAPI.Services;
using Microsoft.Extensions.Configuration;

namespace MiactlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradasController : ControllerBase
    {
        private readonly MiactlanDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;

        public EntradasController(MiactlanDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            this.configuration = configuration;
        }

        // GET: api/Entradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrada>>> GetEntrada()
        {
            return await _context.Entradas.ToListAsync();
        }

        [HttpGet]
        [Route("Usuario/{id}")]
        public async Task<ActionResult<IEnumerable<EntradaDTO>>> GetEntradasByUsuario(string id)
        {
            var usuarioLike = await _context.Likes.Where(x => x.IdUsuario == id).ToListAsync();
            var entradas = await _context.Entradas
                .Include(x => x.Usuario)
                .Include(x => x.Entidad)
                .Include(x => x.CategoriasLink)
                .ThenInclude(x => x.Categoria)
                .ToListAsync();
            var entradasDTO = _mapper.Map<List<EntradaDTO>>(entradas);
            foreach(EntradaDTO entradaDTO in entradasDTO) {
                if (usuarioLike.Where(x => x.IdEntrada == entradaDTO.IdEntrada && x.IdUsuario == entradaDTO.usuario.id).FirstOrDefault() != null)
                {
                    entradaDTO.IsLiked = true;
                }
            }
            return entradasDTO;
        }
        
        [HttpGet]
        [Route("Usuario/{id}/User")]
        public async Task<ActionResult<IEnumerable<EntradaDTO>>> GetEntradasUsuario(string id)
        {
            var usuarioLike = await _context.Likes.Where(x => x.IdUsuario == id).ToListAsync();
            var entradas = await _context.Entradas
                .Include(x => x.Usuario)
                .Include(x => x.Entidad)
                .Include(x => x.CategoriasLink)
                .ThenInclude(x => x.Categoria)
                .Where(x => x.IdUsuario == id)
                .ToListAsync();
            var entradasDTO = _mapper.Map<List<EntradaDTO>>(entradas);
            foreach (EntradaDTO entradaDTO in entradasDTO)
            {
                if (usuarioLike.Where(x => x.IdEntrada == entradaDTO.IdEntrada && x.IdUsuario == entradaDTO.usuario.id).FirstOrDefault() != null)
                {
                    entradaDTO.IsLiked = true;
                }
            }
            return entradasDTO;
        }

        [HttpGet]
        [Route("Usuario/{id}/Liked")]
        public async Task<ActionResult<IEnumerable<EntradaDTO>>> GetEntradasByUsuarioLiked(string id)
        {
            var usuarioLike = await _context.Likes.Where(x => x.IdUsuario == id).ToListAsync();
            var entradas = await _context.Entradas
                .Include(x => x.Usuario)
                .Include(x => x.Entidad)
                .Include(x => x.CategoriasLink)
                .ThenInclude(x => x.Categoria)
                .ToListAsync();
            var entradasDTO = _mapper.Map<List<EntradaDTO>>(entradas);
            foreach (EntradaDTO entradaDTO in entradasDTO)
            {
                if (usuarioLike.Where(x => x.IdEntrada == entradaDTO.IdEntrada && x.IdUsuario == entradaDTO.usuario.id).FirstOrDefault() != null)
                {
                    entradaDTO.IsLiked = true;
                }
            }
            return entradasDTO.Where(x => x.IsLiked == true).ToList();
        }
        
        // GET: api/Entradas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrada>> GetEntrada(int id)
        {
            var entrada = await _context.Entradas.FindAsync(id);

            if (entrada == null)
            {
                return NotFound();
            }

            return entrada;
        }

        // PUT: api/Entradas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrada(int id, EntradaRegistrationDTO entrada)
        {
            if (id != entrada.IdEntrada)
            {
                return BadRequest();
            }

            Entrada entradaR = new Entrada()
            {
                IdEntrada = entrada.IdEntrada,
                IdEntidad = entrada.IdEntidad,
                Titulo = entrada.Titulo,
                Texto = entrada.Texto,
                IdUsuario = entrada.IdUsuario,
                CreatedAt = entrada.CreatedAt,
                UpdatedAt = DateTime.Now
            };

            _context.Entry(entradaR).State = EntityState.Modified;

            if (entrada.ListaCategorias != null && entrada.ListaCategorias.Count > 0)
            {
                var entradas = _context.EntradaCategorias.Where(x => x.IdEntrada == id).AsEnumerable();
                _context.EntradaCategorias.RemoveRange(entradas);
                foreach (int i in entrada.ListaCategorias)
                {
                    if (await _context.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == i) != null)
                    {
                        var entradaCategoria = new EntradaCategoria
                        {
                            IdCategoria = i,
                            IdEntrada = entrada.IdEntrada
                        };
                        _context.EntradaCategorias.Add(entradaCategoria);
                    }

                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Entradas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Entrada>> PostEntrada(EntradaRegistrationDTO entradaDTO)
        {
            if (entradaDTO.ListaCategorias == null || entradaDTO.ListaCategorias.Count == 0)
            {
                return BadRequest("Se necesitan de una o más categorias");
            }

            var clientTexto = new HttpClient();
            var queryStringTexto = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            clientTexto.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "399faba124ec4fbfbef082c9f76267e3");
            // Request parameters
            queryStringTexto["classify"] = "true";
            var uriTexto = "https://miactlan.cognitiveservices.azure.com/contentmoderator/moderate/v1.0/ProcessText/Screen?" + queryStringTexto;

            HttpResponseMessage responseTexto;
            string textoAEvaluar = entradaDTO.Titulo + " " + entradaDTO.Texto;
            responseTexto = await clientTexto.PostAsync(uriTexto, new StringContent(textoAEvaluar, Encoding.UTF8, "text/plain"));
            var responseTextoText = await responseTexto.Content.ReadAsStringAsync();
            var resultTexto = JsonConvert.DeserializeObject<TextApiResponse>(responseTextoText);

            if (resultTexto.Terms.Count > 0)
            {
                return BadRequest("El texto contiene palabras ofensivas.");
            }

            Entrada entrada = new Entrada()
            {
                Titulo = entradaDTO.Titulo,
                Texto = entradaDTO.Texto,
                IdEntidad = entradaDTO.IdEntidad,
                IdUsuario = entradaDTO.IdUsuario,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Entradas.Add(entrada);

            await _context.SaveChangesAsync();

            foreach (int i in entradaDTO.ListaCategorias)
            {
                if (await _context.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == i) != null)
                {
                    var entradaCategoria = new EntradaCategoria
                    {
                        IdCategoria = i,
                        IdEntrada = entrada.IdEntrada
                    };
                    _context.EntradaCategorias.Add(entradaCategoria);
                }
                
            }

            await _context.SaveChangesAsync();

            return Ok(entrada);
        }

        [HttpPost]
        [Route("archivos/{id}")]
        public async Task<ActionResult> StoreFiles(int id,[FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("Se deben incluir archivos");
            }
            BlobStorageService blobStorageService = new BlobStorageService(this.configuration);
            bool negative = false;
            foreach (IFormFile formFile in files)
            {
                var fileName = Path.GetFileName(formFile.FileName);
                string mimeType = formFile.ContentType;
                byte[] fileData;
                using (var target = new MemoryStream())
                {
                    formFile.CopyTo(target);
                    fileData = target.ToArray();
                }
                string filePath = blobStorageService.UploadFileToBlob(formFile.FileName, fileData, mimeType);

                DataRepresentationApi dataRepresentationApi = new DataRepresentationApi();
                dataRepresentationApi.DataRepresentation = "URL";
                dataRepresentationApi.Value = filePath;
                var jsonString = JsonConvert.SerializeObject(dataRepresentationApi);
                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "399faba124ec4fbfbef082c9f76267e3");
                // Request parameters
                queryString["enhanced"] = "true";
                var uri = "https://miactlan.cognitiveservices.azure.com/contentmoderator/moderate/v1.0/ProcessImage/Evaluate?" + queryString;

                HttpResponseMessage response;

                response = await client.PostAsync(uri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
                var responseImagenText = await response.Content.ReadAsStringAsync();
                var resultImagen = JsonConvert.DeserializeObject<ImageApiResponse>(responseImagenText);
                if (resultImagen.IsImageAdultClassified == true ||
                    resultImagen.AdultClassificationScore >= 0.9 ||
                    resultImagen.IsImageRacyClassified == true ||
                    resultImagen.RacyClassificationScore >= 0.9)
                {
                    blobStorageService.DeleteBlobData(filePath);
                    negative = true;
                }

                Archivo archivo = new Archivo()
                {
                    IdEntrada = id,
                    UrlArchivo = filePath,
                    MimeType = mimeType
                };

                _context.Archivos.Add(archivo);

                await _context.SaveChangesAsync();

                var customVisionClient = new HttpClient();
                customVisionClient.DefaultRequestHeaders.Add("Prediction-Key", "fa249ba3cc844f2287c23e5bf874d4ac");

                var uriCustomVision = "https://southcentralus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/85352c53-ff84-4fd0-b3ff-b6212f5257c3/classify/iterations/mIActlanCV/url";

                CustomVisionRequest customVisionRequest = new CustomVisionRequest();
                customVisionRequest.Url = filePath;
                var jsonStringCV = JsonConvert.SerializeObject(customVisionRequest);

                HttpResponseMessage responseCustom;

                responseCustom = await customVisionClient.PostAsync(uriCustomVision, new StringContent(jsonStringCV, Encoding.UTF8, "application/json"));
                var resultCustom = await responseCustom.Content.ReadAsStringAsync();
                var resultadoCV = JsonConvert.DeserializeObject<CustomVisionResponse>(resultCustom);
                foreach(Prediction prediction in resultadoCV.predictions)
                {
                    if (prediction.probability >= 0.9)
                    {
                        var categoria = await _context.CategoriaArchivos.Where(x => x.CategoriaTagId == prediction.tagId).FirstOrDefaultAsync();
                        if (categoria != null)
                        {
                            ArchivoCategoriaArchivo archivoCategoriaArchivo = new ArchivoCategoriaArchivo()
                            {
                                IdArchivo = archivo.IdArchivo,
                                IdCategoriaArchivo = categoria.IdCategoriaArchivo
                            };
                            _context.ArchivoCategoriaArchivos.Add(archivoCategoriaArchivo);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }

            if ( negative == true )
            {
                return Ok("Se encontraron archivos con contenido inadecuado. No se registraron");
            }

            return Ok("Los archivos han sido registrados");
        }

        // DELETE: api/Entradas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entrada>> DeleteEntrada(int id)
        {
            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }

            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();

            return entrada;
        }

        private bool EntradaExists(int id)
        {
            return _context.Entradas.Any(e => e.IdEntrada == id);
        }
    }
}

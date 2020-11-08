using MiactlanAPI.Context;
using MiactlanAPI.Entities;
using Microsoft.AspNetCore.Identity;
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
    public class UsuariosController : ControllerBase
    {
        private readonly MiactlanDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public UsuariosController(MiactlanDbContext context, UserManager<Usuario> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<Usuario>> Registrar(UsuarioRegistrationDTO usuario)
        {
            var existe = await this._context.Usuarios.Where(x => x.Email == usuario.Email || x.UserName == usuario.UserName).AnyAsync();
            if (existe)
            {
                return BadRequest("El email ingresado ya existe");
            }

            var existeUsuario = await this._context.Usuarios.Where(x => x.UserName == usuario.UserName).AnyAsync();
            if (existeUsuario)
            {
                return BadRequest("El nombre de usuario ingresado ya existe");
            }

            var usuarioR = new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                UserName = usuario.UserName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var resultado = await this._userManager.CreateAsync(usuarioR, usuario.Password);
            if (resultado.Succeeded)
            {
                return usuarioR;
                /*
                return new UsuarioData
                {
                    NombreCompleto = usuario.NombreCompleto,
                    Token = this.jwtGenerador.CrearToken(usuario),
                    Email = usuario.Email,
                    Username = usuario.UserName,
                    Imagen = null,
                };
                */
            }

            return BadRequest("No se pudo agregar al nuevo usuario");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlumaWeb.Data;
using PlumaWeb.Models;
using PlumaWeb.DTOs;

namespace PlumaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly PostgresContext _context;

        public UsuariosController(PostgresContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO login)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Perfils)
                .FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);
            if (usuario == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Usuario o contraseña incorrectos");
            }
            Perfil? usuarioPerfil = usuario.Perfils.FirstOrDefault();

            if (usuarioPerfil == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "El usuario no tiene perfil asignado");
            }

            SessionDTO session = new SessionDTO();
            session.Username = usuario.Username;
            session.Perfil = usuarioPerfil;
            return StatusCode(StatusCodes.Status200OK, session);

        }
    }
}

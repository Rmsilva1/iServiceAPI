using iServiceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iServiceApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuarios")]
    public class UsuarioController : Controller
    {
        private readonly Services.IRepository<Usuario> _repository;

        public UsuarioController(Services.IRepository<Usuario> repo)
        {
            _repository = repo;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IEnumerable<Usuario> GetUsuario()
        {
            return _repository.GetAll();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = _repository.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario([FromRoute] int id, [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != usuario.Id)
                return BadRequest();

            try
            {
                await _repository.UpdateAsync(usuario);
            }
            catch (Exception)
            {
                if (!_repository.Exists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (usuario.HashAuth == null)
            {
                usuario.HashAuth = Guid.NewGuid().ToString();
            }

            try
            {
                await _repository.Insert(usuario);
            }
            catch (Exception)
            {

            }

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception)
            {
                if (!_repository.Exists(id))
                    return NotFound();
                else
                    throw;
            }
           
            return Ok(id);
        }
    }
}

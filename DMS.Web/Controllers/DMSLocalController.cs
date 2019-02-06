using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DMS.Datos;
using DMS.Entidades.Maestros;
using DMS.Web.Models.Maestros.DMSLocal;

namespace DMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DMSLocalController : ControllerBase
    {
        private readonly DbContextDMS _context;

        public DMSLocalController(DbContextDMS context)
        {
            _context = context;
        }

        // GET: api/DMSLocal/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<DMSLocalViewModel>> Listar()
        {
            var dmslocal = await _context.DMSLocal.ToListAsync();

            return dmslocal.Select(c => new DMSLocalViewModel
            {
                DMSLocalID = c.DMSLocalID,
                DMSLocalName = c.DMSLocalName,
                DMSLocalActive = c.DMSLocalActive
            });

            //return _context.DMSLocal;
        }

        // GET: api/DMSLocal/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var dMSLocal = await _context.DMSLocal.FindAsync(id);

            if (dMSLocal == null)
            {
                return NotFound();
            }

            return Ok(new DMSLocalViewModel {
                DMSLocalID = dMSLocal.DMSLocalID,
                DMSLocalName = dMSLocal.DMSLocalName,
                DMSLocalActive = dMSLocal.DMSLocalActive
            });
        }

        // PUT: api/DMSLocal/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.DMSLocalID <= 0)
            {
                return BadRequest();
            }

            var dmslocal = await _context.DMSLocal.FirstOrDefaultAsync(c => c.DMSLocalID == model.DMSLocalID);

            if (dmslocal == null)
            {
                return NotFound();
            }

            dmslocal.DMSLocalName = model.DMSLocalName;
            dmslocal.DMSLocalActive = model.DMSLocalActive;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/DMSLocal/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DMSLocal dmslocal = new DMSLocal
            {
                DMSLocalName = model.DMSLocalName,
                DMSLocalActive = model.DMSLocalActive
            };

            _context.DMSLocal.Add(dmslocal);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            return Ok();


        }

        // DELETE: api/DMSLocal/Eliminar/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dMSLocal = await _context.DMSLocal.FindAsync(id);
            if (dMSLocal == null)
            {
                return NotFound();
            }

            _context.DMSLocal.Remove(dMSLocal);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            

            return Ok(dMSLocal);
        }

        // PUT: api/DMSLocal/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var dmslocal = await _context.DMSLocal.FirstOrDefaultAsync(c => c.DMSLocalID == id);

            if (dmslocal == null)
            {
                return NotFound();
            }

            dmslocal.DMSLocalActive = 0;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/DMSLocal/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var dmslocal = await _context.DMSLocal.FirstOrDefaultAsync(c => c.DMSLocalID == id);

            if (dmslocal == null)
            {
                return NotFound();
            }

            dmslocal.DMSLocalActive = 1;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }


        private bool DMSLocalExists(int id)
        {
            return _context.DMSLocal.Any(e => e.DMSLocalID == id);
        }
    }
}
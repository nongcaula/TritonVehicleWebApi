using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TritonVehicleWebApi;
using TritonVehicleWebApi.Models;

namespace TritonVehicleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelsController : ControllerBase
    {
        private readonly ModelContext _context;

        public ParcelsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Parcels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcel>>> GetParcel()
        {
            return await _context.Parcel.ToListAsync();
        }

        // GET: api/Parcels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parcel>> GetParcel(int id)
        {
            var parcel = await _context.Parcel.FindAsync(id);

            if (parcel == null)
            {
                return NotFound();
            }

            return parcel;
        }

        // PUT: api/Parcels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcel(int id, Parcel parcel)
        {
            if (id != parcel.Id)
            {
                return BadRequest();
            }

            _context.Entry(parcel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelExists(id))
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

        // POST: api/Parcels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Parcel>> PostParcel(Parcel parcel)
        {
            _context.Parcel.Add(parcel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParcel", new { id = parcel.Id }, parcel);
        }

        // DELETE: api/Parcels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parcel>> DeleteParcel(int id)
        {
            var parcel = await _context.Parcel.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }

            _context.Parcel.Remove(parcel);
            await _context.SaveChangesAsync();

            return parcel;
        }

        private bool ParcelExists(int id)
        {
            return _context.Parcel.Any(e => e.Id == id);
        }
    }
}

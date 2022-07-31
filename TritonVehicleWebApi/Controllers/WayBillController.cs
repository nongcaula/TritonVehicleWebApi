using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TritonVehicleWebApi;
using TritonVehicleWebApi.Models;

namespace TritonVehicleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WayBillController : ControllerBase
    {
        private readonly ModelContext _context;

        public WayBillController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/WayBill
        [HttpGet]
        public WayBills GetWayBill()
        {
            WayBills wayBillMetaData = new WayBills();
            wayBillMetaData.WayBillForms =_context.WayBillForm.ToList();
            wayBillMetaData.Vehicles = _context.Vehicle.ToList();
            return  wayBillMetaData;
        }

        // GET: api/WayBill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WayBillForm>> GetWayBillForm(int id)
        {
            var wayBillForm = await _context.WayBillForm.FindAsync(id);

            if (wayBillForm == null)
            {
                return NotFound();
            }

            return wayBillForm;
        }

        // PUT: api/WayBill/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWayBillForm(int id, WayBillForm wayBillForm)
        {
            if (id != wayBillForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(wayBillForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WayBillFormExists(id))
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

        // POST: api/WayBill
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WayBillForm>> PostWayBillForm(WayBillForm wayBillForm)
        {
            try
            {
                wayBillForm.ReferenceNumber = generateID();
                _context.WayBillForm.Add(wayBillForm);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return CreatedAtAction("GetWayBillForm", new { id = wayBillForm.Id }, wayBillForm);
        }

        // DELETE: api/WayBill/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WayBillForm>> DeleteWayBillForm(int id)
        {
            var wayBillForm = await _context.WayBillForm.FindAsync(id);
            if (wayBillForm == null)
            {
                return NotFound();
            }

            _context.WayBillForm.Remove(wayBillForm);
            await _context.SaveChangesAsync();

            return wayBillForm;
        }

        private bool WayBillFormExists(int id)
        {
            return _context.WayBillForm.Any(e => e.Id == id);
        }

        public string generateID()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();

            return id;
        }
    }
}

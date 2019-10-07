using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RT3MobileServices.Models;

namespace RT3MobileServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly RTDataContext _context;

        public SeatsController(RTDataContext context)
        {
            _context = context;
        }

        // GET: api/Seats
        [HttpGet]
        [Route("Seats/All")]
        public IEnumerable<Seat> GetSeats()
        {
            return _context.Seats;
        }
        [HttpGet]
        [Route("Seats/My")]
        public IEnumerable<Seat> GetMySeats(string user)
        {
            return _context.Seats.Where<Seat>(S => S.BuyerName.StartsWith(user)).ToList();
        }

        // GET: api/Seats/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetSeat([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var seat = await _context.Seats.FindAsync(id);

        //    if (seat == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(seat);
        //}

        // PUT: api/Seats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeat([FromRoute] int id, [FromBody] Seat seat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seat.ID)
            {
                return BadRequest();
            }

            _context.Entry(seat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatExists(id))
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

        // POST: api/Seats
        [HttpPost]
        public async Task<IActionResult> PostSeat([FromBody] Seat seat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeat", new { id = seat.ID }, seat);
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seat = await _context.Seats.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();

            return Ok(seat);
        }

        private bool SeatExists(int id)
        {
            return _context.Seats.Any(e => e.ID == id);
        }
    }
}
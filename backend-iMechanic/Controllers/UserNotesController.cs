using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_iMechanic.Model;

namespace backend_iMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotesController : ControllerBase
    {
        private readonly iMechanicDbContext _context;

        public UserNotesController(iMechanicDbContext context)
        {
            _context = context;
        }

        // GET: api/UserNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserNotes>>> GetUserNotes()
        {
          if (_context.UserNotes == null)
          {
              return NotFound();
          }
            return await _context.UserNotes.ToListAsync();
        }

        // GET: api/UserNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserNotes>> GetUserNotes(int id)
        {
          if (_context.UserNotes == null)
          {
              return NotFound();
          }
            var userNotes = await _context.UserNotes.FindAsync(id);

            if (userNotes == null)
            {
                return NotFound();
            }

            return userNotes;
        }

        // PUT: api/UserNotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserNotes(int id, UserNotes userNotes)
        {
            if (id != userNotes.Id)
            {
                return BadRequest();
            }

            _context.Entry(userNotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserNotesExists(id))
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

        // POST: api/UserNotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserNotes>> PostUserNotes(UserNotes userNotes)
        {
          if (_context.UserNotes == null)
          {
              return Problem("Entity set 'iMechanicDbContext.UserNotes'  is null.");
          }
            _context.UserNotes.Add(userNotes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserNotes", new { id = userNotes.Id }, userNotes);
        }

        // DELETE: api/UserNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserNotes(int id)
        {
            if (_context.UserNotes == null)
            {
                return NotFound();
            }
            var userNotes = await _context.UserNotes.FindAsync(id);
            if (userNotes == null)
            {
                return NotFound();
            }

            _context.UserNotes.Remove(userNotes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserNotesExists(int id)
        {
            return (_context.UserNotes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

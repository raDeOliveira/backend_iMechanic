using backend_iMechanic.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<UserNote>>> GetUser_Notes()
        {
            if (_context.User_Notes == null)
            {
                return NotFound();
            }
            return await _context.User_Notes.ToListAsync();
        }

        // GET: api/UserNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserNote>> GetUserNote(int id)
        {
            if (_context.User_Notes == null)
            {
                return NotFound();
            }
            var userNote = await _context.User_Notes.FindAsync(id);

            if (userNote == null)
            {
                return NotFound();
            }

            return userNote;
        }

        // PUT: api/UserNotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserNote(int id, UserNote userNote)
        {
            if (id != userNote.Id)
            {
                return BadRequest();
            }

            _context.Entry(userNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserNoteExists(id))
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
        public async Task<ActionResult<UserNote>> PostUserNote(UserNote userNote)
        {
            if (_context.User_Notes == null)
            {
                return Problem("Entity set 'iMechanicDbContext.User_Notes'  is null.");
            }
            _context.User_Notes.Add(userNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserNote", new { id = userNote.Id }, userNote);
        }

        // DELETE: api/UserNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserNote(int id)
        {
            if (_context.User_Notes == null)
            {
                return NotFound();
            }
            var userNote = await _context.User_Notes.FindAsync(id);
            if (userNote == null)
            {
                return NotFound();
            }

            _context.User_Notes.Remove(userNote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserNoteExists(int id)
        {
            return (_context.User_Notes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // @@ info
        // CUSTOM METHODS
        [HttpPost("addNotes")]
        public IActionResult PostUserNotes([FromBody] UserNote userNote)
        {
            if (userNote == null)
            {
                return NotFound();
            }

            var insertUserNote = _context.Database
                .SqlQueryRaw<string>($"INSERT INTO USER_NOTES (ID_USER, NOTES, ID_CHOOSEN_CAR) VALUES ({1}, '{2}', {3})", userNote.Id_User, userNote.Notes, userNote.Id_Choosen_Car).ToList();

            System.Diagnostics.Debug.WriteLine(insertUserNote);

            return Ok(insertUserNote);
        }

    }
}


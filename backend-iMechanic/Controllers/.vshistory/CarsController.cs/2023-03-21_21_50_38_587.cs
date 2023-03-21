using backend_iMechanic.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_iMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly iMechanicDbContext _context;

        public CarsController(iMechanicDbContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'iMechanicDbContext.Cars'  is null.");
            }
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // @@info CUSTOM METHODS
        // get all DISTINCT BRANDS
        [HttpGet]
        [Route("/api/brands")]
        public IEnumerable<string> GetBrands()
        {
            if (_context.Cars == null)
            {
                return (IEnumerable<string>)NotFound();
            }

            var brands = (from b in _context.Cars
                          select b.Brand)
                          .Distinct()
                          .OrderBy(b => b);

            return brands;
        }

        // @@info "select DISTINCT model from cars where brand like '%$brand%' "
        [HttpGet]
        [Route("/api/models/{brand}")]
        public IEnumerable<string> GetModels(string brand)
        {
            if (_context.Cars == null)
            {
                return (IEnumerable<string>)NotFound();
            }

            var models = (from m in _context.Cars
                          where m.Brand == brand
                          select m.Model)
                          .Distinct()
                          .OrderBy(m => m);
            return models;
        }

        // @@info "select distinct `year` from cars where `year` between 1995 and 2018"
        [HttpGet]
        [Route("/api/years")]
        public string GetYears()
        {
            //if (_context.Cars == null)
            //{
            //    return (IEnumerable<string>)NotFound();
            //}
            //var years = (from y in _context.Cars
            //             where Convert.ToInt32(y.Year) >= 1995 && Convert.ToInt32(y.Year) <= 2018
            //             select y.Year)
            //             .Distinct()
            //             .OrderBy(y => y);

            var years = _context.Database
                .ExecuteSqlRaw("select distinct 'year' from cars where 'year' between '1995' and '2018'")
                .ToString();

            return years;
        }

        // get models brand
        [HttpGet]
        [Route("/api/brand/{brand}")]
        public IQueryable<Car> GetBrand(string brand)
        {
            var models = (from b in _context.Cars
                          where b.Brand == brand
                          select b);

            if (_context.Cars == null)
            {
                return (IQueryable<Car>)NotFound();
            }

            return models;
        }

        // get all fuel
        [HttpGet]
        [Route("/api/brand/fuel")]
        public IEnumerable<string> GetAllFuel()
        {
            if (_context.Cars == null)
                return (IEnumerable<string>)NotFound();

            // @@warn "select distinct engine_fuel from cars where engine_fuel not in ('-')"
            var fuels = (from f in _context.Cars
                         select f.Engine_Fuel)
                        .Distinct()
                        .OrderBy(f => f);

            return fuels;
        }


        // @@info "select distinct brand from cars where brand like '%$brand%' "
        [HttpGet]




        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

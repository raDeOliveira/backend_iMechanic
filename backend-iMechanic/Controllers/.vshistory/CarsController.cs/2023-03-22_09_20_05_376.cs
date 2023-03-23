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

        // @@info get all DISTINCT MODELS from brand
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

        // @@info get all DISTINCT YEARS between 1995 and 2018"
        [HttpGet]
        [Route("/api/years")]
        public IEnumerable<string> GetYears()
        {
            if (_context.Cars == null)
            {
                return (IEnumerable<string>)NotFound();
            }

            var years = (from y in _context.Cars
                         where y.Year >= 1995 && y.Year <= 2018
                         select y.Year)
                         .Distinct()
                         .OrderBy(y => y);

            //var years = _context.Database
            //    .SqlQuery<string>($"select distinct year from cars where year between '1995' and '2018'")
            //    .ToList();

            return years;
        }

        // get all FUELS
        [HttpGet]
        [Route("/api/fuels")]
        public IEnumerable<string> GetAllFuel()
        {
            if (_context.Cars == null)
                return (IEnumerable<string>)NotFound();

            var fuels = (from f in _context.Cars
                         where f.Engine_Fuel != null
                         select f.Engine_Fuel)
                        .Distinct()
                        .OrderBy(f => f);

            return fuels;
        }

        // get SELECTED CAR
        // select * from cars where brand = '$brand' and model like '%$model%' and engine_fuel like '%$fuel%'
        [HttpGet]
        [Route("/api/car/{brand}/{model}/{fuel}")]
        public IOrderedQueryable<Car> GetSelectedCar(string brand, string model, string fuel)
        {
            //if (_context.Cars == null)
            //{
            //    return (IEnumerable<string>)NotFound();
            //}

            var car = (from c in _context.Cars
                       where c.Brand == brand && c.Model == model && c.Engine_Fuel == fuel
                       select c)
                       .Distinct()
                       .OrderBy(c => c);

            return car;
        }


        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace SourabhAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourabhController : ControllerBase
    {
      private static List<Sourabh>  Brothers= new List<Sourabh>
            {
                new Sourabh
                {
                    Id = 1,
                    Name = "Bhaiya",
                    FirstName = "Govind",
                    LastName ="Yadav",
                    Place ="Mainpuri"
                },
                 new Sourabh
                {
                    Id = 2,
                    Name = "Bhaiya",
                    FirstName = "Arjun",
                    LastName ="Yadav",
                    Place ="Home"
                }
            };
        private readonly DataContext _context;
        public SourabhController(DataContext context)
        {
                _context = context; 
        }

        [HttpGet]   
        public async Task<ActionResult<List<Sourabh>>> Get()
        {
            return Ok(await _context.Sourabhs.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sourabh>> Get(int id)
        {
            var Brother = await _context.Sourabhs.FindAsync(id);
            if (Brother == null)
            {
                return BadRequest("Brother not found"); 
            }
            return Ok(Brother);
        }
        [HttpPost]
        public async Task<ActionResult<List<Sourabh>>> AddBrother(Sourabh Brother)
        {
             _context.Sourabhs.Add(Brother);
            await _context.SaveChangesAsync();
            return Ok(await _context.Sourabhs.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<Sourabh>> UpdateBrother(Sourabh request)
        {
            var dbBrother = await _context.Sourabhs.FindAsync(request.Id);
            if (dbBrother == null)
            {
                return BadRequest("Brother not found");
            }
            dbBrother.Name = request.Name;
            dbBrother.FirstName = request.FirstName;  
            dbBrother.LastName = request.LastName;
            dbBrother.Place = request.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.Sourabhs.ToListAsync()); 
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Sourabh>>> Delete(int id)
        {
            var dbBrother = await _context.Sourabhs.FindAsync(id);
            if (dbBrother == null)
                return BadRequest("Brother not found");
            _context.Sourabhs.Remove(dbBrother);
            await _context.SaveChangesAsync();
            return Ok(await _context.Sourabhs.ToListAsync());
        }
    }
}

using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScheduleMasterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        IAddressService _addressService;
        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: api/<AddressesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var addresses = await _addressService.GetAllAsync();
            if(addresses == null)
                return NotFound();
            return Ok(addresses);
        }

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var address =  await _addressService.GetByIdAsync(id);
            if(address != null)
                return Ok(address);
            return NoContent();
        }

        // POST api/<AddressesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Address address)
        {
            var id = await _addressService.AddAsync(address);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Address address)
        {
            var updatedAddress = await _addressService.UpdateAsync(id, address);
            if(updatedAddress == null)
                return BadRequest();
            return Ok(updatedAddress);
        }
    }
}

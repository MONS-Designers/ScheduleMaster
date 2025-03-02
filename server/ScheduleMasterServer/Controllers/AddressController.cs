using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScheduleMasterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var addresses = await _addressService.GetAllAsync();
            if(addresses == null)
                return NotFound();
            return Ok(addresses);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var address =  await _addressService.GetByIdAsync(id);
            if(address != null)
                return Ok(address);
            return NoContent();
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Address address)
        {
            var id = await _addressService.AddAsync(address);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        // PUT api/<AddressController>/5
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

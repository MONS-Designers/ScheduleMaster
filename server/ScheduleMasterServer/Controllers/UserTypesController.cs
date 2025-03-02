using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Services;

namespace ScheduleMasterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypeService _service;

        public UserTypesController(IUserTypeService userTypeService)
        {
            _service = userTypeService;
        }

        // GET: api/UserTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> Get()
        {
            var userTypes = await _service.GetAllAsync();
            if(userTypes == null)
                return NotFound();
            return Ok(userTypes);
        }

        // GET: api/UserTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserType>> Get(int id)
        {
            var userType = await _service.GetByIdAsync(id);

            if (userType == null)
            {
                return NotFound();
            }

            return Ok(userType);
        }

        // PUT: api/UserTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserType userType)
        {
            if (id != userType.Id)
            {
                return BadRequest();
            }

            var updatedUserType = await _service.UpdateAsync(id, userType);
            if(updatedUserType == null)
                return BadRequest();
            return Ok(updatedUserType);
        }

        // POST: api/UserTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserType>> Post(UserType userType)
        {
            var id = _service.AddAsync(userType);
            return CreatedAtAction("Get", new { id }, id);
        }
    }
}

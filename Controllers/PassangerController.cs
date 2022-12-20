using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using PassengerApi.DataContext;
using PassengerApi.Models;
using PassengerApi.Models.Dtos;
using PassengerApi.Repository;
using PassengerApi.Repository.IRepository;
using System.Collections.Generic;

namespace PassengerApi.Controllers
{
    [Route("api/Passenger")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository _repo;
       // private readonly PassengerDbContext _context;
        private readonly IMapper _mapper;
        public PassengerController(IPassengerRepository repo, IMapper mapper)
        {
            // _context = context;
            _repo = repo;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PassengerDto>>> GetAllPassengers()
        {
            IEnumerable<Passenger> passengerList = await _repo.GetAllAsync();
            return Ok(passengerList);

        }

        [HttpGet("{id:int}", Name = "GetPassenger")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async  Task<ActionResult<PassengerDto>> GetPassengerById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var passenger = await  _repo.GetByIdAsync(x => x.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PassengerDto>(passenger));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<PassengerCreateDto>> CreatePassenger([FromBody]PassengerCreateDto createDto)
        {
            if (await _repo.GetByIdAsync(u => u.Name.ToLower() == createDto.Name.ToLower()) !=null) 
            {
                ModelState.AddModelError("Custom Error", "Passenger is already exists");
                return BadRequest();
            }
            Passenger model = _mapper.Map<Passenger>(createDto);
           
           await _repo.CreateAsync(model);
            return CreatedAtRoute("GetPassenger", new {id = model.Id}, model);

        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var passenger = await _repo.GetByIdAsync(u => u.Id == id);
            if(passenger==null)
            {
                return NotFound();
            }
           await  _repo.RemoveAsync(passenger);
            
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePassenger(int id, [FromBody] PassengerUpdateDto updateDto)
        {
            if(updateDto==null || id != updateDto.Id)
            {
                return BadRequest();
            }
            Passenger model = _mapper.Map<Passenger>(updateDto);
            
            await _repo.UpdateAsync(model);
            
            return NoContent();
        }
}

}

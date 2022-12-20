using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using PassangerApi.DataContext;
using PassangerApi.Models;
using PassangerApi.Models.Dtos;
using PassangerApi.Repository;
using PassangerApi.Repository.IRepository;
using System.Collections.Generic;

namespace PassangerApi.Controllers
{
    [Route("api/Passanger")]
    [ApiController]
    public class PassangerController : ControllerBase
    {
        private readonly IPassangerRepository _repo;
       // private readonly PassangerDbContext _context;
        private readonly IMapper _mapper;
        public PassangerController(IPassangerRepository repo, IMapper mapper)
        {
            // _context = context;
            _repo = repo;
            _mapper = mapper;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PassangerDto>>> GetAllPassangers()
        {
            IEnumerable<Passanger> passangerList = await _repo.GetAllAsync();
            return Ok(passangerList);

        }

        [HttpGet("{id:int}", Name = "GetPassanger")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async  Task<ActionResult<PassangerDto>> GetPassangerById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var passanger = await  _repo.GetByIdAsync(x => x.Id == id);
            if (passanger == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PassangerDto>(passanger));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<PassangerCreateDto>> CreatePassanger([FromBody]PassangerCreateDto createDto)
        {
            if (await _repo.GetByIdAsync(u => u.Name.ToLower() == createDto.Name.ToLower()) !=null) 
            {
                ModelState.AddModelError("Custom Error", "Passanger is already exists");
                return BadRequest();
            }
            Passanger model = _mapper.Map<Passanger>(createDto);
           
           await _repo.CreateAsync(model);
            return CreatedAtRoute("GetPassanger", new {id = model.Id}, model);

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
            var passanger = await _repo.GetByIdAsync(u => u.Id == id);
            if(passanger==null)
            {
                return NotFound();
            }
           await  _repo.RemoveAsync(passanger);
            
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePassanger(int id, [FromBody] PassangerUpdateDto updateDto)
        {
            if(updateDto==null || id != updateDto.Id)
            {
                return BadRequest();
            }
            Passanger model = _mapper.Map<Passanger>(updateDto);
            
            await _repo.UpdateAsync(model);
            
            return NoContent();
        }
}

}

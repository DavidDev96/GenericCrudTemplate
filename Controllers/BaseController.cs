using GenericCRUDTemplate.MW.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericCRUDTemplate.MW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity, TCreationDTO, TUpdateDTO, TInfoDTO> : ControllerBase
    {
        protected readonly IEntityLogic<TEntity, TCreationDTO, TUpdateDTO, TInfoDTO> _entityLogic;

        public BaseController(IEntityLogic<TEntity, TCreationDTO, TUpdateDTO, TInfoDTO> entityLogic)
        {
            _entityLogic = entityLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<TInfoDTO> result = await _entityLogic.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            TInfoDTO? result = await _entityLogic.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCreationDTO creationDTO)
        {
            if (creationDTO == null)
            {
                return BadRequest();
            }

            TInfoDTO result = await _entityLogic.Create(creationDTO);
            return CreatedAtAction(nameof(GetById), result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TUpdateDTO updateDTO)
        {
            bool entityExists = await _entityLogic.Exists(id);
            if (!entityExists)
            {
                return NotFound();
            }

            TInfoDTO updatedEntity = await _entityLogic.Update(id, updateDTO);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool entityExists = await _entityLogic.Exists(id);
            if (!entityExists)
            {
                return NotFound();
            }

            await _entityLogic.Delete(id);
            return NoContent();
        }
    }
}
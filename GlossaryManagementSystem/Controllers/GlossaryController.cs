using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlossaryManagementSystem.DTOs;
using GlossaryManagementSystem.DTOs.GlossaryItem;
using GlossaryManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlossaryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/glossary")]
    public class GlossaryController : ControllerBase
    {
        private readonly IGlossaryService _glossaryService;

        public GlossaryController(IGlossaryService glossaryService)
        {
            _glossaryService = glossaryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams pagination)
            => Ok(await _glossaryService.GetAll(pagination));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var item = await _glossaryService.GetById(id);
            return item is null ? NotFound("Item does not found.") : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGlossaryItemDTO dto)
        {
            try
            {
                var created = await _glossaryService.Add(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGlossaryItemDTO dto)
        {
            var updated = await _glossaryService.Update(id, dto);
            return updated is null ? NotFound("The item doesn't exist.") : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _glossaryService.Delete(id);
            return deleted is null ? NotFound() : NoContent();
        }
    }
}
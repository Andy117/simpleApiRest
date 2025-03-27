using Microsoft.AspNetCore.Mvc;
using SimpleApi.Services;
using SimpleApi.Models;
using System.Collections.Generic;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_itemService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _itemService.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Item newItem)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdItem = _itemService.Create(newItem);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Item updatedItem)
        {
            if (_itemService.Update(id, updatedItem)) return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_itemService.Delete(id)) return NoContent();
            return NotFound();
        }
    }
}

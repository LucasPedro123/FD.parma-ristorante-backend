using RestaurantAPI.Models;
using FD.ParmaRistorante.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FD.ParmaRistorante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly CardapioService _service;

        public CardapioController(CardapioService service)
        {
            _service = service;
        }

        //todos os usuários podem consultar
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        //apenas o admin pode criar, atualizar e deletar
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Cardapio cardapio)
        {
            return Ok(await _service.CreateAsync(cardapio));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, Cardapio model)
        {
            model.Id = id;
            var updated = await _service.UpdateAsync(model);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return !result ? NotFound() : Ok();
        }
    }
}

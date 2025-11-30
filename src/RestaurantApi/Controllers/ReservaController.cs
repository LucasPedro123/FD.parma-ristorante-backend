using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using RestaurantAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly RestaurantContext _context;
        private readonly ReservaService _service;

        public ReservaController(RestaurantContext context, ReservaService service)
        {
            _context = context;
            _service = service;
        }

        //admin functions
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reserva reserva)
        {
            var result = await _service.CreateAsync(reserva);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? Ok() : NotFound();
        }

        //view users
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaResponse>>> Get()
        {
            var reservas = await _service.GetAllAsync();

            return Ok(reservas.Select(r => new ReservaResponse
            {
                Id = r.Id,
                Nome = r.Nome,
                Telefone = r.Telefone,
                QuantidadePessoas = r.QuantidadePessoas,
                DataReserva = r.DataReserva,
                Observacoes = r.Observacoes
            }));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaResponse>> GetById(int id)
        {
            var reserva = await _service.GetByIdAsync(id);

            if (reserva == null)
                return NotFound();

            return Ok(new ReservaResponse
            {
                Id = reserva.Id,
                Nome = reserva.Nome,
                Telefone = reserva.Telefone,
                QuantidadePessoas = reserva.QuantidadePessoas,
                DataReserva = reserva.DataReserva,
                Observacoes = reserva.Observacoes
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ReservaRequest request)
        {
            var reserva = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = reserva.Id }, reserva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ReservaRequest request)
        {
            var updated = await _service.UpdateAsync(id, request);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}

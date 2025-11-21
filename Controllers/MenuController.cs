using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using RestaurantAPI.DTOs;
using RestaurantAPI.Repositories;
using System.IO;
using System;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _service;
        private readonly IWebHostEnvironment _env;
        private readonly IMenuRepository _menuRepository;

        public MenuController(MenuService service, IWebHostEnvironment env, IMenuRepository menuRepository)
        {
            _service = service;
            _env = env;
            _menuRepository = menuRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);

            if (item == null)
                return NotFound(new { message = "Item não encontrado no cardápio." });

            return Ok(item);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] CreateMenuItemDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return BadRequest(new { message = "O nome do alimento é obrigatório." });

                if (dto.Price <= 0)
                    return BadRequest(new { message = "O preço deve ser maior que zero." });

                string? imagePath = null;

                if (dto.Image != null)
                {
                    string folder = Path.Combine(_env.WebRootPath, "menu-images");

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
                    string fullPath = Path.Combine(folder, fileName);

                    await using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await dto.Image.CopyToAsync(stream);
                    }

                    imagePath = $"/menu-images/{fileName}";
                }


                var item = new MenuItem
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    ImageUrl = imagePath
                };

                var savedItem = await _menuRepository.CreateAsync(item);

                return CreatedAtAction(nameof(GetById), new { id = savedItem.Id }, savedItem);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(403, new { message = "Acesso negado. Você não possui permissão para criar itens do cardápio." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao criar item.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] MenuItem model)
        {
            try
            {
                var existing = await _service.GetByIdAsync(id);

                if (existing == null)
                    return NotFound(new { message = "Item não encontrado para atualização." });

                if (model.Price <= 0)
                    return BadRequest(new { message = "O preço deve ser maior que zero." });

                existing.Name = model.Name;
                existing.Description = model.Description;
                existing.Price = model.Price;
                existing.ImageUrl = model.ImageUrl;

                await _service.UpdateAsync(existing);
                return Ok(existing);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(403, new { message = "Acesso negado. Apenas administradores podem atualizar o cardápio." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao atualizar item.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _service.GetByIdAsync(id);

                if (item == null)
                    return NotFound(new { message = "Item não encontrado para exclusão." });

                await _service.DeleteAsync(id);
                return Ok(new { message = "Item deletado com sucesso." });
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(403, new { message = "Acesso negado. Apenas administradores podem deletar itens do cardápio." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao deletar item.", error = ex.Message });
            }
        }
    }
}

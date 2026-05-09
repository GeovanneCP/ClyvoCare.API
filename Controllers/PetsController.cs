using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClyvoCare.API.Models;
using ClyvoCare.API.Data;
using ClyvoCare.API.DTOs;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PetsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> GetPet()
    {
        return await _context.Pets.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetPet(int id)
    {
        var pet = await _context.Pets.FindAsync(id);
        return pet == null ? NotFound() : pet;
    }

    [HttpGet("especie/{especie}")]
    public async Task<ActionResult<IEnumerable<Pet>>> GetPorEspecie(string especie)
    {
        return await _context.Pets
            .Where(p => p.Especie.ToLower() == especie.ToLower())
            .ToListAsync();
    }

    [HttpGet("tutor/{usuarioId}")]
    public async Task<ActionResult<IEnumerable<Pet>>> GetPorTutor(int usuarioId)
    {
        return await _context.Pets
            .Where(p => p.UsuarioId == usuarioId)
            .ToListAsync();
    }

    [HttpGet("busca/{nome}")]
    public async Task<ActionResult<IEnumerable<Pet>>> GetPorNome(string nome)
    {
        return await _context.Pets
            .Where(p => p.Nome.Contains(nome))
            .ToListAsync();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPet(int id, Pet pet)
    {
        if (id != pet.Id) return BadRequest();

        _context.Entry(pet).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PetExists(id)) return NotFound();
            else throw;
        }
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Pet>> PostPet(PetCreateDTO petDto)
    {
        var pet = new Pet
        {
            Nome = petDto.Nome,
            Especie = petDto.Especie,
            DataNascimento = petDto.DataNascimento,
            UsuarioId = petDto.UsuarioId
        };

        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
        var pet = await _context.Pets.FindAsync(id);
        if (pet == null) return NotFound();

        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool PetExists(int id)
    {
        return _context.Pets.Any(e => e.Id == id);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClyvoCare.API.Models;
using ClyvoCare.API.Data;
using ClyvoCare.API.DTOs;

[Route("api/[controller]")]
[ApiController]
public class LogsSaudeController : ControllerBase
{
    private readonly AppDbContext _context;

    public LogsSaudeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LogSaude>>> GetLogSaude()
    {
        return await _context.LogsSaude.ToListAsync();
    }

    [HttpGet("pet/{petId}")]
    public async Task<ActionResult<IEnumerable<LogSaude>>> GetLogsPorPet(int petId)
    {
        return await _context.LogsSaude
            .Where(l => l.PetId == petId)
            .OrderByDescending(l => l.DataHora)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<LogSaude>> PostLogSaude(LogSaudeCreateDTO dto)
    {
        var log = new LogSaude
        {
            Peso = dto.Peso,
            Temperatura = dto.Temperatura,
            BatimentosCardiacos = dto.BatimentosCardiacos,
            Observacoes = dto.Observacoes,
            PetId = dto.PetId,
            DataHora = DateTime.Now
        };

        _context.LogsSaude.Add(log);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLogSaude), new { id = log.Id }, log);
    }
}
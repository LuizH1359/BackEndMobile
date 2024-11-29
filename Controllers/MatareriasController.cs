using BackEndMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MateriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Materias.ToListAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]

        public async Task <ActionResult> GetById(int id)
        {
            var model = await _context.Materias.FindAsync(id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPost]

        public async Task<ActionResult> CadastroMateria(Materia materia)
        {
            var novaMateria = new Materia
            {
                Nome = materia.Nome,
                NotaPeriodoLetivo = materia.NotaPeriodoLetivo

            };
            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();

            return StatusCode(201, novaMateria);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> AtualizarMateria(int id, Materia materia)
        {
            if (id != materia.Id) return BadRequest("Id da Matéria não encontrado.");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var materiaDb = await _context.Materias.FindAsync(id);

            if (materiaDb == null) return NotFound("Materia não encontrada");

            materiaDb.Nome = materia.Nome;
            materiaDb.NotaPeriodoLetivo = materia.NotaPeriodoLetivo;

            _context.Materias.Update(materiaDb);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task <ActionResult> Excluir(int id)
        {
            var model = await _context.Materias.FindAsync(id);

            if (model == null) return NotFound("Matéria não encontrada.");

            _context.Materias.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

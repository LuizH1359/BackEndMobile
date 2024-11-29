using BackEndMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndMobile.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotasController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task <ActionResult> GetAll()
        {
            var model = await _context.Notas.ToListAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]

        public async Task <ActionResult> GetById( int id)
        {
           
            var model = await _context.Notas.FindAsync(id);
            if (id == null) return NotFound("Nota não encontrada pelo Id");
                return Ok(model);   
        }

        [HttpPost]

        public async Task <ActionResult> CadastrarNota(Nota nota)
        {
            var novaNota = new Nota
            {
                Resultado = nota.Resultado
            };

            _context.Notas.Add(novaNota);
            await _context.SaveChangesAsync();
            return Ok(novaNota);

        }

        [HttpPut("{id}")]
        public async Task <ActionResult> AtualizarNota(Nota nota, int id)
        {
            if (id != nota.Id) return BadRequest("Nota não encontrada");

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var notaDb = await _context.Notas.FindAsync(nota.Id);

            if(notaDb == null) return NotFound("Nota não encontrada.");

            notaDb.Resultado = nota.Resultado;

            _context.Notas.Update(notaDb);
            await _context.SaveChangesAsync();

            return Ok(notaDb);


        }

        [HttpDelete]

        public async Task <ActionResult> ExcluirNota(int id)
        {
            var model = await _context.Notas.FindAsync(id);
            if (model == null) return NotFound("Nota não encontrada");

            _context.Notas.Remove(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }
       

    }
}

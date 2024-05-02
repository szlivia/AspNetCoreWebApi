using System.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController :ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{Id}")]
        public IActionResult GetById(int id)
        {
            var prof = _context.Professores.FirstOrDefault(a => a.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");

            return Ok(prof);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var prof = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if(prof == null) return BadRequest("Professor não encontrado");

            return Ok(prof);
        }

        [HttpPost]
        public IActionResult Post (Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{Id}")]
        public IActionResult Put (int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{Id}")]
        public IActionResult Patch (int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault( a => a.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");
            
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete (int id)
        {
            var prof = _context.Professores.FirstOrDefault(a => a.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");

            _context.Remove(prof);
            _context.SaveChanges();
            return Ok();
        }
    }
}
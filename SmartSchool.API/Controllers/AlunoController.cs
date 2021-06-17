using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSchool.API.Models;
using SmartSchool.API.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        //Para chamar a classe do context
        private readonly SmartContext _context;

        //Utiliza a classe aluno do contexto
        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // Get: api/aluno/byId?id={id} = Antigo
        // Get: api/aluno/byId/{id} = atual
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) 
                return BadRequest("O Aluno não foi encontrado");
            
            
            return Ok(aluno);
        }

        // Get: api/aluno/{nome} = Antigo
        //Get: api/aluno/ByName?nome={nome}&sobrenome={sobrenome}
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            //var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));
            //if (aluno == null)
            //    return BadRequest("O Aluno não foi encontrado");

            var aluno = _context.Alunos.FirstOrDefault(a =>
                //a.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase) && a.Sobrenome.Contains(sobrenome, StringComparison.OrdinalIgnoreCase)
                a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
            );

            return Ok(aluno);
        }

        // api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);

        }

        // utilizado para atualizar um registro
        // api/aluno
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null)
            {
                return BadRequest("Aluno não encontrado");
            }

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);

        }

        // utilizado para atualizar um registro parcialmente
        // api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null)
            {
                return BadRequest("Aluno não encontrado");
            }

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);

        }

        // utilizado para deletar um registro
        // api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();

        }


    }
}


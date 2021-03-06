using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        //private readonly SmartContext _context;
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            //_context = context;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorByID(id, false);
            if (professor == null)
                return BadRequest("O Professor não foi encontrado");


            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorByID(id, false);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorByID(id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorByID(id);
            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado");
            }

            return BadRequest("Professor não deletado");
        }

    }
}

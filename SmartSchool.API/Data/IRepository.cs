using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //ALUNOS
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaID(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoByID(int alunoId, bool includeProfessor = false);

        //PROFESSORES
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaID(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorByID(int professorId, bool includeProfessor = false);

    }
}

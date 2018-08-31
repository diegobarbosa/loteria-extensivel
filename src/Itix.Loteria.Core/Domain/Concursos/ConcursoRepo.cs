using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Concursos
{
    public interface IConcursoRepo
    {
        Concurso Ativo(int idJogo);
        
    }

    public class ConcursoRepo : IConcursoRepo
    {
        List<Concurso> concursos = new List<Concurso>();

        public Concurso Ativo(int idJogo)
        {
            return new Concurso
            {
                IdConcurso = 1,
                Codigo = 1000,
                IdJogo = 1,
                Status = EnumStatusConcurso.ABT
            };

        }
    }
}

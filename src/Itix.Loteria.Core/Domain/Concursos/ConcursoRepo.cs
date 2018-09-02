using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Loteria.Core.Domain.Concursos
{
    public interface IConcursoRepo
    {
        Concurso AtivoByIdJogo(int idJogo);

        Concurso AtivoByIdConcurso(int idConcurso);

    }

    public class ConcursoRepo : IConcursoRepo
    {
        List<Concurso> concursos = new List<Concurso>();

        public ConcursoRepo()
        {
            concursos.Add(new Concurso
            {
                IdConcurso = 1,
                Codigo = 1000,
                IdJogo = 1,
                Status = EnumStatusConcurso.ABT
            });
        }

        public Concurso AtivoByIdConcurso(int idConcurso)
        {
            return concursos
                 .SingleOrDefault(x =>
                    x.IdConcurso == idConcurso
                 && x.Status == EnumStatusConcurso.ABT
                 );
        }

        public Concurso AtivoByIdJogo(int idJogo)
        {

            return concursos[0];
        }
    }
}

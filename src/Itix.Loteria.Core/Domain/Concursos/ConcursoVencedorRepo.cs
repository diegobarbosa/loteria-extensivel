using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Loteria.Core.Domain.Concursos
{
    public interface IConcursoVencedorRepo
    {
        ConcursoVencedor GetByIdVencedor(int idVencedor);

        List<ConcursoVencedor> GetByIdConcurso(int idConcurso);
    }

    public class ConcursoVencedorRepo : IConcursoVencedorRepo
    {
        List<ConcursoVencedor> vencedores = new List<ConcursoVencedor>();

        public void Insert(ConcursoVencedor vencedor)
        {
            vencedores.Add(vencedor);
        }

        public ConcursoVencedor GetByIdVencedor(int idVencedor)
        {
            return vencedores
                .SingleOrDefault(x => x.IdConcursoVencedor == idVencedor);
        }

        public List<ConcursoVencedor> GetByIdConcurso(int idConcurso)
        {
            return vencedores
                .Where(x => x.IdConcurso == idConcurso)
                .ToList();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Loteria.Core.Domain.Concursos
{
    public interface IConcursoVencedorRepo
    {
        VencedorDoConcurso GetByIdVencedor(int idVencedor);

        List<VencedorDoConcurso> GetByIdConcurso(int idConcurso);
    }

    public class VencedorDoConcursoRepo : IConcursoVencedorRepo
    {
        List<VencedorDoConcurso> vencedores = new List<VencedorDoConcurso>();

        public void Insert(VencedorDoConcurso vencedor)
        {
            vencedores.Add(vencedor);
        }

        public VencedorDoConcurso GetByIdVencedor(int idVencedor)
        {
            return vencedores
                .SingleOrDefault(x => x.IdVencedor == idVencedor);
        }

        public List<VencedorDoConcurso> GetByIdConcurso(int idConcurso)
        {
            return vencedores
                .Where(x => x.IdConcurso == idConcurso)
                .ToList();
        }

    }
}

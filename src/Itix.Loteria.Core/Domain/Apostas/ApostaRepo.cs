using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Loteria.Core.Domain.Apostas
{
    public interface IApostaRepo
    {
        void Insert(Aposta aposta);

        Aposta ByIdAposta(int idAposta);

        List<Aposta> ByIdConcurso(int idConcurso);

        List<Aposta> VencedoresByIdConcurso(int idConcurso);
    }

    public class ApostaRepo : IApostaRepo
    {
        public static List<Aposta> Apostas = new List<Aposta>();

        public List<Aposta> GetTodos()
        {
            return Apostas;
        }

        public void Insert(Aposta aposta)
        {
            Apostas.Add(aposta);
        }

        public Aposta ByIdAposta(int idAposta)
        {
            return Apostas
                .SingleOrDefault(x => x.IdAposta == idAposta);
        }

        public List<Aposta> ByIdConcurso(int idConcurso)
        {
            return Apostas
                .Where(x => x.IdConcurso == idConcurso)
                .ToList();
        }

        public List<Aposta> VencedoresByIdConcurso(int idConcurso)
        {
            return (from aposta in ApostaRepo.Apostas
                    where
                       aposta.IdConcurso == idConcurso
                    && aposta.AcertoStatus == StatusAcerto.VENC

                    select aposta)

                    .ToList();
        }
    }

}

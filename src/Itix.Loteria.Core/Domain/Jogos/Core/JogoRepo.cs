using Itix.Loteria.Core.Domain.Jogos.MegaSena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos.Core
{
    public interface IJogoRepo
    {
        List<IJogo> GetTodos();

        List<IJogo> GetAtivos();

        IJogo GetByCodigo(string codigoJogo);

        IJogo GetByIdJogo(int idJogo);
    }

    public class JogoRepo : IJogoRepo
    {
        List<IJogo> jogos = new List<IJogo>();

        public JogoRepo()
        {
            jogos.AddRange(new List<IJogo> {
                new MegaSenaJogo()
            });

        }

        public List<IJogo> GetTodos()
        {
            return jogos;
        }

        public List<IJogo> GetAtivos()
        {
            return jogos
                .Where(x => x.Status == JogoTipoStatus.ATV)
                .ToList();
        }

        public IJogo GetByCodigo(string codigoJogo)
        {
            return jogos
                .SingleOrDefault(x => x.CodigoJogo == codigoJogo);
        }

        public IJogo GetByIdJogo(int idJogo)
        {
            return jogos
               .SingleOrDefault(x => x.IdJogo == idJogo);
        }
    }

}

using Itix.Loteria.Core.Domain.Jogos;
using Itix.Loteria.Core.Domain.Jogos.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.Loteria.UI.Controllers
{
    [Route("api/[controller]")]
    public class JogosController : Controller
    {
        IJogoRepo jogoRepo;

        public JogosController(IJogoRepo jogoRepo)
        {
            this.jogoRepo = jogoRepo;
        }

        [HttpGet]
        public IEnumerable<IJogo> Index()
        {
            return jogoRepo.GetAtivos();
        }

        [HttpGet("{codigoJogo}")]
        public IJogo Get(string codigoJogo)
        {
            return jogoRepo.GetByCodigo(codigoJogo);
        }
    }
}

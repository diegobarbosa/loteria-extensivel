using Itix.Loteria.Core.Domain.Apostas;
using Itix.Loteria.Core.Domain.Concursos;
using Itix.Loteria.Core.Domain.Servicos;
using Itix.Loteria.Core.Domain.Servicos.ProcessarConcursos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itix.Loteria.UI.Controllers
{
    [Route("api/[controller]")]
    public class ConcursosController : Controller
    {
        IConcursoRepo concursoRepo;

        IFinalizarApostasService finalizarApostasService;

        IProcessarConcursoService processarConcursoService;

        IApostaRepo apostaRepo;

        public ConcursosController(
            IConcursoRepo concursoRepo,
            IFinalizarApostasService finalizarApostasService,
            IProcessarConcursoService processarConcursoService,
            IApostaRepo apostaRepo
            )
        {
            this.concursoRepo = concursoRepo;

            this.finalizarApostasService = finalizarApostasService;

            this.processarConcursoService = processarConcursoService;

            this.apostaRepo = apostaRepo;
        }

        [HttpPost("{idConcurso}/apostar")]
        public ActionResult Apostar(int idConcurso, [FromBody] FinalizarApostasService.Command command)
        {
            command.IdConcurso = idConcurso;

            finalizarApostasService.Executar(command);

            return Ok();
        }


        [HttpPost("{idConcurso}/processar")]
        public ActionResult Processar(int idConcurso)
        {
            processarConcursoService.Executar(idConcurso);

            return Ok();
        }

        [HttpGet("{idConcurso}/vencedores")]
        public IEnumerable<Aposta> Vencedores(int idConcurso)
        {
            return apostaRepo.VencedoresByIdConcurso(idConcurso);
        }


    }
}

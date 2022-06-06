using CondominioDevAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CondominioDevAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioFinanceiroController : ControllerBase
    {
        private readonly RelatorioFinanceiroAppService _relatorioFinanceiroAppService;

        public RelatorioFinanceiroController(RelatorioFinanceiroAppService relatorioFinanceiroAppService)
        {
            _relatorioFinanceiroAppService = relatorioFinanceiroAppService;
        }

        /// <summary>
        /// Retorna o morador com maior custo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("maior-custo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult MoradorMaiorCusto()
        {
            var morador = _relatorioFinanceiroAppService.GetMaiorCusto();
            if (morador == null) return NotFound();
            return Ok(morador);
        }

        /// <summary>
        /// Retorna a somatória da renda de todos os habitantes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("gasto-total")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GastoTotal()
        {
            var gastoTotal = _relatorioFinanceiroAppService.GetGastoTotal();
            return Ok(gastoTotal);
        }

        /// <summary>
        /// Retorna o orçamento do condomínio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("orcamento-condominio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult OrcamentoCondominio()
        {
            var orcamentoCondominio = _relatorioFinanceiroAppService.OrcamentoCondominio();
            return Ok($"O orçamento atual do condomínio é de R$ {orcamentoCondominio} por habitante. Esse valor inclui o valor do condomínio e a conta de luz!");
        }

        /// <summary>
        /// Retorna a diferença entre o orçamento e o gasto do condomínio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("orcamento-gasto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult DiferencaOrcamentoEGasto()
        {
            return Ok(_relatorioFinanceiroAppService.DiferencaOrcamentoEGasto());
        }

    }
}

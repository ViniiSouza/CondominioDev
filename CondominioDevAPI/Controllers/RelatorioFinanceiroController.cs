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

        [HttpGet]
        [Route("maior-custo")]
        public ActionResult MoradorMaiorCusto()
        {
            var morador = _relatorioFinanceiroAppService.GetMaiorCusto();
            if (morador == null) return NotFound();
            return Ok(morador);
        }

        [HttpGet]
        [Route("gasto-total")]
        public ActionResult GastoTotal()
        {
            var gastoTotal = _relatorioFinanceiroAppService.GetGastoTotal();
            return Ok(gastoTotal);
        }

        [HttpGet]
        [Route("orcamento-condominio")]
        public ActionResult OrcamentoCondominio()
        {
            var orcamentoCondominio = _relatorioFinanceiroAppService.OrcamentoCondominio();
            return Ok($"O orçamento atual do condomínio é de R$ {orcamentoCondominio} por habitante. Esse valor inclui o valor do condomínio e a conta de luz!");
        }

        [HttpGet]
        [Route("orcamento-gasto")]
        public ActionResult DiferencaOrcamentoEGasto()
        {
            return Ok(_relatorioFinanceiroAppService.DiferencaOrcamentoEGasto());
        }

    }
}

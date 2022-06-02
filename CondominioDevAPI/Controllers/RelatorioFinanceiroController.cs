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
        
    }
}

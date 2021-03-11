using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokerApi.Business.Interfaces.Service;
using PokerApi.Model.Dto.Financial;

namespace PokerApi.Controllers
{
    /// <summary>
    /// FinancialController - Financeiros
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        private readonly IFinancialBusiness _business;

        /// <summary>
        /// Constructor
        /// </summary>
        public FinancialController(IFinancialBusiness business)
        {
            _business = business;
        }

        /// <summary>
        /// GetFinancial - Busca a lista de financeiros do sistema
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetFinancial()
        {
            return Ok(await _business.GetAll());
        }

        /// <summary>
        /// GetFinancial - Busca um financeiro específico do sistema
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="placeId"></param>
        [HttpGet("{playerId:int}/{placeId:int}")]
        public async Task<ActionResult> GetFinancial(int playerId, int placeId)
        {
            var financial = await _business.GetById(playerId, placeId);

            if (financial == null)
            {
                return NotFound();
            }

            return Ok(financial);
        }

        /// <summary>
        /// PostFinancial - Envia um novo financeiro para o sistema
        /// </summary>
        /// <param name="financial"></param>
        [HttpPost]
        public async Task<ActionResult> PostFinancial(FinancialPostDto financial)
        {
            return Ok(await _business.Post(financial));
        }

        /// <summary>
        /// PutFinancial - Atualiza um financeiro do sistema
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="placeId"></param>
        /// <param name="financial"></param>
        [HttpPut("{playerId:int}/{placeId:int}")]
        public async Task<IActionResult> PutFinancial(int playerId, int placeId, FinancialPutDto financial)
        {
            if (playerId != financial.PlayerId || placeId != financial.PlaceId)
            {
                return BadRequest();
            }

            var oldFinancial = await _business.GetById(playerId, placeId);
            if (oldFinancial == null)
            {
                return NotFound();
            }

            await _business.Put(playerId, placeId, financial);
            return NoContent();
        }

        /// <summary>
        /// DeleteFinancial - Apaga um financeiro do sistema
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="placeId"></param>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFinancial(int playerId, int placeId)
        {
            var financial = await _business.GetById(playerId, placeId);
            if (financial == null)
            {
                return NotFound();
            }
            await _business.Delete(playerId, placeId);
            return NoContent();
        }
    }
}

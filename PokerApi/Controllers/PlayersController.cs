using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokerApi.Business.Interfaces.Service;
using PokerApi.Model.Dto.Player;

namespace PokerApi.Controllers
{
    /// <summary>
    /// PlayersController - Jogadores
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersBusiness _business;

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayersController(IPlayersBusiness business)
        {
            _business = business;
        }

        /// <summary>
        /// GetPlayers - Busca a lista de jogadores do sistema
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetPlayers()
        {
            return Ok(await _business.GetAll());
        }

        /// <summary>
        /// GetPlayer - Busca um jogador específico do sistema
        /// </summary>
        /// <param name="playerId"></param>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetPlayer(int playerId)
        {
            var player = await _business.GetById(playerId);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        /// <summary>
        /// PostPlayer - Envia um novo jogador para o sistema
        /// </summary>
        /// <param name="player"></param>
        [HttpPost]
        public async Task<ActionResult> PostPlayer(PlayerPostDto player)
        {
            return Ok(await _business.Post(player));
        }

        /// <summary>
        /// PutPlayer - Atualiza um jogador do sistema
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="player"></param>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPlayer(int playerId, PlayerPutDto player)
        {
            if (playerId != player.Id)
            {
                return BadRequest();
            }

            var oldPlayer = await _business.GetById(playerId);
            if (oldPlayer == null)
            {
                return NotFound();
            }
            
            await _business.Put(playerId, player);
            return NoContent();
        }

        /// <summary>
        /// DeletePlayer - Apaga um jogador do sistema
        /// </summary>
        /// <param name="playerId"></param>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _business.GetById(id);
            if (player == null)
            {
                return NotFound();
            }
            await _business.Delete(id);
            return NoContent();
        }
    }
}

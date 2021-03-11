using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokerApi.Business.Interfaces.Service;
using PokerApi.Model.Dto.Place;

namespace PokerApi.Controllers
{
    /// <summary>
    /// PlacesController - Lugares
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesBusiness _business;

        /// <summary>
        /// Constructor
        /// </summary>
        public PlacesController(IPlacesBusiness business)
        {
            _business = business;
        }

        /// <summary>
        /// GetPlaces - Busca a lista de lugares do sistema
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetPlaces()
        {
            return Ok(await _business.GetAll());
        }

        /// <summary>
        /// GetPlace - Busca um lugar específico do sistema
        /// </summary>
        /// <param name="placeId"></param>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetPlace(int placeId)
        {
            var place = await _business.GetById(placeId);

            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        /// <summary>
        /// PostPlace - Envia um novo lugar para o sistema
        /// </summary>
        /// <param name="place"></param>
        [HttpPost]
        public async Task<ActionResult> PostPlace(PlacePostDto place)
        {
            return Ok(await _business.Post(place));
        }

        /// <summary>
        /// PutPlace - Atualiza um lugar do sistema
        /// </summary>
        /// <param name="placeId"></param>
        /// <param name="place"></param>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPlace(int placeId, PlacePutDto place)
        {
            if (placeId != place.Id)
            {
                return BadRequest();
            }

            var oldPlace = await _business.GetById(placeId);
            if (oldPlace == null)
            {
                return NotFound();
            }

            await _business.Put(placeId, place);
            return NoContent();
        }

        /// <summary>
        /// DeletePlace - Apaga um lugar do sistema
        /// </summary>
        /// <param name="playerId"></param>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePlace(int id)
        {
            var place = await _business.GetById(id);
            if (place == null)
            {
                return NotFound();
            }
            await _business.Delete(id);
            return NoContent();
        }
    }
}

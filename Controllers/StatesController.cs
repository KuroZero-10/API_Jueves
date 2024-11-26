using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_Jueves_2024II.DAL.Entities;
using ShoppingAPI_Jueves_2024II.Domain.Interfaces;
using ShoppingAPI_Jueves_2024II.Domain.Servicios;

namespace ShoppingAPI_Jueves_2024II.Controllers
{
    [Route("api/statesController")]
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var states = await _stateService.GetStatesAsync();
            if (states == null || !states.Any()) return NotFound();

            return Ok(states);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByID/{id}")]// api/countries/get
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var states = await _stateService.GetStateByIdAsync(id);
            if (states == null) return NotFound();//404

            return Ok(states);//200
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(State state)
        {
            try
            {
                var newstate = await _stateService.CreateStateAsync(state);
                if (newstate == null) return NotFound();
                return Ok(newstate);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate")) return Conflict(String.Format("{0} ya existe", state.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(State state)
        {
            try
            {
                var editedCountry = await _stateService.UpdateStateAsync(state);
                if (editedCountry == null) return NotFound();
                return Ok(state);
            }
            catch (Exception e)
            {

                if (e.Message.Contains("duplicate")) return Conflict(String.Format("{0} ya existe", state.Name));

                return Conflict(e.Message);
            }
        }
        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedCountry = await _stateService.DeleteStateAsync(id);
            if (deletedCountry == null) return NotFound();
            return Ok(deletedCountry);
        }
    }
}

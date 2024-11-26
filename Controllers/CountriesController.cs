using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_Jueves_2024II.DAL.Entities;
using ShoppingAPI_Jueves_2024II.Domain.Interfaces;
using ShoppingAPI_Jueves_2024II.Domain.Servicios;

namespace ShoppingAPI_Jueves_2024II.Controllers
{
    [Route("api/[controller]")]//Este es el nombre inicial de mi RUTA, URL O PATH
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService; //Se hace la conexion a la interface
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();
            if (countries == null || !countries.Any()) return NotFound();

            return Ok(countries);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByID/{id}")]// api/countries/get
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var countries = await _countryService.GetCountryByIdAsync(id);
            if (countries == null) return NotFound();//404

            return Ok(countries);//200
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newcountry = await _countryService.CreateCountryAsync(country);
                if (newcountry == null) return NotFound();
                return Ok(newcountry);
            }
            catch (Exception ex)
            {

                if(ex.Message.Contains("duplicate")) return Conflict(String.Format("{0} ya existe", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry=await _countryService.EditCountryAsync(country);
                if(editedCountry == null) return NotFound();
                return Ok(country);
            }
            catch (Exception e)
            {

                if (e.Message.Contains("duplicate")) return Conflict(String.Format("{0} ya existe", country.Name));

                return Conflict(e.Message);
            }
        }
        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedCountry = await _countryService.DeleteCountryAsync(id);
            if (deletedCountry == null) return NotFound();
            return Ok(deletedCountry);
        }

    }
}

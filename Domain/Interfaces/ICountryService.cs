 using ShoppingAPI_Jueves_2024II.DAL.Entities;

namespace ShoppingAPI_Jueves_2024II.Domain.Interfaces
{
    public interface ICountryService
    {
        //get by id, get all, create, update, delete; son las operaciones principales, pueden haber mas...
        //Collections: IList  lista completa, ICollection listas no ordenables, IEnumerable lista estática, IQuerable lista lógica
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);
    }
}

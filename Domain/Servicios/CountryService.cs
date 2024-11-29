using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2024II.DAL;
using ShoppingAPI_Jueves_2024II.DAL.Entities;
using ShoppingAPI_Jueves_2024II.Domain.Interfaces;

namespace ShoppingAPI_Jueves_2024II.Domain.Servicios
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;
        
        public CountryService(DataBaseContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {
                return await _context.Countries.Include(s=>s.States).ToListAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                //Otras dos formas
                var country1 = await _context.Countries.FindAsync(id);
                var country2 = await _context.Countries.FirstAsync(c => c.Id == id);
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country); //Este metodo me permite crear el objetoen el contexto de mi BD
                await _context.SaveChangesAsync();//Este metodo permite guardar el pais en la tabla
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate= DateTime.Now;
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);
                if (country == null)
                {
                    return null;
                }
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        

        
    }
}

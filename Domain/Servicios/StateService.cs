using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2024II.DAL;
using ShoppingAPI_Jueves_2024II.DAL.Entities;
using ShoppingAPI_Jueves_2024II.Domain.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingAPI_Jueves_2024II.Domain.Servicios
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;
        public StateService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            try
            {
                var states = await _context.States.ToListAsync();
                return states;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> GetStateByIdAsync(Guid id)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(s => s.Id == id);
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> GetStateByNameAsync(string name)
        {
            try
            {
                var state= await _context.States.FirstOrDefaultAsync(s=> s.Name == name);
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                await _context.AddAsync(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> UpdateStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _context.Update(state);
                await _context.SaveChangesAsync();
                return state;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await GetStateByIdAsync(id);
                if (state == null) return null;
                _context.States.Remove(state);
                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}

using ShoppingAPI_Jueves_2024II.DAL.Entities;

namespace ShoppingAPI_Jueves_2024II.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesAsync();
        Task<State> GetStateByIdAsync(Guid id);
        Task<State> GetStateByNameAsync(string name);
        Task<State> CreateStateAsync(State state);
        Task<State> UpdateStateAsync(State state);
        Task<State> DeleteStateAsync(Guid id);

    }
}

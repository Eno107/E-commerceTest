using WebApplication1.Models;

namespace WebApplication1.Data.Services
{
	public interface IActorsService
	{
		Task<IEnumerable<Actor>> getAllAsync();

		Task<Actor> getByIdAsync(int id);

		Task AddAsync(Actor actor);

		Task<Actor> UpdateAsync(int id,  Actor actor);

		Task DeleteAsync(int id);
	}
}

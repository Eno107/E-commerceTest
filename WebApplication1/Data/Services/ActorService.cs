using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Services
{
	public class ActorService : IActorsService
	{

		private readonly AppDBContext _context;

		public ActorService(AppDBContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Actor actor)
		{
			await _context.Actors.AddAsync(actor);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var actor = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
			_context.Actors.Remove(actor);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Actor>> getAllAsync()
		{
			return await _context.Actors.ToListAsync();
		}

		public async Task<Actor> getByIdAsync(int id)
		{
			var actor = await _context.Actors.FirstOrDefaultAsync(n=> n.Id == id);
			return actor;
		}

		public async Task<Actor> UpdateAsync(int id, Actor newActor)
		{
			_context.Update(newActor);
			await _context.SaveChangesAsync();
			return newActor;
		}
	}
}

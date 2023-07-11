namespace WebApplication1.Data.Base
{
	public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
	{
		Task<IEnumerable<T>> getAllAsync();

		Task<T> getByIdAsync(int id);

		Task AddAsync(T entity);

		Task UpdateAsync(int id, T entity);

		Task DeleteAsync(int id);
	}
}

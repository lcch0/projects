namespace Storage.Interfaces
{
	public interface IDbSerializer
	{
		void LoadByContext<T>(object target, IRepositoryContext<T> context);
	}
}

using System;

namespace SQLAccessor.Interfaces
{
	public interface IRepositoryContext<out T> : IDisposable
	{
		T Connection { get; }
	}
}
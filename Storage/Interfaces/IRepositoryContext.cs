using System;

namespace Storage.Interfaces
{
	public interface IRepositoryContext<out T> : IDisposable
	{
		T Connection { get; }
	}
}
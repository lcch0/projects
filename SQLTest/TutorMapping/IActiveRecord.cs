using System.Collections.Generic;

namespace TutorMapping
{
	public interface IActiveRecord<T>
	{
		IEnumerable<T> GetRecord(int id, ISqliteContext context);
		int AddRecord(T record, ISqliteContext context);
	}
}
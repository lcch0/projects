using System.Collections.Generic;
using System.Linq;

namespace TutorMapping
{
	public class BaseActiveRecord<T> where T : class, IIdRecord, new()
	{
		public virtual IEnumerable<T> GetRecord(ISqliteContext context, int id = -1, int parentid = -1)
		{
			IEnumerable<T> sequence =
				id < 0
				? context.Connection.Table<T>()
				: context.Connection.Table<T>().Where(p => p.Id == id);

			if (parentid > -1)
				sequence = sequence.Where(p => p.ParentId == parentid);

			return sequence;
		}

		public virtual int AddRecord(ISqliteContext context)
		{
			int pid = -1;

			context.Connection.RunInTransaction(() =>
			{
				context.Connection.Insert(this);
				pid = context.Connection.ExecuteScalar<int>("SELECT last_insert_rowid()");
			});

			return pid;
		}

		public virtual int UpdateRecord(ISqliteContext context)
		{
			return context.Connection.Update(this);
		}

		public virtual int DeleteRecord(ISqliteContext context)
		{
			return context.Connection.Delete(this);
		}
	}
}

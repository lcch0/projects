using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LiteDB;
using Storage.Serializable;

namespace Storage.Serializers
{
    public class DbCollection<T> where T : new()
    {
        public IEnumerable<T> SqlCollection { get; set; }
        public LiteCollection<T> NoSqlCollection { get; set; }

        public IEnumerable<T> Collection
        {
            get
            {
                if (NoSqlCollection != null)
                    return NoSqlCollection.FindAll();

                return SqlCollection;
            }
        }

        public DbCollection(LiteCollection<T> noSqlCollection)
        {
            NoSqlCollection = noSqlCollection;
        }

        public DbCollection(List<T> sqlCollection)
        {
            SqlCollection = sqlCollection;
        }

        public DbCollection<T> Include<TK>(Expression<Func<T, TK>> dbref)
        {
            NoSqlCollection = NoSqlCollection?.Include(dbref);
            return this;
        }
    }
}

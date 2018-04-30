using System.Collections.Generic;
using System.Data.SQLite;
using Storage.Interfaces;
using Storage.Serializable;

namespace Storage.Serializers.SqlSpecific
{
    class UserSerializer : BaseSerializer
    {
        public UserSerializer(IDbSerializer s) :base(s)
        {
            
        }

        public int AddRecord(User user)
        {
            var strcmd = $"insert into {user.TableName}(name) values(@name)";

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                cmd.Parameters.AddWithValue("name", user.Name);
                user.Id = Serializer.Context.ExecuteNonQuery(cmd);
            }

            return user.Id;
        }

        public int DeleteRecord(User entity)
        {
            var strcmd = $"delete from {entity.TableName} where id = {entity.Id}";

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                Serializer.Context.ExecuteNonQuery(cmd);
            }

            return entity.Id;
        }

        public IEnumerable<User> GetRecords(int id)
        {
            var entity = new User();
            var strcmd = id > 0 
                ? $"select id, name from {entity.TableName} where id = {id}"
                : $"select id, name from {entity.TableName}";

            List<User> list = new List<User>();

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entity = new User
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };

                        list.Add(entity);
                    }
                }
            }

            return list;
        }

        public int UpdateRecord(User entity)
        {
            if (entity.Id < 1)
                return -1;

            var strcmd = $"update {entity.TableName} set name = @name where id = {entity.Id}";

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                cmd.Parameters.AddWithValue("name", entity.Name);
                entity.Id = Serializer.Context.ExecuteNonQuery(cmd);
            }

            return entity.Id;
        }

        public IEnumerable<User> GetRecords(string id)
        {
            var entity = new User();
            var strcmd = $"select id, name from {entity.TableName} where name = '{id}'";

            List<User> list = new List<User>();

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entity = new User
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };

                        list.Add(entity);
                    }
                }
            }

            return list;
        }
    }
}

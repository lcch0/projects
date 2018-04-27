using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Storage.Interfaces;
using Storage.Serializable;

namespace Storage.Serializers.SqlSpecific
{
    class ActivitySerializer : BaseSerializer
    {
        public ActivitySerializer(IDbSerializer s) : base(s){}

        public int AddRecord(Activity entity)
        {
            var strcmd = $"insert into {entity.TableName}(date, desc, days, projectid, userid) values(@date, @desc, @days, @projectid, @userid)";

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                cmd.Parameters.AddWithValue("date", entity.GetDate());
                cmd.Parameters.AddWithValue("desc", entity.Desc);
                cmd.Parameters.AddWithValue("days", entity.Days);
                cmd.Parameters.AddWithValue("projectid", entity.Project?.Id);
                cmd.Parameters.AddWithValue("userid", entity.User?.Id);

                entity.Id = Serializer.Context.ExecuteNonQuery(cmd);
            }

            return entity.Id;

        }

        public int DeleteRecord(Activity entity)
        {
            var strcmd = $"delete from {entity.TableName} where id = {entity.Id}";

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                Serializer.Context.ExecuteNonQuery(cmd);
            }

            return entity.Id;
        }

        public IEnumerable<Activity> GetRecords(int id)
        {
            var entity = new Activity();
            var strcmd = id > 0 
                ? $"select id, date, desc, days, projectid, userid from {entity.TableName} where id = {id}"
                : $"select id, date, desc, days, projectid, userid from {entity.TableName}";

            List<Activity> list = new List<Activity>();

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entity = new Activity();
                        entity.Id = reader.GetInt32(0);
                        entity.SetDate(reader.GetString(1));
                        entity.Desc = reader.GetString(2);
                        entity.Days = reader.GetInt32(3);
                        var projectId = reader.GetInt32(4);
                        var userId = reader.GetInt32(5);

                        entity.Project = Serializer.GetRecords<Project>(projectId).FirstOrDefault();
                        entity.User = Serializer.GetRecords<User>(userId).FirstOrDefault();

                        list.Add(entity);
                    }

                }
            }

            return list;
        }

        public int UpdateRecord(Activity entity)
        {
            if (entity.Id < 1)
                return -1;

            var strcmd = $"update {entity.TableName} set date = @date, desc = @desc, days = @days, projectid = @projectid, userid = @userid where id = {entity.Id}";

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                cmd.Parameters.AddWithValue("date", entity.GetDate());
                cmd.Parameters.AddWithValue("desc", entity.Desc);
                cmd.Parameters.AddWithValue("days", entity.Days);
                cmd.Parameters.AddWithValue("projectid", entity.Project?.Id);
                cmd.Parameters.AddWithValue("userid", entity.User?.Id);

                entity.Id = Serializer.Context.ExecuteNonQuery(cmd);
            }

            return entity.Id;
        }
    }
}

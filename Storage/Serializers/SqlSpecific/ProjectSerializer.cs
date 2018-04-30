using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Storage.Interfaces;
using Storage.Serializable;

namespace Storage.Serializers.SqlSpecific
{
    class ProjectSerializer : BaseSerializer
    {
        public ProjectSerializer(IDbSerializer s) : base(s)
        {

        }

        public int AddRecord(Project entity)
        {
            var strcmd = $"insert into {entity.TableName}(projecttype) values(@projecttype)";

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                cmd.Parameters.AddWithValue("projecttype", entity.ProjectType);
                entity.Id = Serializer.Context.ExecuteNonQuery(cmd);
            }

            return entity.Id;
        }

        public int DeleteRecord(Project entity)
        {
            var strcmd = $"delete from {entity.TableName} where id = {entity.Id}";

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                Serializer.Context.ExecuteNonQuery(cmd);
            }

            return entity.Id;
        }

        public IEnumerable<Project> GetRecords(int id)
        {
            var entity = new Project();
            var strcmd = id > 0 
                ? $"select id, projecttype from {entity.TableName} where id = {id}"
                : $"select id, projecttype from {entity.TableName}";

            List<Project> list = new List<Project>();

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entity = new Project
                        {
                            Id = reader.GetInt32(0),
                            ProjectType = reader.GetInt32(1)
                        };

                        list.Add(entity);
                    }
                }
            }

            return list;
        }

        public IEnumerable<Project> GetRecords(Project.EType type)
        {
            var entity = new Project();
            var strcmd = $"select id, projecttype from {entity.TableName} where projecttype = {(int)type}";
                

            List<Project> list = new List<Project>();

            using (SQLiteCommand cmd = new SQLiteCommand(strcmd, Serializer.Context.Connection as SQLiteConnection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entity = new Project
                        {
                            Id = reader.GetInt32(0),
                            ProjectType = reader.GetInt32(1)
                        };

                        list.Add(entity);
                    }
                }
            }

            return list;
        }

        public int UpdateRecord(Project entity)
        {
            return -1;
        }
    }
}

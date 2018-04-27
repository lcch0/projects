using Storage.Interfaces;

namespace Storage.Serializers
{
    public class SerializerFactory
    {
        private static bool _sql = true;

        public static IDbSerializer GetDbSerializer(string path)
        {
            if (!_sql)
                return new LiteDbSerializer(path);

            return new SqliteSerializer(path);
        }

    }
}

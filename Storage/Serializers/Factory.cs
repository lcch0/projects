using Storage.Interfaces;

namespace Storage.Serializers
{
    public class Factory
    {
        private static bool _sql = true;

        public static IDbSerializer GetDbSerializer(string path)
        {
            return new SqliteSerializer(path);
        }

    }
}

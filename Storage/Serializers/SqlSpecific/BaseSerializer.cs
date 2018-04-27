using Storage.Interfaces;

namespace Storage.Serializers.SqlSpecific
{
    abstract class BaseSerializer
    {
        protected readonly IDbSerializer Serializer;
        
        protected BaseSerializer(IDbSerializer s)
        {
            Serializer = s;
        }
    }
}

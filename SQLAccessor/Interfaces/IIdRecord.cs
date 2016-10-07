namespace SQLAccessor.Interfaces
{
	public interface IIdRecord
	{
		int Id { get; set; }
		string TableName { get; }
	}
}

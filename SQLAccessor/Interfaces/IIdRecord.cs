namespace SQLAccessor.Interfaces
{
	public interface IIdRecord
	{
		int Id { get; set; }
		int ParentId { get; set; }
	}
}

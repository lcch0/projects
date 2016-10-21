using Storage.Serializable;

namespace Logic.Models
{
    public class UserModel
    {
		public UserModel()
		{
		}

		public UserModel(User user)
		{
			Id = user.Id;
			Name = user?.Name ?? "No user";
		}

	    public int Id { get; set; }
		public string Name { get; set; }

	    public User GetStorageObject()
	    {
		    return new User
		    {
			    Id = Id,
				Name = Name
		    };
	    }
    }
}

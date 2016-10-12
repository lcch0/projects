using Storage.Serializable;

namespace Logic.Models
{
    public class UserModel
    {
		public UserModel(User user)
		{
			Name = user?.Name ?? "No user";
		}

		public string Name { get; set; }
	}
}

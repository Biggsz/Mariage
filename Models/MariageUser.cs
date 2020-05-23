using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Mariage.Models
{
	public class MariageUser : IdentityUser
	{
		public MariageUser(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public virtual Participation? Participation { get; set; }
	}
}
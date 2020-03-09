using Microsoft.AspNetCore.Identity;

namespace Mariage.Models
{
    public class MariageUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
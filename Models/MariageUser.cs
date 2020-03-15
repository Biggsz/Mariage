using Microsoft.AspNetCore.Identity;

namespace Mariage.Models
{
    public class MariageUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsInvitedToLunch { get; set; }
        public bool WillAttendLunch { get; set; }
        public bool WillAttendDinner { get; set; }
        public string PlusOne { get; set; }
    }
}
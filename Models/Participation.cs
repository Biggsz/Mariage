namespace Mariage.Models
{
    public class Participation
    {
        public Participation(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool CanBringChildren { get; set; } = false;
        public bool CanBringPlusOne { get; set; } = false;
        public bool CompletedForm { get; set; } = false;
        public bool IsInvitedToLunch { get; set; } = false;
        public bool WillAttendLunch { get; set; } = false;
        public bool WillAttendDinner { get; set; } = false;
        public Participation? PlusOne { get; set; }
    }
}
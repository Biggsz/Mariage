namespace Mariage.Models
{
    public class Participation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool CanBringChildren { get; set; }
        public bool CanBringPlusOne { get; set; }
        public bool CompletedForm { get; set; }
        public bool IsInvitedToLunch { get; set; }
        public bool WillAttendLunch { get; set; }
        public bool WillAttendDinner { get; set; }
        public string PlusOne { get; set; }
    }
}
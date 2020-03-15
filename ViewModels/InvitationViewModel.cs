using System.ComponentModel;

namespace Mariage.ViewModels
{
    public class InvitationViewModel
    {
        [DisplayName("Je serai présent au repas de midi.")]
        public bool WillAttendLunch { get; set; }
        [DisplayName("Je serai présent au buffet du soir.")]
        public bool WillAttendDinner { get; set; }
        [DisplayName("Je serai accompagné (conjoint/partenaire).")]
        public bool HasPlusOne { get; set; }
        [DisplayName("Prénom et nom :")]
        public string PlusOne { get; set; }
        [DisplayName("Nombre d'enfants :")]
        public int Children { get; set; }
    }
}
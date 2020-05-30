using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mariage.ViewModels
{
    public class InvitationViewModel
    {
        [DisplayName("Je serai présent au repas de midi.")]
        public bool WillAttendLunch { get; set; } = false;
        [DisplayName("Je serai présent au buffet du soir.")]
        public bool WillAttendDinner { get; set; } = false;
        [DisplayName("Je serai accompagné (conjoint/partenaire).")]
        public bool HasPlusOne { get; set; } = false;
        [DisplayName("Prénom :")]
        public string? PlusOneFirstName { get; set; }
        [DisplayName("Nom :")]
        public string? PlusOneLastName { get; set; }
        [DisplayName("Nombre d'enfants :")]
        public int Children { get; set; } = 0;
    }
}
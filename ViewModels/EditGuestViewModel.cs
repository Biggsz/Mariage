using System.ComponentModel.DataAnnotations;

namespace Mariage.ViewModels
{
    public class EditGuestViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Prénom")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string? LastName { get; set; }
        [Display(Name = "Invité à midi")]
        [Required]
        public bool IsInvitedToLunch { get; set; }
        [Display(Name = "Peut amener ses enfants")]
        [Required]
        public bool CanBringChildren { get; set; }
        [Display(Name = "Peut amener son conjoint/partenaire")]
        [Required]
        public bool CanBringPlusOne { get; set; }
    }
}
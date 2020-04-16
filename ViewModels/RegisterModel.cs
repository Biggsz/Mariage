using System.ComponentModel.DataAnnotations;

namespace Mariage.ViewModels
{
    public class RegisterModel
    {
        [EmailAddress(ErrorMessage="L'adresse email n'est pas valide.")]
        [Required(ErrorMessage="L'adresse email est obligatoire.")]
        public string? Email { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage="Le prénom est obligatoire.")]
        public string? FirstName { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage="Le nom est obligatoire.")]
        public string? LastName { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Le mot de passe est obligatoire.")]
        public string? Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="La confirmation du mot de passe est obligatoire.")]
        [Compare("Password",ErrorMessage="La confirmation du mot de passe ne correspond pas au mot de passe.")]
        public string? PasswordConfirmation { get; set; }
    }
}
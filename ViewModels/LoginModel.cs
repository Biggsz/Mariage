using System.ComponentModel.DataAnnotations;

namespace Mariage.ViewModels
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage="L'adresse email n'est pas valide.")]
        [Required(ErrorMessage="L'adresse email est obligatoire.")]
        public string Email { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Le mot de passe est obligatoire.")]
        public string Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Wypozyczalnia1.Models;

namespace Wypozyczalnia1.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Pole Email jest wymagane")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole Hasło jest wymagane")]
        [StringLength(100, ErrorMessage = "{0} musi mieć co najmniej {2} znaków długości.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasło i potwierdzenie hasła nie są zgodne.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Pole Email jest wymagane")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole Hasło jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }

    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Rodzaj użytkownika")]
        public UserType UserType { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Wypozyczalnia1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile Profile { get; set; }
        [Required]
        public string Email {  get; set; }
        
    }

    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Rodzaj użytkownika")]
        public UserType UserType { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public enum UserType
    {
        [Display(Name = "Brązowy")]
        Bronze,

        [Display(Name = "Srebrny")]
        Silver,

        [Display(Name = "Złoty")]
        Gold
    }
}

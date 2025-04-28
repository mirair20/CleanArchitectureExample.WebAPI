using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureExample.WebAPI.model
{
    public class UserRegistrationRequest
    {
        [Required(ErrorMessage = "Nimi pakollinen.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Sähköpostiosoite pakollinen.")]
        [EmailAddress(ErrorMessage = "Sähköpostiosoite ei ole kelvollinen")] 

        public required string Email {  get; set; }
    }
}

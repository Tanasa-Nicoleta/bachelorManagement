using System.ComponentModel.DataAnnotations;

namespace BachelorManagement.ApiLayer.Models
{
    public class AccountDto
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@".+\b@info\.uaic\.ro\b$")]
        [MinLength(12)]
        [MaxLength(61)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[A-Z])(?=.*[@#$%^&+=!*()\-_{}\\ |:;\,<>?`~\[\]\.\'])(?=\S+$).{6,}$")]
        [MaxLength(32)]
        public string Password { get; set; }
    }
}
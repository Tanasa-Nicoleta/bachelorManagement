using System.ComponentModel.DataAnnotations;

namespace BachelorManagement.ApiLayer.Models
{
    public class AccountDTO
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@".+\b@info\.uaic\.com\b$")]
        [MinLength(12)]
        [MaxLength(61)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[A-Z])(?=.*[@#$%^&+=!*()\-_{}\\ |:;\,<>?`~\[\]\.\'])(?=\S+$).{6,}$")]
        [MaxLength(32)]
        public string Password { get; set; }
    }
}

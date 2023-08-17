using System.ComponentModel.DataAnnotations;

namespace _1FinanceAssignment_Web_Api_.AccountDto
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

namespace WebApplication1.Models
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя пользователя должно быть от 3 до 20 символов.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Имя пользователя может содержать только буквы, цифры и подчеркивания.")]
        [Remote(action: "IsUsernameUnique", controller: "Account", ErrorMessage = "Это имя пользователя уже занято.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 100 символов.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [CreditCard]
        public string CreditCardNumber { get; set; }

        public string PhoneNumber { get; set; }

        [Range(18, 100, ErrorMessage = "Возраст должен быть от 18 до 100 лет.")]
        public int Age { get; set; }

        [Url]
        public string Website { get; set; }

        [ValidateNever]
        public bool TermsOfService { get; set; }
    }
}

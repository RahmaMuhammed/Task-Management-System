using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password Doesn't Match")]
        public string ConfirmedPassword { get; set; }
        [Required(ErrorMessage = "Data Of Birth is Required")]
        public DateOnly DOB { get; set; }
        public bool IsAgree { get; set; }

    }
}

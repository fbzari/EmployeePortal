using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models
{
    public class AddEmployeeViewModel
    {
            public string Name { get; set; }
            public string Email { get; set; }

            [Required(ErrorMessage = "Phone number is required")]
            [Range(1000000000, 9999999999, ErrorMessage = "Phone number must be a 10-digit number")]
            public long PhoneNo { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Department { get; set; }
    }
}

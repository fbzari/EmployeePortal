using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EmployeePortal.Data;

namespace EmployeePortal.Models.Validation
{
    public class EmailExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (MVCDemoDbContext)validationContext.GetService(typeof(MVCDemoDbContext));
            var email = value as string;

            // Check if the email exists in the database
            if (dbContext.Employees.Any(e => e.Email == email))
            {
                return new ValidationResult("Email already exists.");
            }

            return ValidationResult.Success;
        }
    }
}

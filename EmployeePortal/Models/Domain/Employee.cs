﻿namespace EmployeePortal.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
    }
}

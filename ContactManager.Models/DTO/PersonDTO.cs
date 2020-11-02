using System;

namespace ContactManager.Models.DTO
{
    public class PersonDTO : EntityBase
    {
        public DateTime DateofBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}

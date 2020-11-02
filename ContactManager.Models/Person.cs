using System;

namespace ContactManager.Models
{
    public class Person : EntityBase
    {
        public DateTime DateofBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}

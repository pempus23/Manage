using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ContactManager.DAL.EF
{
    public class MyData : DropCreateDatabaseAlways<ContactManagerContext>
    {
        protected override void Seed(ContactManagerContext context)
        {
            List<Person> people = new List<Person>
            {
                new Person{DateofBirth = new DateTime(2008, 5, 10, 18, 30, 25), Married = false, Phone ="+510111215655",Salary= 18150},
                new Person{DateofBirth = new DateTime(1991, 2, 11, 3, 15, 36), Married = true, Phone ="+560122215655",Salary= 13870}
            };
            people.ForEach(x => context.People.AddOrUpdate(
                c => new { c.DateofBirth, c.Married, c.Phone, c.Salary }, x));

        }
    }
}

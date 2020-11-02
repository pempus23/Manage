using ContactManager.Models;
using System.Data.Entity;

namespace ContactManager.DAL.EF
{
    public class ContactManagerContext : DbContext
    {
        public ContactManagerContext()
            : base("AutoConnection")
        {
            
        }
        public virtual DbSet<Person> People { get; set; }
    }
}

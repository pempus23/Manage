using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DAL.Repository
{
    public class PersonRepository : BaseRepository<Person>, IRepository<Person>
    {
        public override List<Person> GetAll()
        {
            return Context.People.OrderBy(x => x.Id).ToList();
        }
        public override int Add(Person entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            return SaveChanges();
        }
    }
}

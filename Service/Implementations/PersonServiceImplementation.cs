using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonAPI_Mysql.Data;
using PersonAPI_Mysql.Model;

namespace PersonAPI_Mysql.Service.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySqlContext _mysqlContext;
        public PersonServiceImplementation(MySqlContext context)
        {
            _mysqlContext = context;
        }
        public Person Create(Person person)
        {
            throw new System.NotImplementedException();
        }

         public Person Update(Person person, int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Person> FindAll()
        {
            var persons = _mysqlContext.Persons.ToList();
            return persons;
        }

        public Person FindbyId(int id)
        {
            var person = _mysqlContext.Persons.Where(p => p.Id == id).FirstOrDefault();
            return person;
        }


    }
}
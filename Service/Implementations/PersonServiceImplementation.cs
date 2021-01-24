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
            try
            {
                _mysqlContext.Add(person);
                _mysqlContext.SaveChanges();                
            }
            catch (System.Exception)
            {
                throw;
            }

            return person;
        }

         public Person Update(Person person)
        {
            if(!Exists(person.Id)) return new Person();
            
            var result = _mysqlContext.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if(result != null)
            {
              try
              {
                  _mysqlContext.Entry(result).CurrentValues.SetValues(person);
                  _mysqlContext.SaveChanges();
              }
              catch (System.Exception)
              {
                  throw;
              }
            }
 

            return person;

        }

        public void Delete(int id)
        {
            var result = _mysqlContext.Persons.Where(p => p.Id == id).FirstOrDefault();

            if (result != null)
            {
                try
                {
                    _mysqlContext.Persons.Remove(result);
                    _mysqlContext.SaveChanges();
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
            }
        }

        public List<Person> FindAll()
        {
            var persons = _mysqlContext.Persons.ToList();
            return persons;
        }

        public Person FindbyId(int id)
        {
            var person = _mysqlContext.Persons.SingleOrDefault(p => p.Id == id);
            return person;
        }

        private bool Exists(int id)
        {
            return _mysqlContext.Persons.Any(p => p.Id.Equals(id));
        }

    }
}
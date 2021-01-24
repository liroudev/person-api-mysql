using System.Collections.Generic;
using PersonAPI_Mysql.Model;

namespace PersonAPI_Mysql.Service
{
    public interface IPersonService
    {
        Person Create (Person person);
        Person Update(Person person);
        void Delete(int id);
         List<Person> FindAll();
         Person FindbyId(int id);
    }
}
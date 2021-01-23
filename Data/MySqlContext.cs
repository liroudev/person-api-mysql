using Microsoft.EntityFrameworkCore;
using PersonAPI_Mysql.Model;

namespace PersonAPI_Mysql.Data
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(){}

        public MySqlContext(DbContextOptions<MySqlContext> options): base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }

    }
}
using ASP_Demo_Archi_DAL.Models;

namespace ASP_Demo_Archi_DAL.Repositories
{
    public interface IPersonRepo
    {
        void Create(Person person);
        List<Person> GetAll();
        Person GetById(int Id);
    }
}
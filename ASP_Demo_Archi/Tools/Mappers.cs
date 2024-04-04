using ASP_Demo_Archi.Models;
using ASP_Demo_Archi_DAL.Models;

namespace ASP_Demo_Archi.Tools
{
    public static class Mappers
    {
        public static Movie ToDAL(this MovieCreateForm form)
        {
            return new Movie
            {
                Title = form.Title,
                Description = form.Description,
                RealisatorId = form.RealisatorId
            };
        }
    }
}

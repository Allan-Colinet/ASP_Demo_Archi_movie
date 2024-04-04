using ASP_Demo_Archi_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Demo_Archi_DAL.Repositories
{
    public interface IMovieRestrictRepo
    {
        List<Movie> GetAll();
        Movie GetById(int id);
    }
}

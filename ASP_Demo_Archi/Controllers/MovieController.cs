using ASP_Demo_Archi.Models;
using ASP_Demo_Archi.Tools;
using ASP_Demo_Archi_DAL.Models;
using ASP_Demo_Archi_DAL.Repositories;
using ASP_Demo_Archi_DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Demo_Archi.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepo _movieRepo;

        public MovieController(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
            
        }
        public IActionResult Index()
        {
            return View(_movieRepo.GetAll());
        }

        public IActionResult Liste()
        {

            return View(_movieRepo.GetAll());
        }

        public IActionResult Details(int id)
        {
            Movie m = _movieRepo.GetById(id);
            return View(m);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Scénario de gestion des erreurs => Voir MovieService (Create)
        //Voir Modif dans controller Home/Error et dans la vue Shared/Error
        [HttpPost]
        public IActionResult Create(MovieCreateForm movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_movieRepo.Create(movie.ToDAL()))
                    {
                        return RedirectToAction("Liste");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Une erreur s'est produite lors de l'ajout";
                        return View(movie);
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error", "Home", routeValues: new { ex.Message });
                }
            }
            return View(movie);

        }



        /*
         Mettre en place le formulaire de mise à jour d'un film
            => L'action en HttpPost pour enregistrer les modif quand on a cliqué sur Valider
            => La méthode de service Edit qui fait la mise à jour dans la liste
            => La vu qui présente le formulaire prérempli avec les données du film à éditer
         */

        //Afficher le formulaire prérempli sur base d'un id
        public IActionResult Edit(int id)
        {
            Movie aModifier = _movieRepo.GetById(id);
            return View(aModifier);
        }

        //Action entreprise quand je clique sur Valider dans le formulaire
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Edit(movie);
                return RedirectToAction("Liste");
            }
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            _movieRepo.Delete(id);
            return RedirectToAction("Liste");
        }
    }
}

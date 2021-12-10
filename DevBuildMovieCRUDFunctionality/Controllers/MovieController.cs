using DevBuildMovieCRUDFunctionality.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildMovieCRUDFunctionality.Controllers
{
    public class MovieController : Controller
    {
        private MovieDAL MovieDAL = new MovieDAL();

        public IActionResult Index()
        {
            Movie model = new Movie();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Movie model)
        {
            if (ModelState.IsValid)
            {
                MovieDAL.CreateMovie(model);
                return RedirectToAction("Result", "Movie", model);
            }
            return View(model);
        }

        public IActionResult Result(Movie model)
        {
            return View(model);
        }

        public IActionResult Catalog()
        {
            return View(MovieDAL.GetMovies());
        }

        public IActionResult Details(int id)
        {
            return View(MovieDAL.GetMovie(id));
        }

        public IActionResult Edit(int id)
        {
            return View(MovieDAL.GetMovie(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            if (ModelState.IsValid)
            {
                MovieDAL.UpdateMovie(model);
                return RedirectToAction("EditResult", "Movie", model);
            }
            return View(MovieDAL.GetMovie(model.ID));
        }

        public IActionResult EditResult(Movie model)
        {
            return View(MovieDAL.GetMovie(model.ID));
        }

        public IActionResult Delete(int id)
        {

            return View(MovieDAL.GetMovie(id));
        }

        [HttpPost]
        public IActionResult Delete(Movie model)
        {
            MovieDAL.DeleteMovie(model.ID);
            return RedirectToAction("Catalog", "Movie");
        }
    }
}

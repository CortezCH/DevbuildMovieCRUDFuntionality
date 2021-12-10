using DevBuildMovieCRUDFunctionality.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildMovieCRUDFunctionality.Controllers
{
    public class SearchController : Controller
    {
        SearchDAL SearchDAL = new SearchDAL();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            Search model = new Search();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(Search model)
        {
            
            return RedirectToAction("SearchResult", "Search", model);
        }

        public IActionResult SearchResult(Search model)
        {
            if(model.Title != string.Empty || model.Genre != string.Empty)
            {
                List<Movie> searchResults = SearchDAL.SearchMovie(model);
                return View(searchResults);
            }
            return RedirectToAction("Search", "Search", model);
        }
    }
}

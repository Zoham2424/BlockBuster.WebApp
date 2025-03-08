using BlockBuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlockBuster.WebApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            return View(movie);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            ViewBag.GenreId =
                new SelectList
                (
                    BasicFunctions
                        .GetAllGenres()
                        .ToDictionary
                        (
                            genre => genre.GenreId,
                            genre => genre.GenreDescr
                        ),
                    "Key",
                    "Value"
                );

            ViewBag.DirectorId =
                   new SelectList
                    (
                        BasicFunctions
                            .GetAllDirectors()
                            .ToDictionary
                            (
                                director => director.DirectorId,
                                director => $"{director.LastName}, {director.FirstName}"
                            ),
                        "Key",
                        "Value"
                    );

            return View(movie);
        }


        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                BasicFunctions
                    .UpdateMovie
                    (
                        id,
                        collection[nameof(Movie.Title)],
                        int.Parse(collection[nameof(Movie.ReleaseYear)]),
                        BasicFunctions.GetDirectorById(int.Parse(collection["DirectorId"])),
                        BasicFunctions.GetGenreById(int.Parse(collection["GenreId"]))
                    );

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }


        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

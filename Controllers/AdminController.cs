﻿using BlockBuster.Models;
using BlockBuster.WebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlockBuster.WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            var movieList = BasicFunctions.GetMovieWithDetailsById(id);
            return View(movieList);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            ViewBag.DirectorId = DropDownFormatter.FormatDirectors();
            ViewBag.DirectorId = DropDownFormatter.FormatGenres();
            return View();
        }

        // POST: AdminController/Create
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

        // GET: AdminController/Edit/5
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movieToEdit)
        {
            try
            {
                BasicFunctions.EditMovie(movieToEdit);
                return RedirectToAction("Admin", " Home");
            }
            catch
            {
                return View();
            }
        }

    

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            return View(movie);  
        }
        public ActionResult Delete(Movie movie)
        {
            try
            {
                BasicFunctions.DeleteMovie(movie.MovieId);
                return RedirectToAction("Admin", " Home");
            }
            catch
            {
                return View();
            }
        }

            // POST: AdminController/Delete/5
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

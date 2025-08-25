using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC_9_Code_First.Models;
using CC_9_Code_First.Repositories;

namespace CC_9_Code_First.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        IMovieRepository<Movies> movieRepository = null;

        public MovieController()
        {
            movieRepository = new MovieRepository<Movies>();
        }

        public ActionResult Index()
        {
            var getAllMovies = movieRepository.GetAllMovies();
            return View(getAllMovies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movies movies)
        {
            if (ModelState.IsValid)
            {
                movieRepository.Create(movies);
                movieRepository.save();
                return RedirectToAction("Index");
            }
            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            var movie = movieRepository.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                movieRepository.Edit(movie);
                movieRepository.save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = movieRepository.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ToDelete(int id)
        {
            movieRepository.Delete(id);
            movieRepository.save();
            return RedirectToAction("Index");
        }

        public ActionResult GetYear()
        {
            return View();
        }

        [HttpPost,ActionName("GetYear")]
        public ActionResult GetMovieReleasedInYear(DateTime year)
        {
            var allMovies = movieRepository.GetAllMovies();
            var res = (from m in allMovies
                       where m.DateOfRelease.Year == year.Year
                       select m).ToList();
            return View("GetMovieReleasedInYear",res);
        }

        public ActionResult GetDirectorName()
        {
            return View();
        }

        [HttpPost,ActionName("GetDirectorName")]
        public ActionResult GetMovieByDirectorName(string name)
        {
            var allMovies = movieRepository.GetAllMovies();
            var res = (from m in allMovies
                       where m.DirectorName == directorName
                       select m).ToList();
            return View(res);
        }
    }
}
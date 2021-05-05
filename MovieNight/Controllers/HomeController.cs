using MovieNight.Models;
using MovieNight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieNight.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index(int page = 1)
        {
            IQueryable<Movie> query = db.Movies;
            int totalItems = query.Count();
            int pageSize = 9;
            int totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);
            List<Movie> movies = query
                .OrderByDescending(x => x.ImdbRating).Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            // filmleri listeye ekledik

            var vm = new HomeViewModel()
            {
                Movies = movies,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    ItemsOnPage = movies.Count,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                    HasNext = page < totalPages,
                    HasPrevious = page > 1
                }
            };
            return View(vm);

            //ViewBag.TotalPages =(int)Math.Ceiling(db.Movies.Count() / 9m);
            //ViewBag.Page = page; 
            //return View(db.Movies.OrderByDescending(x => x.ImdbRating).Skip((page - 1) * 9).Take(9).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
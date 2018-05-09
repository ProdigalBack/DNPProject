using CinemaData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VIACinema.Models.Catalog;

namespace VIACinema.Controllers
{
    public class CatalogController:Controller
    {
        private IMovie _movies;
        private IShowing _showing;
        private IShowingSeat _showingSeat;
        
        public CatalogController(IMovie movies,IShowing showings, IShowingSeat showingSeat)
        {
            _movies = movies;
            _showing = showings;
            _showingSeat = showingSeat;
        }

        public IActionResult Index()
        {
            var movieModels = _movies.GetAll();
            var listingResult = movieModels
                .Select(result => new MovieIndexListingModel {
                    Id=result.Id,
                    ImageUrl=result.ImageUrl,
                    Name=result.Name,
                    Description=result.Description
                });

            var model = new MovieIndexModel()
            {
                Movies=listingResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var showings = _showing.GetById(id);
            var listingResult = showings
                .Select(result => new ShowingIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.Movie.ImageUrl,
                    Name = result.Movie.Name,
                    Description = result.Movie.Description,
                    Runtime=result.Movie.Runtime,
                    Director=result.Movie.Director,
                    Actor=result.Movie.Actor,
                    Time=result.Showtime
                });

            var model = new ShowingIndexModel()
            {
                Showings = listingResult
            };
            return View(model);
            
        }

        public IActionResult Order(int id)
        {
            string Name = _showing.GetMovie(id).Name;
            var seats = _showingSeat.GetSeatsById(id);
            var listingResult = seats
                .Select(result => new ShowingSeatIndexListingModel
                {
                    Name = Name,
                    Id =result.Id,
                    Seat=result.Seat,
                    Showing=result.Showing,
                    Status=result.Status
                 });

            var model = new ShowingSeatIndexModel()
            {
                ShowingSeats=listingResult
            };
            return View(model);
        }
    }
}

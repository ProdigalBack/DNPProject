using CinemaData;
using CinemaData.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VIACinema.Models.Catalog;
using VIACinema.Models.OrderHistory;

namespace VIACinema.Controllers
{
    
    public class CatalogController:Controller
    {
        private IMovie _movies;
        private IShowing _showing;
        private IShowingSeat _showingSeat;
        private IOrder _order;
        static int userId;

        
        public CatalogController(IMovie movies,IShowing showings, IShowingSeat showingSeat,IOrder order)
        {
            _movies = movies;
            _showing = showings;
            _showingSeat = showingSeat;
            _order = order;
           
        }
        [Authorize]
        public IActionResult Index(int id) 
        {
            if (id != 0)
            {
                userId = id;
            }
            var movieModels = _movies.GetAll();
            var listingResult = movieModels
                .Select(result => new MovieIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    Name = result.Name,
                    Description = result.Description
                });

            var model = new MovieIndexModel()
            {
                Movies = listingResult
            };
            int i = userId;
            return View(model);
        }
        
        [Authorize]
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
        [Authorize]
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

        [Authorize]
        public IActionResult ChooseSeat(int id)
        {
           
            var showingSeat = _showingSeat.GetShowingSeat(id);
            _order.OrderTicket(userId, showingSeat.Id);
            int showingId = showingSeat.Showing.Id;
            return RedirectToAction("Order", new { id =  showingId});
        }
        [Authorize]
        public IActionResult OrderHistory()
        {
            var orderHistory = _order.GetOrdersById(userId);

            var listingResult = orderHistory
                .Select(result => new OrderIndexListingModel
                {

                    Name = _order.Get(result.Id).ShowingSeat.Showing.Movie.Name,
                    Row = _order.Get(result.Id).ShowingSeat.Seat.Row,
                    Column= _order.Get(result.Id).ShowingSeat.Seat.Column,
                    Time= _order.Get(result.Id).ShowingSeat.Showing.Showtime
                });
            var model = new OrderIndexModel
            {
                OrderHistory=listingResult
            };
            return View("~/Views/OrderHistory/OrderHistory.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        
    }
}

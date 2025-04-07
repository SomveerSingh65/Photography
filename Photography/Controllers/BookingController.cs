using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Photography.Models;
using Photography.Services.Abstract;
using Photography.Services.Concate;

namespace Photography.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingServices _services;
        public BookingController(IBookingServices services)

        {
            _services = services;
        }

        // GET: BookingController

        public async Task<IActionResult> Index()
        {
            var bookings = await _services.GetAllBooking(); // Await and get the bookings
            return View(bookings); // Pass the bookings to the view
        }
        // GET: BookingController/Details/5

        public ActionResult GetSingleBooking(int id)
        {
            var SingleBooking = _services.GetSingleBooking(id);
            return View(SingleBooking);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: BookingController/Create
        public async Task<IActionResult> Create([Bind("CustomerName,PhotographerName,Date,EventType,Contact")] BookingModel model)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateBooking(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("BookingId,CustomerName,PhotographerName,Date,EventType,Contact")] BookingModel model)
        {
            if (id != model.BookingId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _services.UpdateBooking(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             _services.DeleteBooking(id);
            return RedirectToAction(nameof(Index));
        }



    }
}

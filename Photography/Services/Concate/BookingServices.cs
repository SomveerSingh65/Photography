using Microsoft.EntityFrameworkCore;
using Photography.Databases;
using Photography.Models;
using Photography.Services.Abstract;

namespace Photography.Services.Concate
{
    public class BookingServices :IBookingServices
    {
        private readonly AppDbContext _appDbContext;
        public BookingServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<BookingModel>> GetAllBooking()
        {
            return await _appDbContext.Bookings.ToListAsync();
        }

        public async Task<BookingModel> GetSingleBooking(int bookingId)
        {
            return await _appDbContext.Bookings.FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }

        public async Task CreateBooking(BookingModel model)
        {
            _appDbContext.Bookings.AddAsync(model);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateBooking(BookingModel model)
        {
            _appDbContext.Bookings.Update(model);
            await _appDbContext.SaveChangesAsync();
        }

        public void DeleteBooking(int bookingId)
        {
            var FilterBooking = _appDbContext.Bookings.FirstOrDefault(B => B.BookingId == bookingId);
            if (FilterBooking != null)
            {
                _appDbContext.Remove(FilterBooking);
            }


        }
    }
}

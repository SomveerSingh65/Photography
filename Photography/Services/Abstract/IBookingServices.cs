using Photography.Models;
using System.Threading.Tasks;

namespace Photography.Services.Abstract
{
    public interface IBookingServices
    {
        Task<IEnumerable<BookingModel>> GetAllBooking();
        Task<BookingModel> GetSingleBooking(int bookingId);
        Task CreateBooking(BookingModel model);
        Task UpdateBooking(BookingModel model);
        void DeleteBooking(int bookingId);
    }
}

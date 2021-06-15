using Api.Pricex.myDB;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo.CustomerService
{
    public class QuickToolRepo
    {
        public pedb_devContext _context { get; }
        public QuickToolRepo(pedb_devContext context)
        {
            _context = context;
        }

        public Bookings GetBooking(int booking_id)
        {
            return _context.Bookings.SingleOrDefault(e => e.Id == booking_id);
        }

        public async Task<String> ChangeName(Bookings model, int booking_id)
        {
            var bookings = GetBooking(booking_id);

            if (bookings == null)
            {
                return null;
            }
            else
            {
                bookings.LeadGuestName = model.LeadGuestName;
                bookings.Surname = model.Surname;
                bookings.UpdatedAt = DateTime.Now;

                _context.Bookings.Update(bookings);
                _context.SaveChanges();
            }

            return "Change name successfully";
        }
    }
}

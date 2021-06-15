using Api.Pricex.myDB;
using System.Collections.Generic;
using System.Linq;

namespace Api.Pricex.Repo.CustomerService
{
    public class BookingReportRepo
    {
        public pedb_devContext _context { get; }
        public BookingReportRepo(pedb_devContext context)
        {
            _context = context;
        }

        public List<BookingReport> GetBookingReport(int booking_id)
        {
            return _context.BookingReport.Where(e => e.BookingId == booking_id).OrderByDescending(b => b.Seq).ToList();
        }
    }
}

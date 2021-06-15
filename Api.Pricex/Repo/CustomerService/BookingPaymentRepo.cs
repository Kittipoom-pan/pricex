using Api.Pricex.myDB;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo.CustomerService
{
    public class BookingPaymentRepo
    {
        public pedb_devContext _context { get; }
        public BookingPaymentRepo(pedb_devContext context)
        {
            _context = context;
        }

        public Task<Invoices> GetBookingPayment(string offer_id, int booking_id)
        {
            return _context.Invoices.Where(e => e.InvoiceableId == offer_id).FirstOrDefaultAsync();
        }

        //public async Task<String> EditBookingPayment(OfferPaymentTransactions model, string offer_id, int user_id)
        //{
        //    var bookingPayment = GetBookingPayment(offer_id, user_id);
        //    if (bookingPayment == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        bookingPayment.Seq = model.Seq;
        //        bookingPayment.CreatedAt = model.CreatedAt;
        //        bookingPayment.PaymentType = model.PaymentType;
        //        bookingPayment.Amount = model.Amount;
        //        bookingPayment.Status = model.Status;
        //        bookingPayment.Last4Digit = model.Last4Digit;
        //        bookingPayment.TransactionType = model.TransactionType;
        //        bookingPayment.Currency = model.Currency;
        //        bookingPayment.GateWay = model.GateWay;
        //        bookingPayment.UpdatedAt = DateTime.Now;

        //        _context.OfferPaymentTransactions.Update(bookingPayment);
        //        _context.SaveChanges();
        //    }

        //    return "Booking payment update successfully";
        //}
    }
}

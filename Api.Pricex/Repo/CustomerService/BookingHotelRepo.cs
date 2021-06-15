using Api.Pricex.myDB;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EmailService;
using Microsoft.Extensions.Options;
using Api.Pricex.Models;

namespace Api.Pricex.Repo.CustomerService
{
    public class BookingHotelRepo
    {
        public pedb_devContext _context { get; }
        private readonly IEmailSender _emailSender;
        private readonly IOptions<EmailAccount> _emailAccount;
        public BookingHotelRepo(pedb_devContext context, IEmailSender emailSender, IOptions<EmailAccount> emailAccount)
        {
            _context = context;
            _emailAccount = emailAccount;
            _emailSender = emailSender;
        }

        public async Task<Offers> GetOfferHotel(int offer_id) => _context.Offers.Where(e => e.Id == offer_id && e.StatusId == 4).FirstOrDefault();

        public async Task<string> CancelBooking(int offer_id, string reason_cancel)
        {
            var result = await GetOfferHotel(offer_id);
            if(result == null)
            {
                return null;
            }
            else
            {
                result.ReasonCancel = reason_cancel;
                result.StatusId = 5;
                result.CanceledAt = DateTime.Now;

                _context.Offers.Update(result);
                _context.SaveChanges();
            }
            return "Cancel booking successfully";
        }

        public async Task<string> RejectBooking(int offer_id, int reject_id)
        {
            var result = await GetOfferHotel(offer_id);
            if (result == null)
            {
                return null;
            }
            else
            {
                result.ReasonRejectId = reject_id;
                result.StatusId = 3;
                result.RejectedAt = DateTime.Now;

                _context.Offers.Update(result);
                _context.SaveChanges();
            }

            var reasonReject = await _context.ReasonReject.Where(e => e.Id == reject_id).FirstOrDefaultAsync();
            ContactEmail contact = new ContactEmail(_context);

            var model = await contact.GetContactEmail(offer_id);
            if (model != null && model.CustomerEmail != null && model.HotelEmail != null)
            {
                //string emailHotel = _emailAccount.Value.Hotel;
                string emailHotel = model.HotelEmail;
                string emailCustomer = model.CustomerEmail;
                var message = new Message(new string[] { emailHotel, emailCustomer }, "Reject booking", string.Format("Reason : {0}", reasonReject.Reason));
                await _emailSender.SendEmailAsync(message);
            }
       
            return "Reject booking successfully";
        }

        public async Task<String> EditBookingHotel(Offers offers, int offer_id, int user_id)
        {
            var result = await GetOfferHotel(offer_id);

            if (result == null)
            {
                return null;
            }
            else
            {
                result.CheckedinAt = offers.CheckedinAt;
                result.CheckedoutAt = offers.CheckedoutAt;
                result.TotalAdults = offers.TotalAdults;
                result.TotalChildren = offers.TotalChildren;
                result.SpecialRequest = offers.SpecialRequest;
                result.UpdatedAt = DateTime.Now;

                _context.Offers.Update(result);
                _context.SaveChanges();
            }

            return "Hotel reservation update successfully";
        }
    }
}

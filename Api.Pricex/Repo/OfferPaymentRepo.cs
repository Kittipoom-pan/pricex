using Api.Pricex.Interface;
using Api.Pricex.myDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class OfferPaymentRepo : IOfferPayment
    {
        public pedb_devContext _context { get; }
        public OfferPaymentRepo(pedb_devContext context)
        {
            _context = context;
        }
        public async Task OfferPaymentTimeOut(int offer_id)
        {
            int[] paymentStatus = new int[] { 1, 2 };
            long today = DateTime.Today.Ticks;

            var offer = await _context.Offers.Where(e => e.Id == offer_id && paymentStatus.Contains(e.StatusId)).FirstOrDefaultAsync();
            if(DateTime.Now > offer.PaymentExpiredAt)
            {

            }
            throw new NotImplementedException();
        }
    }
}

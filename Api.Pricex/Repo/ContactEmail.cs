using Api.Pricex.myDB;
using Api.Pricex.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class ContactEmail
    {
        public pedb_devContext _context { get; }
        public ContactEmail(pedb_devContext context)
        {
            _context = context;
        }
        public async Task<ContactEmailViewModel> GetContactEmail(int offer_id)
        {
            var result = (from f in _context.Set<Offers>()
                          join b in _context.Set<Bookings>()
                          on f.Id equals b.OfferId
                          join u in _context.Set<Users>()
                          on b.UserId equals u.Id
                          join r in _context.Set<Rooms>()
                          on f.RoomId equals r.Id
                          join h in _context.Set<HotelBranches>()
                          on r.HotelBranchId equals h.Id
                          where f.Id == offer_id
                          select new ContactEmailViewModel
                          {
                              CustomerEmail = u.Email,
                              HotelEmail = h.Email 
                          }).FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            return result;
        }
    }
}

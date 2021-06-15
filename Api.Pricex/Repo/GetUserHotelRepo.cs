using Api.Pricex.myDB;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class GetUserHotelRepo
    {
        public pedb_devContext _context { get; }
        public GetUserHotelRepo(pedb_devContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserHotel(int user_hotel_id) => _context.User.Where(e => e.Id == user_hotel_id).FirstOrDefault();
    }
}

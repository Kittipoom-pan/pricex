using Api.Pricex.Models;
using System.Threading.Tasks;

namespace Api.Pricex.Interface
{
    public interface IPushNotificationService
    {
        Task SendNotification(PushNotification notification, int user_hotel_id, string booking_type);
    }
}

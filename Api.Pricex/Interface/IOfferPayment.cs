using System.Threading.Tasks;

namespace Api.Pricex.Interface
{
    public interface IOfferPayment
    {
        Task OfferPaymentTimeOut(int offer_id);
    }
}

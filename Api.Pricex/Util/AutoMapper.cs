using Api.Pricex.myDB;
using Api.Pricex.ViewModels;
using Api.Pricex.ViewModels.CustomerService;
using AutoMapper;

namespace Api.Pricex.Util
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserViewModels, User>();

            CreateMap<Invoices, BookingPaymentViewModel>()
                .ForMember(dest =>
                    dest.Amount,
                    opt => opt.MapFrom(src => src.Total))
                .ForMember(dest =>
                    dest.Reference,
                    opt => opt.MapFrom(src => src.InvoiceNumber))
                .ForMember(dest =>
                    dest.PaymentType,
                    opt => opt.MapFrom(src => src.CardType));

            CreateMap<BookingReport, BookingReportViewMoel>();

            //CreateMap<HotelBranches, Photos>()
            //  .IncludeMembers(src => src.Photos);

            //CreateMap<Photos, PhotoViewModels>()
            //  .ForMember(dest => dest.Filename, m => m.MapFrom(src => src.Filename));

            //CreateMap<Photos, PhotoViewModels>().ForMember(p => p.Filename, opt => opt.Ignore());
        }
    }
}

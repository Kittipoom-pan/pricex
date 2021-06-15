using System.ComponentModel.DataAnnotations;


namespace Api.Pricex.ViewModels.CustomerService
{
    public class BookingReportViewMoel
    {
        public int BookingId { get; set; }
        public int Seq { get; set; }
        public string Activitie { get; set; }
        public string Review { get; set; }
        public string CreatedBy { get; set; }
        [Display(Name = "Date")]
        public string Date { get; set; }
    }
}

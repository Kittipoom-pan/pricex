using System.Collections.Generic;

namespace Api.Pricex.ViewModels
{
    public class RegistrationViewModel 
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public int UserId  { get; set; }
        public int HotelId  { get; set; }
        public int HotelBranchId  { get; set; }
    }
}

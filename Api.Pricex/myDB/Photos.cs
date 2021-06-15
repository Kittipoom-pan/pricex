
using Api.Pricex.ViewModels;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Api.Pricex.myDB
{
    public partial class Photos
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public int? ReferenceId { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public string Mime { get; set; }
        public string DiskType { get; set; }
        //public byte? IsCover { get; set; }
        //public DateTime? CreatedAt { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        //public string UpdatedBy { get; set; }
        //public Photos()
        //{
        //    Path = Path + Filename;
        //}
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual HotelRoomType hotelRoomType { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual HotelBranches HotelBranches { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Rooms Rooms { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Api.Pricex.myDB
{
    public partial class UserHotelPermissions
    {
        public int UserHotelId { get; set; }
        public byte? AllowReport { get; set; }
        public byte? AllowDashboard { get; set; }
        public byte? AllowResponseOffer { get; set; }
        public byte? AllowCheckin { get; set; }
        public byte? AllowUpdateOffer { get; set; }
        public byte? AllowBan { get; set; }
        public byte? AllowChat { get; set; }
        public byte? AllowUpdateRoom { get; set; }
        public byte? AllowManageRoom { get; set; }
        public byte? AllowSearchPending { get; set; }
        public byte? AllowSearchAccept { get; set; }
        public byte? AllowSearchReject { get; set; }
        public byte? AllowSearchCancel { get; set; }
        public byte? AllowSearchPaid { get; set; }
        public byte? AllowSearchExpired { get; set; }
        public byte? AllowFinancial { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}

using Api.Pricex.Models;
using Api.Pricex.myDB;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class HotelRoomSettingRepo
    {
        private pedb_devContext dataContext;
        private readonly IConfiguration _config;

        public HotelRoomSettingRepo(pedb_devContext dataContext, IConfiguration config)
        {
            this.dataContext = dataContext;
            _config = config;
        }

        public async Task<HotelRoomSetting> UpdateRoomSetting(RoomSetting roomSetting, int hotel_id, int hotel_branch_id)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(facilitiesModel);
                var hotelRoomSetting = dataContext.HotelRoomSettings.SingleOrDefault(e => e.HotelBranchId == hotel_branch_id);

                if (hotelRoomSetting == null)
                {
                    var hotelFacilities = new HotelRoomSetting()
                    {
                        HotelBranchId = hotel_branch_id,
                        HotelId = hotel_id,
                        Amenitie = JsonConvert.SerializeObject(roomSetting.roomSettingAmenitie),
                        CreatedAt = DateTime.Now,
                    };

                    dataContext.HotelRoomSettings.Add(hotelFacilities);
                    dataContext.SaveChanges();

                    return hotelFacilities;
                }

                else
                {
                    hotelRoomSetting.Amenitie = JsonConvert.SerializeObject(roomSetting.roomSettingAmenitie);
                    hotelRoomSetting.UpdatedAt = DateTime.Now;


                    dataContext.HotelRoomSettings.Update(hotelRoomSetting);
                    dataContext.SaveChanges();

                    return hotelRoomSetting;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Api.Pricex.Models;
using Api.Pricex.myDB;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class HotelFacilitiesRepo
    {
        private pedb_devContext dataContext;
        private readonly IConfiguration _config;

        public HotelFacilitiesRepo(pedb_devContext dataContext, IConfiguration config)
        {
            this.dataContext = dataContext;
            _config = config;
        }

        public async Task<HotelFacilities> UpdateHotelFacilities(int hotel_branch_id, FacilitiesRequestModel facilitiesModel, int user_id)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(facilitiesModel);
                var hotel = dataContext.HotelFacilities.SingleOrDefault(e => e.HotelBranchId == hotel_branch_id);
                if (hotel == null)
                {
                    var hotelFacilities = new HotelFacilities()
                    {
                        HotelBranchId = hotel_branch_id,
                        UserId = user_id,
                        FacilitiesId = JsonConvert.SerializeObject(facilitiesModel.facilities),
                        FacilitiesGroupTypeId = JsonConvert.SerializeObject(facilitiesModel.facilities_group),
                        CreatedAt = DateTime.Now,
                    };

                    dataContext.HotelFacilities.Add(hotelFacilities);
                    dataContext.SaveChanges();

                    return hotelFacilities;
                }

                else
                {
                    //foreach (var data in facilities)
                    //{
                    //HotelFacilities model = new HotelFacilities();

                    //model.HotelBranchId = hotel_branch_id;
                    //model.FacilitiesId = data.facilities_id;
                    //model.CreatedAt = DateTime.Now;

                    //Facilities facilitiesDb = new Facilities();
                    //facilitiesDb.Id = data.facilities_id;
                    //facilitiesDb.Description = data.topic_facilities;

                    //FacilitiesGroupType facilitiesGroupType = new FacilitiesGroupType();
                    //facilitiesRequestModel.raw_facilities = json;
                    //foreach (var item in data.facilities)
                    //    {
                    //        model.FacilitiesId = item.id;
                    //        model.FacilitiesGroupTypeId = item.name;
                    //        model.UpdatedAt = DateTime.Now;
                    //    }
                    hotel.FacilitiesId = JsonConvert.SerializeObject(facilitiesModel.facilities);
                    hotel.FacilitiesGroupTypeId = JsonConvert.SerializeObject(facilitiesModel.facilities_group);
                    hotel.UpdatedAt = DateTime.Now;


                    dataContext.HotelFacilities.Update(hotel);
                    dataContext.SaveChanges();

                    return hotel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

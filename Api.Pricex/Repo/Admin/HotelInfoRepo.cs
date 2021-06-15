using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Api.Pricex.Repo.Admin
{
    public class HotelInfoRepo
    {
        public pedb_devContext _context { get; }

        public HotelInfoRepo(pedb_devContext context)
        {
            _context = context;
        }

        public List<HotelInfoViewModel> GetHotelInfo(Filter filter)
        {
            try
            {
                var dashboard = new List<HotelInfoViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_hotel_info"; 
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_hotel_type", filter.hotel_type);
                    cmd.Parameters.AddWithValue("@input_search", filter.search);

                    cmd.Parameters.AddWithValue("@PageCount", MySqlDbType.Int32);
                    cmd.Parameters["@PageCount"].Direction = ParameterDirection.Output;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dashboard.Add(new HotelInfoViewModel()
                            {
                                HotelId = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                                HotelName = reader["name_en"].ToString(),
                                Rating = reader["rating"] != DBNull.Value ? Convert.ToDouble(reader["rating"]) : 0,
                                Location = string.Format("{0}, Thailand", reader["location"].ToString()),
                                Commission = reader["commission"] != DBNull.Value ? Convert.ToDouble(reader["commission"]) : 0,
                            });
                        }
                    }
                    Object obj = cmd.Parameters["@PageCount"].Value;
                    var lParam = (Int32)obj;
                    conn.Close();
                    return dashboard;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //    try
        //    {
        //        var result = new List<HotelInfoViewModel>();

        //        if (filter.search == null || filter.search == "")
        //        {
        //            result = (from h in _context.HotelBranches
        //                      join lp in _context.LocationProvinces
        //                      on h.ProvinceId equals lp.Id
        //                      group h by new { h.HotelId, h.NameEn, h.Rating } into ht
        //                      select new HotelInfoViewModel
        //                      {
        //                          //ht.Key, Top = ht
        //                          HotelId = ht.Key.HotelId,
        //                          HotelName = ht.Key.NameEn,
        //                          Rating = (float)ht.Key.Rating,
        //                          Location = string.Format("{0}, Thailand", lp.)
        //                      });
        //        }
        //        else if (filter.hotel_type == "hotel_id")
        //        {
        //            result = (from h in _context.HotelBranches
        //                      join r in _context.Rooms
        //                      on h.Id equals r.HotelBranchId
        //                      join lp in _context.LocationProvinces
        //                      on h.ProvinceId equals lp.Id
        //                      join f in _context.Offers
        //                      on r.Id equals f.RoomId
        //                      join ra in _context.Ratings
        //                      on f.Id equals ra.OfferId
        //                      where h.Id == Convert.ToInt32(filter.search)
        //                      select new HotelInfoViewModel
        //                      {
        //                          HotelId = h.HotelId,
        //                          HotelName = h.NameEn,
        //                          Rating = (float)ra.Rating,
        //                          Location = string.Format("{0}, Thailand", lp.NameEn)
        //                      }).ToList();
        //        }
        //        else if (filter.hotel_type == "hotel_name")
        //        {
        //            result = (from h in _context.HotelBranches
        //                      join r in _context.Rooms
        //                      on h.Id equals r.HotelBranchId
        //                      join lp in _context.LocationProvinces
        //                      on h.ProvinceId equals lp.Id
        //                      join f in _context.Offers
        //                      on r.Id equals f.RoomId
        //                      join ra in _context.Ratings
        //                      on f.Id equals ra.OfferId
        //                      where h.NameEn.Contains(filter.search)
        //                      select new HotelInfoViewModel
        //                      {
        //                          HotelId = h.HotelId,
        //                          HotelName = h.NameEn,
        //                          Rating = (float)ra.Rating,
        //                          Location = string.Format("{0}, Thailand", lp.NameEn)
        //                      }).ToList();
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

using Api.Pricex.myDB;
using Api.Pricex.ViewModels;
using Api.Pricex.ViewModels.Dashboard;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Api.Pricex.Repo
{
    public class DashboardRepo
    {
        public pedb_devContext _context { get; }
        public DashboardRepo(pedb_devContext context)
        {
            _context = context;
        }

        public List<TotalOfferHotelViewModel> GetTotalOfferHotel(int hotel_branch_id, DateTime? date_from, DateTime? date_to)
        {
            try
            {
                //  var hotelName = _context.HotelBranches.Where(e => e.Id == hotel_branch_id).FirstOrDefault();

                var totalOfferHotel = new List<TotalOfferHotelViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_total_offer_hotel"; 
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_id", hotel_branch_id);
                    cmd.Parameters.AddWithValue("@input_date_from", date_from);
                    cmd.Parameters.AddWithValue("@input_date_to", date_to);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            totalOfferHotel.Add(new TotalOfferHotelViewModel()
                            {
                                TotalOffer = reader["total_offer"] != DBNull.Value ? Convert.ToInt32(reader["total_offer"]) : 0,
                                TotalAccepted = reader["total_accepted"] != DBNull.Value ? Convert.ToInt32(reader["total_accepted"]) : 0,
                                TotalPaidIncome = reader["total_paid_income"] != DBNull.Value ? Convert.ToInt32(reader["total_paid_income"]) : 0,
                                RoomType = reader["room_type_en"].ToString(),
                                PhotoRoom = string.Format("https://pricex-api.dev.fysvc.com/{0}", reader["path"].ToString()),
                                HotelBranchName = reader["hotel_name"].ToString(),
                                View = reader["view"].ToString(),
                                OfferedPrice = reader["offer_average_price"] != DBNull.Value ? Convert.ToInt32(reader["offer_average_price"]) : 0,
                                FullPrice = reader["room_average_price"] != DBNull.Value ? Convert.ToInt32(reader["room_average_price"]) : 0
                            });
                        }
                    }
                    return totalOfferHotel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DashboardViewModel> GetPendingStatus(string duration, DateTime? calendar, int hotel_branch_id)
        {
            try
            {
                var pending = new List<DashboardViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_pending_dashboard";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_calendar", calendar);
                    cmd.Parameters.AddWithValue("@input_duration", duration);
                    cmd.Parameters.AddWithValue("@input_hotel_branch_id", hotel_branch_id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pending.Add(new DashboardViewModel()
                            {
                                Id = reader["offer_id"] != DBNull.Value ? Convert.ToInt32(reader["offer_id"]) : 0,
                                OfferDate = reader.IsDBNull("created_at") ? (DateTime?)null : reader.GetDateTime("created_at"),
                                RoomType = reader["room_type_th"].ToString(),
                                TotalRooms = reader["total_rooms"] != DBNull.Value ? Convert.ToInt32(reader["total_rooms"]) : 0,
                                TotalAdults = reader["total_adults"] != DBNull.Value ? Convert.ToInt32(reader["total_adults"]) : 0,
                                CheckIn = reader["check_in"].ToString(),
                                CheckOut = reader["check_out"].ToString(),
                                Name = reader["customer_name"].ToString(),
                                Picture = reader["user_picture"].ToString(),
                                Rating = reader["rating"] != DBNull.Value ? Convert.ToInt32(reader["rating"]) : 0,
                                OfferPrice = reader["offer"].ToString(),
                                FullPrice = reader["full_price"].ToString(),
                                WaitingTime = reader["waiting_time"] != DBNull.Value ? Convert.ToInt32(reader["waiting_time"]) : 0,
                                StatusId = reader["status_id"] != DBNull.Value ? Convert.ToInt32(reader["status_id"]) : 0,
                            });
                        }
                    }
                    return pending;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DashboardViewModel> GetAcceptedStatus(string search, string status, int hotel_branch_id)
        {
            try
            {
                var pending = new List<DashboardViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_accepted_dashboard";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@input_token", token);
                    cmd.Parameters.AddWithValue("@input_search", search);
                    cmd.Parameters.AddWithValue("@input_status", status);
                    cmd.Parameters.AddWithValue("@input_hotel_branch_id", hotel_branch_id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pending.Add(new DashboardViewModel()
                            {
                                Id = reader["offer_id"] != DBNull.Value ? Convert.ToInt32(reader["offer_id"]) : 0,
                                AcceptDate = reader.IsDBNull("accepted_at") ? (DateTime?)null : reader.GetDateTime("accepted_at"),
                                PaidDate = reader.IsDBNull("paid_at") ? (DateTime?)null : reader.GetDateTime("paid_at"),
                                RoomType = reader["room_type_en"].ToString(),
                                TotalRooms = reader["total_rooms"] != DBNull.Value ? Convert.ToInt32(reader["total_rooms"]) : 0,
                                TotalAdults = reader["total_adults"] != DBNull.Value ? Convert.ToInt32(reader["total_adults"]) : 0,
                                CheckIn = reader["check_in"].ToString(),
                                CheckOut = reader["check_out"].ToString(),
                                Name = reader["customer_name"].ToString(),
                                Picture = reader["user_picture"].ToString(),
                                Rating = reader["rating"] != DBNull.Value ? Convert.ToInt32(reader["rating"]) : 0,
                                OfferPrice = reader["offer"].ToString(),
                                FullPrice = reader["full_price"].ToString(),
                                Status = reader["status"].ToString(),
                                StatusId = reader["status_id"] != DBNull.Value ? Convert.ToInt32(reader["status_id"]) : 0,
                            });
                        }
                    }
                    return pending;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DashboardViewModel> GetCheckInStatus(string search, string status, int hotel_branch_id)
        {
            try
            {
                var pending = new List<DashboardViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_check_in_dashboard";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_search", search);
                    cmd.Parameters.AddWithValue("@input_status", status);
                    cmd.Parameters.AddWithValue("@input_hotel_branch_id", hotel_branch_id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pending.Add(new DashboardViewModel()
                            {
                                Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                                AcceptDate = reader.IsDBNull("accepted_at") ? (DateTime?)null : reader.GetDateTime("accepted_at"),
                                PaidDate = reader.IsDBNull("paid_at") ? (DateTime?)null : reader.GetDateTime("paid_at"),
                                RoomType = reader["room_type_en"].ToString(),
                                TotalRooms = reader["total_rooms"] != DBNull.Value ? Convert.ToInt32(reader["total_rooms"]) : 0,
                                TotalAdults = reader["total_adults"] != DBNull.Value ? Convert.ToInt32(reader["total_adults"]) : 0,
                                CheckIn = reader["check_in"].ToString(),
                                CheckOut = reader["check_out"].ToString(),
                                Name = reader["customer_name"].ToString(),
                                Picture = reader["user_picture"].ToString(),
                                Rating = reader["rating"] != DBNull.Value ? Convert.ToInt32(reader["rating"]) : 0,
                                OfferPrice = reader["offer"].ToString(),
                                FullPrice = reader["full_price"].ToString(),
                                Status = reader["status"].ToString(),
                                StatusId = reader["status_id"] != DBNull.Value ? Convert.ToInt32(reader["status_id"]) : 0,
                            });
                        }
                    }
                    return pending;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

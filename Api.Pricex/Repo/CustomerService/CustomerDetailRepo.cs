using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Util;
using Api.Pricex.ViewModels.CustomerService;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Api.Pricex.Repo.CustomerService
{
    public class CustomerDetailRepo
    {
        public pedb_devContext _context { get; }
        public CustomerDetailRepo(pedb_devContext context)
        {
            _context = context;
        }

        public List<CustomerDetailViewModel> GetCustomerDetailByFilter(FilterCustomer filter)
        {
            try
            {
                var model = new List<CustomerDetailViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_customer_detail_customer_service";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //if (filter.keyword == null)
                    //{
                    //    filter.keyword = "";
                    //}
                    cmd.Parameters.AddWithValue("@input_search_by", filter.search_by);
                    cmd.Parameters.AddWithValue("@input_keyword", filter.keyword);
                    cmd.Parameters.AddWithValue("@input_id", 0);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new CustomerDetailViewModel()
                            {
                                BookingId = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0,
                                OfferId = reader["offer_id"] != DBNull.Value ? Convert.ToInt32(reader["offer_id"]) : 0,
                                MemberId = reader["member_id"] != DBNull.Value ? Convert.ToInt32(reader["member_id"]) : 0,
                                GuestName = reader["guest_name"].ToString(),
                                CreditCardNumber = reader["card_number"].ToString(),
                                HotelName = reader["hotel_name"].ToString(),
                                CheckIn = reader.IsDBNull("checkedin_at") ? "" : Utility.convertToDateFormatString(reader.GetDateTime("checkedin_at").ToString()),
                                CheckOut = reader.IsDBNull("checkedout_at") ? "" : Utility.convertToDateFormatString(reader.GetDateTime("checkedout_at").ToString()),
                                EmailHotel = reader["email"].ToString(),
                                PhoneHotel = reader["phone_number"].ToString(),
                            });
                        }
                    }

                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BookingDetail> GetCustomerDetail(int booking_id)
        {
            try
            {
                var model = new List<BookingDetail>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_customer_detail_customer_service";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_id", booking_id);
                    cmd.Parameters.AddWithValue("@input_search_by", "");
                    cmd.Parameters.AddWithValue("@input_keyword", "");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new BookingDetail()
                            {
                                BookingId = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0,
                                OfferId = reader["offer_id"] != DBNull.Value ? Convert.ToInt32(reader["offer_id"]) : 0,
                                MemberId = reader["member_id"] != DBNull.Value ? Convert.ToInt32(reader["member_id"]) : 0,
                                GuestName = reader["guest_name"].ToString(),
                                GuestPhone = reader["guest_phone"] != DBNull.Value ? Convert.ToInt32(reader["guest_phone"]) : 0,
                                NumberOfAdult = reader["total_adults"] != DBNull.Value ? Convert.ToInt32(reader["total_adults"]) : 0,
                                NumberOfChidren = reader["total_children"] != DBNull.Value ? Convert.ToInt32(reader["total_children"]) : 0,
                                NumberOfNight = reader["total_days"] != DBNull.Value ? Convert.ToInt32(reader["total_days"]) : 0,
                                NumberOfRoom = reader["total_rooms"] != DBNull.Value ? Convert.ToInt32(reader["total_rooms"]) : 0,
                                HotelName = reader["hotel_name"].ToString(),
                                CheckIn = reader.IsDBNull("checkedin_at") ? "" : Utility.convertToDateFormatString(reader.GetDateTime("checkedin_at").ToString()),
                                CheckOut = reader.IsDBNull("checkedout_at") ? "" : Utility.convertToDateFormatString(reader.GetDateTime("checkedout_at").ToString()),
                                EmailHotel = reader["email"].ToString(),
                                PhoneHotel = reader["phone_number"].ToString(),
                                CancellationPolicy = reader["cancellation_policy"].ToString(),
                                RoomType = reader["room_type_en"].ToString(),
                            });
                        }
                    }

                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

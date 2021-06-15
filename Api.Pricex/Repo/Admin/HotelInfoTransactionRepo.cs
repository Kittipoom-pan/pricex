using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.Util;
using Api.Pricex.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Api.Pricex.Repo.Admin
{
    public class HotelInfoTransactionRepo
    {
        public pedb_devContext _context { get; }

        public HotelInfoTransactionRepo(pedb_devContext context)
        {
            _context = context;
        }

        public List<HotelInfoTransactionViewModel> GetHotelInfoTransaction(Filter filter)
        {
            try
            {
                var model = new List<HotelInfoTransactionViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_hotel_transaction";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_duration", filter.duration);
                    cmd.Parameters.AddWithValue("@input_calendar", filter.calendar);
                    cmd.Parameters.AddWithValue("@input_status", filter.status);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new HotelInfoTransactionViewModel()
                            {
                                BookingId = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0,
                                OfferId = reader["offer_id"] != DBNull.Value ? Convert.ToInt32(reader["offer_id"]) : 0,
                                HotelName = reader["name_en"].ToString(),
                                CustomerName = reader["customer_name"].ToString(),
                                Arrival = reader.IsDBNull("arrival") ? "" : Utility.convertToDateTimeFormatString(reader.GetDateTime("arrival").ToString()),
                                Departure = reader.IsDBNull("departure") ? "" : Utility.convertToDateTimeFormatString(reader.GetDateTime("departure").ToString()),
                                RoomNight = reader["room_night"] != DBNull.Value ? Convert.ToInt32(reader["room_night"]) : 0,
                                RoomType = reader["room_type_en"].ToString(),
                                OriginalRate = reader["room_average_price"] != DBNull.Value ? Convert.ToDecimal(reader["room_average_price"]) : 0,
                                OfferRate = reader["offer_average_price"] != DBNull.Value ? Convert.ToDecimal(reader["offer_average_price"]) : 0,
                                //OfferRateDate = reader.IsDBNull("offer_rate_date") ? (DateTime?)null : reader.GetDateTime("offer_rate_date"),
                                OfferRateDate = reader.IsDBNull("offer_rate_date") ? "" : Utility.convertToDateTimeFormatString(reader.GetDateTime("offer_rate_date").ToString()),
                                WaitingTime = reader["waiting_time"] != DBNull.Value ? Convert.ToInt32(reader["waiting_time"]) : 0,
                                OfferExpiredAt = reader.IsDBNull("offer_expired_at") ? "" : Utility.convertToDateTimeFormatString(reader.GetDateTime("offer_expired_at").ToString()),
                                Status = reader["status"].ToString(),
                                Position = reader["position"] != DBNull.Value ? reader["position"].ToString() : "",
                                GeneralInformation = reader["responsibilities"] != DBNull.Value ? reader["responsibilities"].ToString() : "",
                                Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "",
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : "",
                                AlternativeEmail = reader["alternative_email"] != DBNull.Value ? reader["alternative_email"].ToString() : "",
                                //CreateAt = Convert.ToDateTime(reader["created_at"])
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

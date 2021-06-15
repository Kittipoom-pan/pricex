using Api.Pricex.myDB;
using Api.Pricex.Util;
using Api.Pricex.ViewModels;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class BookingSummaryRepo
    {
        public pedb_devContext _context { get; }
        public BookingSummaryRepo(pedb_devContext context)
        {
            _context = context;
        }

        public List<BookingSummaryViewModel> GetBookingSummary(string search, string search_type, int status,DateTime? date_from, DateTime? date_to)
        {
            try
            {
                var totalOfferHotel = new List<BookingSummaryViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_booking_summary";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_search", search);
                    cmd.Parameters.AddWithValue("@input_search_type", search_type);
                    cmd.Parameters.AddWithValue("@input_status", status);
                    cmd.Parameters.AddWithValue("@input_date_from", date_from);
                    cmd.Parameters.AddWithValue("@input_date_to", date_to);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            totalOfferHotel.Add(new BookingSummaryViewModel()
                            {
                                //BookingNo = reader["booking_id"] != DBNull.Value ? Convert.ToInt32(reader["booking_id"]) : 0,
                                OfferId = reader["offer_id"] != DBNull.Value ? Convert.ToInt32(reader["offer_id"]) : 0,
                                AcceptDate = reader.IsDBNull("accepted_at") ? "" : Utility.convertToDateTimeFormatString(reader.GetDateTime("accepted_at").ToString()),
                                OfferDate = reader.IsDBNull("created_at") ? "" : Utility.convertToDateTimeFormatString(reader.GetDateTime("created_at").ToString()),
                                RoomType = reader["room_type_en"].ToString(),
                                TotalRooms = reader["total_rooms"] != DBNull.Value ? Convert.ToInt32(reader["total_rooms"]) : 0,
                                RoomNight = reader["total_days"] != DBNull.Value ? Convert.ToInt32(reader["total_days"]) : 0,
                                CheckIn = reader.IsDBNull("check_in_date") ? "" : Utility.convertToDateFormatString(reader.GetDateTime("check_in_date").ToString()),
                                CheckInTime = reader.IsDBNull("check_in_time") ? "" : reader.GetDateTime("check_in_time").ToString("hh:mm:ss"),
                                //CheckIn = string.Format("{0} {1}", reader.GetDateTime("check_in_date").ToString("dd/MM/yyyy"), reader.GetDateTime("check_in_time").ToString("hh:mm:ss")),
                                //CheckOut = string.Format("{0} {1}", reader.GetDateTime("check_out_date").ToString("dd/MM/yyyy"), reader.GetDateTime("check_out_time").ToString("hh:mm:ss")),
                                CheckOut = reader.IsDBNull("check_out_date") ? "" : Utility.convertToDateFormatString(reader.GetDateTime("check_out_date").ToString()),
                                CheckOutTime = reader.IsDBNull("check_out_time") ? "" : reader.GetDateTime("check_out_time").ToString("hh:mm:ss"),
                                Name = reader["customer_name"].ToString(),
                                OfferPrice = reader["offer"].ToString(),
                                FullPrice = reader["full_price"].ToString(),
                                Status = reader["status"].ToString(),
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

        public async Task<Offers> GetOfferHotel(int offer_id) => _context.Offers.Where(e => e.Id == offer_id && e.StatusId == 1).FirstOrDefault();
        public async Task<RoomPrices> GetRoomPrice(int room_id) => _context.RoomPrices.Where(e => e.RoomId == room_id && e.IsActive == 1).FirstOrDefault();

        public async Task<string> AcceptOffer(int offer_id)
        {
            var offer = await GetOfferHotel(offer_id);
            
            if(offer == null)
            {
                return null;
            }
            else
            {
                offer.AcceptedAt = DateTime.Now;
                offer.PaymentExpiredAt = DateTime.Now.AddDays(1);
                offer.StatusId = 2;

                _context.Offers.Update(offer);
                _context.SaveChanges();

                var booking = new Bookings()
                {
                    OfferId = offer.Id,
                    UserId = offer.UserId,
                    //CreatedAt = DateTime.Now
                };

                _context.Bookings.Add(booking);
                _context.SaveChanges();

                var room = await GetRoomPrice(offer.RoomId);
                if (room == null)
                {
                    return null;
                }
                else
                {
                    room.RemainingQuota = room.Quota - offer.TotalRooms;
                    room.UpdatedAt = DateTime.Now;

                    _context.Offers.Update(offer);
                    _context.SaveChanges();
                }
            }

            return "Accept offer succesfully.";
        }

        public async Task<string> RejectOffer(int offer_id)
        {
            var offer = await GetOfferHotel(offer_id);

            if (offer == null)
            {
                return null;
            }
            else
            {
                offer.RejectedAt = DateTime.Now;
                offer.StatusId = 3;

                _context.Offers.Update(offer);
                _context.SaveChanges();
            }

            return "Reject offer succesfully.";
        }
    }
}

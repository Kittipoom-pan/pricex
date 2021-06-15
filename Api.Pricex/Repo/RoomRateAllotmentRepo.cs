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
    public class RoomRateAllotmentRepo
    {
        private pedb_devContext dataContext;
        private readonly MySqlConnection _con;
        public RoomRateAllotmentRepo(pedb_devContext dataContext)
        {
            this.dataContext = dataContext;
            _con = new MySqlConnection(dataContext.Database.GetDbConnection().ConnectionString);
        }

        public async Task<List<RoomViewModel>> Getroom(int hotelBranchId, string lang)
        {
            if (lang == "EN")
            {
                return await (from r in dataContext.Rooms
                              where r.HotelBranchId == hotelBranchId
                              select new RoomViewModel() { room = r.NameEn, id = r.Id }).ToListAsync();
            }
            else
            {
                return await (from r in dataContext.Rooms
                              where r.HotelBranchId == hotelBranchId
                              select new RoomViewModel() { room = r.NameTh, id = r.Id }).ToListAsync();
            }
        }

        public async Task<List<RoomRateAllotmentViewModel>> GetRoomrateAllotment(int hotel_branch_id, int room_id, string lang, DateTime? date_from, DateTime? date_to)
        {
            try
            {
                var roomRateAllotments = new List<RoomRateAllotmentViewModel>();

                MySqlConnection conn = new MySqlConnection(dataContext.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_roomrate_allotment";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pHotelBrancdId", hotel_branch_id);
                    cmd.Parameters.AddWithValue("@pRoomId", room_id);
                    cmd.Parameters.AddWithValue("@pLang", lang);
                    cmd.Parameters.AddWithValue("@pDateFrom", date_from);
                    cmd.Parameters.AddWithValue("@pDateTo", date_to);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomRateAllotments.Add(new RoomRateAllotmentViewModel()
                            {
                                RoomId = reader["room_id"] != DBNull.Value ? Convert.ToInt32(reader["room_id"]) : 0,
                                HoteBranchId = reader["hotel_branch_id"] != DBNull.Value ? Convert.ToInt32(reader["hotel_branch_id"]) : 0,
                                StatusId = reader["is_active"] != DBNull.Value ? Convert.ToInt32(reader["is_active"]) : 0,
                                Room = reader["room_name"].ToString(),
                                Month = reader["date_month"].ToString(),
                                Date = Utility.convertToDateFormatString(reader.GetDateTime("room_date").ToString()),
                                RoomForSale = reader["quota"] != DBNull.Value ? Convert.ToInt32(reader["quota"]) : 0,
                                NetBook = reader["net_book"] != DBNull.Value ? Convert.ToInt32(reader["net_book"]) : 0,
                                Price = reader["price"] != DBNull.Value ? Convert.ToInt32(reader["price"]) : 0,
                                PriceMin = reader["price_min"] != DBNull.Value ? Convert.ToInt32(reader["price_min"]) : 0,
                                PriceMax = reader["price_max"] != DBNull.Value ? Convert.ToInt32(reader["price_max"]) : 0,
                                CreateAt = Utility.convertToDateTimeFormatString(reader.GetDateTime("created_at").ToString()),
                            });
                        }
                    }
                    conn.Close();
                    return roomRateAllotments;
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }

        public async Task AddRoomRate(RoomRateAllotment roomRate, int hotel_branch_id)
        {
            foreach (var room in roomRate.Room)
            {
                foreach (DateTime day in Utility.EachCalendarDay(roomRate.DateFrom, roomRate.DateTo))
                {
                    var roomrateallotment = new RoomRateAllotment()
                    {
                        RoomId = room.id,
                        HotelBranchId = hotel_branch_id,
                        DateFrom = day,
                        Amount = roomRate.Amount,
                        Price = roomRate.Price,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "",
                    };
                    dataContext.RoomRateAllotment.Add(roomrateallotment);
                    dataContext.SaveChanges();
                }
            }
        }

        public async Task<bool> CreateRoomRate(RoomRateAllotment roomRate, int hotel_branch_id)
        {
            bool success = false;

            try
            {
                if (roomRate.Applicable == "every_day")
                {
                    foreach (var room in roomRate.Room)
                    {
                        foreach (DateTime day in Utility.EachCalendarDay(roomRate.DateFrom, roomRate.DateTo))
                        {
                            var roomPrices = new RoomPrices()
                            {
                                RoomId = room.id,
                                HotelBranchId = hotel_branch_id,
                                RoomDate = day,
                                Quota = roomRate.Amount,
                                Price = roomRate.Price,
                                CreatedAt = DateTime.Now,
                                CreatedBy = "",
                                IsActive = 1
                            };
                            dataContext.RoomPrices.Add(roomPrices);
                            dataContext.SaveChanges();

                            success = true;
                        }
                    }
                    return success;
                }
                else if (roomRate.Applicable == "custom")
                {
                    //var result = await GetroomPrice(roomRate.RoomId);

                    //foreach (var day in result)
                    //{
                    // validate day 
                    //}

                    //if (result.RoomDate.Date == roomRate.DateFrom.Date)
                    //{
                    //    return "Duplicate rooms and dates";
                    //}

                    await AddRoomRate(roomRate, hotel_branch_id);

                    if (roomRate.DayCustom != null)
                    {
                        foreach (var room in roomRate.Room)
                        {
                            foreach (var day in roomRate.DayCustom)
                            {
                                DataTable table = new DataTable();
                                using (MySqlCommand cmd = new MySqlCommand())
                                {
                                    cmd.Connection = _con;
                                    _con.Open();

                                    cmd.CommandText = "insert_room_rate";
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("@pHotelBranchID", hotel_branch_id);
                                    cmd.Parameters.AddWithValue("@pRoomArrayID", room.id);
                                    cmd.Parameters.AddWithValue("@pDay", day.id);
                                    cmd.Parameters.AddWithValue("@pPrice", roomRate.Price);
                                    cmd.Parameters.AddWithValue("@pQuota", roomRate.Amount);
                                    cmd.Parameters.AddWithValue("@pApplicable", roomRate.Applicable);

                                    using (MySqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            table.Load(reader);
                                        }
                                    }

                                    if (table != null && table.Rows.Count > 0)
                                    {
                                        success = true;
                                        _con.Close();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        await AddRoomRate(roomRate, hotel_branch_id);

                        foreach (var room in roomRate.Room)
                        {
                            DataTable table = new DataTable();
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                cmd.Connection = _con;
                                _con.Open();

                                cmd.CommandText = "insert_room_rate";
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@pHotelBranchID", hotel_branch_id);
                                cmd.Parameters.AddWithValue("@pRoomArrayID", room.id);
                                cmd.Parameters.AddWithValue("@pDay", 0);
                                cmd.Parameters.AddWithValue("@pPrice", roomRate.Price);
                                cmd.Parameters.AddWithValue("@pQuota", roomRate.Amount);
                                cmd.Parameters.AddWithValue("@pApplicable", roomRate.Applicable);

                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        table.Load(reader);
                                    }
                                }

                                if (table != null && table.Rows.Count > 0)
                                {
                                    success = true;
                                    _con.Close();
                                }
                            }

                        }
                    }
                }
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditRoomRate(RoomRateAllotment roomRate, int hotel_branch_id)
        {
            bool success = false;

            List<int> roomID = new List<int>();
            List<int> dayID = new List<int>();

            foreach (var room in roomRate.Room)
            {
                roomID.Add(room.id);
            }

            if (roomRate.DayCustom != null)
            {
                foreach (var day in roomRate.DayCustom)
                {
                    dayID.Add(day.id);
                }
            }

            var arrayRoomId = string.Join(",", roomID);
            var arrayDayId = string.Join(",", dayID);

            try
            {
                MySqlConnection conn = new MySqlConnection(dataContext.Database.GetDbConnection().ConnectionString);
                DataTable table = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.CommandText = "update_room_rate";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pHotelBranchID", hotel_branch_id);
                    cmd.Parameters.AddWithValue("@pRoomArrayID", arrayRoomId);
                    cmd.Parameters.AddWithValue("@pDay", arrayDayId);
                    cmd.Parameters.AddWithValue("@pPrice", roomRate.Price);
                    cmd.Parameters.AddWithValue("@pQuota", roomRate.Amount);
                    cmd.Parameters.AddWithValue("@pDateFrom", roomRate.DateFrom);
                    cmd.Parameters.AddWithValue("@pDateTo", roomRate.DateTo);
                    cmd.Parameters.AddWithValue("@pDateNow", DateTime.Now);
                    cmd.Parameters.AddWithValue("@pApplicable", roomRate.Applicable);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            table.Load(reader);
                        }
                    }

                    //if (table != null && table.Rows.Count > 0)
                    //{
                    success = true;
                    conn.Close();
                    //}
                }
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditPriceRate(RoomRateAllotment roomRate, int hotel_branch_id)
        {
            bool success = false;
            List<int> roomID = new List<int>();
            List<int> dayID = new List<int>();

            foreach (var room in roomRate.Room)
            {
                roomID.Add(room.id);
            }

            if (roomRate.DayCustom != null)
            {
                foreach (var day in roomRate.DayCustom)
                {
                    dayID.Add(day.id);
                }
            }

            var arrayRoomId = string.Join(",", roomID);
            var arrayDayId = string.Join(",", dayID);
            try
            {
                MySqlConnection conn = new MySqlConnection(dataContext.Database.GetDbConnection().ConnectionString);
                DataTable table = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.CommandText = "update_room_rate_price_range";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pHotelBranchID", hotel_branch_id);
                    cmd.Parameters.AddWithValue("@pRoomArrayID", arrayRoomId);
                    cmd.Parameters.AddWithValue("@pDay", arrayDayId);
                    cmd.Parameters.AddWithValue("@pPriceMin", roomRate.PriceMin);
                    cmd.Parameters.AddWithValue("@pPriceMax", roomRate.PriceMax);
                    cmd.Parameters.AddWithValue("@pDateFrom", roomRate.DateFrom);
                    cmd.Parameters.AddWithValue("@pDateTo", roomRate.DateTo);
                    cmd.Parameters.AddWithValue("@pDateNow", DateTime.Now);
                    cmd.Parameters.AddWithValue("@pApplicable", roomRate.Applicable);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            table.Load(reader);
                        }
                    }

                    //if (table != null && table.Rows.Count > 0)
                    //{
                    success = true;
                    conn.Close();
                    //}
                }
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteRate(RoomRateAllotment roomRate, int hotel_branch_id)
        {
            bool success = false;

            //int[] dayId = new int[] { };
            //List<int> arrayInt = new List<int>();

            List<int> roomID = new List<int>();
            List<int> dayID = new List<int>();

            foreach (var room in roomRate.Room)
            {
                roomID.Add(room.id);
            }

            if (roomRate.DayCustom != null)
            {
                foreach (var day in roomRate.DayCustom)
                {
                    dayID.Add(day.id);
                }
                //foreach (var day in roomRate.DayCustom)
                //{
                //    for (; day.id != 0; day.id /= 10)
                //        arrayInt.Add(day.id % 10);

                //    dayId = arrayInt.ToArray();
                //    Array.Reverse(dayId);
                //}
            }
            var arrayRoomId = string.Join(",", roomID);
            var arrayDayId = string.Join(",", dayID);

            MySqlConnection conn = new MySqlConnection(dataContext.Database.GetDbConnection().ConnectionString);
            DataTable table = new DataTable();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "delete_room_rate";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pHotelBranchID", hotel_branch_id);
                cmd.Parameters.AddWithValue("@pRoomArrayID", arrayRoomId);
                cmd.Parameters.AddWithValue("@pDay", arrayDayId);
                cmd.Parameters.AddWithValue("@pDateFrom", roomRate.DateFrom);
                cmd.Parameters.AddWithValue("@pDateTo", roomRate.DateTo);
                cmd.Parameters.AddWithValue("@pDateNow", DateTime.Now);
                cmd.Parameters.AddWithValue("@pApplicable", roomRate.Applicable);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        table.Load(reader);
                    }
                }

                success = true;
                conn.Close();
            }
            return success;
        }

        public static int[] ConvertInttoArrayInt(int n)
        {
            if (n == 0) return new int[1] { 0 };

            var digits = new List<int>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }
    }
}

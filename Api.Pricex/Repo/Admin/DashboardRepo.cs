using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.ViewModels;
using Api.Pricex.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Api.Pricex.Repo.Admin
{
    public class DashboardRepo
    {
        public pedb_devContext _context { get; }

        public DashboardRepo(pedb_devContext context)
        {
            _context = context;
        }

        public List<DashboardAdminViewModel> GetDashboard(Filter filter,int user_id)
        {
            try
            {
                var dashboard = new List<DashboardAdminViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.CommandText = "get_dashboard_admin"; // The name of the Stored Proc
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@input_calendar", filter.calendar);
                        cmd.Parameters.AddWithValue("@input_duration", filter.duration);
                        cmd.Parameters.AddWithValue("@input_search", filter.search);
                        cmd.Parameters.AddWithValue("@input_hotel_type", filter.hotel_type);
                        cmd.Parameters.AddWithValue("@input_status", filter.status);
                        //cmd.Parameters.AddWithValue("@input_user_id", user_id);

                        cmd.Parameters.AddWithValue("@PageCount", MySqlDbType.Int32);
                        cmd.Parameters["@PageCount"].Direction = ParameterDirection.Output; 

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                            dashboard.Add(new DashboardAdminViewModel()
                            {
                                HotelId = reader["hotel_id"] != DBNull.Value ? Convert.ToInt32(reader["hotel_id"]) : 0,
                                HotelName = reader["hotel_name"].ToString(),
                                TotalRequest = reader["total_request"] != DBNull.Value ? Convert.ToInt32(reader["total_request"]) : 0,
                                Pending = reader["pending"] != DBNull.Value ? Convert.ToInt32(reader["pending"]) : 0,
                                Approved = reader["approved"] != DBNull.Value ? Convert.ToInt32(reader["approved"]) : 0,
                                Rejected = reader["rejected"] != DBNull.Value ? Convert.ToInt32(reader["rejected"]) : 0,
                                Expire = reader["expire"] != DBNull.Value ? Convert.ToInt32(reader["expire"]) : 0,
                                //CreateAt = Convert.ToDateTime(reader["created_at"])
                        });
                            }
                        }
                        Object obj = cmd.Parameters["@PageCount"].Value;
                        var lParam = (Int32)obj;
                        return dashboard;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DashboardTotalOfferViewModel> GetDashboardTotalOffer(DateTime? date_to, DateTime? date_from)
        {
            try
            {
                var dashboard = new List<DashboardTotalOfferViewModel>();

                MySqlConnection conn = new MySqlConnection(_context.Database.GetDbConnection().ConnectionString);

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "get_total_offer_dashboard_admin"; 
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@input_date_from", date_to);
                    cmd.Parameters.AddWithValue("@input_date_to", date_from);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dashboard.Add(new DashboardTotalOfferViewModel()
                            {
                                TotalOffer = reader["total_offer"] != DBNull.Value ? Convert.ToInt32(reader["total_offer"]) : 0,
                                TotalWaitingForApproval = reader["total_waiting_approval"] != DBNull.Value ? Convert.ToInt32(reader["total_waiting_approval"]) : 0,
                                TotalApproved = reader["total_approved"] != DBNull.Value ? Convert.ToInt32(reader["total_approved"]) : 0,
                            });
                        }
                    }

                    return dashboard;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

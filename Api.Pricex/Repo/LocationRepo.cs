using Api.Pricex.Interface;
using Api.Pricex.myDB;
using Api.Pricex.ViewModels;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class LocationRepo : ILocation
    {
        private readonly pedb_devContext _dataContext;

        public LocationRepo(pedb_devContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<DistrictViewModel>> GetDistrict(string lang, int provinceId)
        {
            var districts = new List<DistrictViewModel>();

            MySqlConnection conn = new MySqlConnection(_dataContext.Database.GetDbConnection().ConnectionString);

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "get_district";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pLang", lang);
                cmd.Parameters.AddWithValue("@pProvinceId", provinceId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        districts.Add(new DistrictViewModel()
                        {
                            id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                            name = reader["district_name"].ToString(),
                        });
                    }
                }
                conn.Close();
                return districts;
            }
        }

        public async Task<List<ProvinceViewModel>> GetProvince(string lang)
        {
            var provinces = new List<ProvinceViewModel>();

            MySqlConnection conn = new MySqlConnection(_dataContext.Database.GetDbConnection().ConnectionString);

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "get_province";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pLang", lang);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        provinces.Add(new ProvinceViewModel()
                        {
                            id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                            name = reader["province_name"].ToString(),
                        });
                    }
                }
                conn.Close();
                return provinces;
            }
        }
        
        public async Task<List<SubDistrictViewModel>> GetSubDistrict(string lang, int districtId)
        {
            var subDistricts = new List<SubDistrictViewModel>();

            MySqlConnection conn = new MySqlConnection(_dataContext.Database.GetDbConnection().ConnectionString);

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "get_sub_district";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pLang", lang);
                cmd.Parameters.AddWithValue("@pDistrictId", districtId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subDistricts.Add(new SubDistrictViewModel()
                        {
                            id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                            name = reader["subdistrict_name"].ToString(),
                            postcode = reader["zip_code_suffix"].ToString(),
                        });
                    }
                }
                conn.Close();
                return subDistricts;
            }
        }
    }
}

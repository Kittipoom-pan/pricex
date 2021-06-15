using Api.Pricex.Models;
using Api.Pricex.myDB;
using Api.Pricex.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class AuthRepo
    {
        private pedb_devContext dataContext;
        private readonly IConfiguration _config;

        public AuthRepo(pedb_devContext dataContext, IConfiguration config)
        {
            this.dataContext = dataContext;
            _config = config;
        }

        public List<UserAccessViewModels> Login(UserViewModels user)
        {
            var result = dataContext.User.Where(p => p.Email == user.Username).FirstOrDefault();
            var encodePassword = ComputeSha256Hash(user.Password);
            if (result == null)
            {
                return null;
            }
            if (result.Password != encodePassword)
            {
                return null;
            }

            var data = (from u in dataContext.User
                        join g in dataContext.UserGroup
                        on u.Id equals g.UserId
                        join gc in dataContext.UserGroupAccess
                        on g.UserId equals gc.UserId
                        join a in dataContext.UserAccess
                        on gc.UserGroupId equals a.UserGroupId
                        where g.UserId == result.Id
                        select new UserAccessViewModels()
                        {
                            UserId = result.Id,
                            UserGroupId = g.UserGroupId,
                            HotelId = u.HotelId,
                            HotelBranchId = u.HotelBranchId,
                            GroupType = g.GroupType,
                            AccessCode = a.AccessCode,
                            AccessPage = a.AccessPage,
                        }).ToList();
            
            return data;
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task<RegistrationViewModel> Register(UserRegistration user)
        {
            try
            {
                var hotels = new Hotels()
                {
                    NameEn = user.HotelNameEn,
                    NameTh = user.HotelNameTh,
                    CreatedAt = DateTime.Now,
                };

                dataContext.Hotels.Add(hotels);
                dataContext.SaveChanges();

                var hotelBranches = new HotelBranches()
                {
                    HotelId = hotels.Id,
                    NameEn = user.HotelNameEn,
                    NameTh = user.HotelNameTh,
                    Status = 0,
                    CreatedAt = DateTime.Now,
                };

                dataContext.HotelBranches.Add(hotelBranches);
                dataContext.SaveChanges();

                var model = new User()
                {
                    Username = user.Username,
                    HotelId = hotels.Id,
                    HotelBranchId = hotelBranches.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MobileNumber = user.MobileNumber,
                    Position = user.Position,
                    Password = ComputeSha256Hash(user.Password),
                    CreatedAt = DateTime.Now,
                };

                dataContext.User.Add(model);
                dataContext.SaveChanges();

                var term = new TermAndConditionStampRead()
                {
                    UserId = model.Id,
                    TermId = user.TermAndConditionStampRead.TermId,
                    Version = user.TermAndConditionStampRead.Version,
                    ConfirmCheckbox = user.TermAndConditionStampRead.ConfirmCheckbox,
                    ReadFrom = user.TermAndConditionStampRead.ReadFrom,
                    CreatedAt = DateTime.Now,
                };

                dataContext.TermAndConditionStampRead.Add(term);
                dataContext.SaveChanges();

                var response = new RegistrationViewModel()
                {
                    UserId = model.Id,
                    HotelId = hotels.Id,
                    HotelBranchId = hotelBranches.Id,
                    Success = true
                };

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

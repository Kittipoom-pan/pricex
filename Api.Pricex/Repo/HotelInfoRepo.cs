using Api.Pricex.myDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class HotelInfoRepo
    {
        //private readonly pedb_devContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private pedb_devContext dataContext;
        private readonly IConfiguration _config;

        public HotelInfoRepo(pedb_devContext dataContext, IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            this.dataContext = dataContext;
            _config = config;
            this._webHostEnvironment = webHostEnvironment;
            //this._httpContextAccessor = httpContextAccessor;
        }
        public HotelBranches GetHotelBranch(int hotel_id, int hotel_branch_id)
        {
            return dataContext.HotelBranches.SingleOrDefault(e => e.Id == hotel_branch_id && e.HotelId == hotel_id);
        }

        public async Task<(int,string)> AddHotelDetail(HotelBranches hotelBranches, int hotel_id, List<IFormFile> files, int hotel_branch_id, int user_id)
        {
            try
            {
                if (hotel_id == null || hotel_id == 0)
                {
                    return (0, "Don't have hotel id");
                }
                if (files.Count > 20)
                {
                    return (0,"Maximum 20 Files");
                }

                var data = GetHotelBranch(hotel_id, hotel_branch_id);

                if (data == null)
                {
                    var contentType = "";
                    //var json = JsonConvert.SerializeObject(hotelBranches);
                    var hotels = new HotelBranches()
                    {
                        HotelId = hotel_id,
                        UserId = user_id,
                        NameTh = hotelBranches.NameTh,
                        NameEn = hotelBranches.NameEn,
                        AddressTh = hotelBranches.AddressTh,
                        AddressEn = hotelBranches.AddressEn,
                        Email = hotelBranches.Email,
                        PhoneNumber = hotelBranches.PhoneNumber,
                        ProvinceId = hotelBranches.ProvinceId,
                        DistrictId = hotelBranches.DistrictId,
                        SubDistrictId = hotelBranches.SubDistrictId,
                        Lat = hotelBranches.Lat,
                        Lng = hotelBranches.Lng,
                        CreatedBy = hotelBranches.CreatedBy,
                        CheckIn = hotelBranches.CheckIn,
                        CheckOut = hotelBranches.CheckOut,
                        Status = 0,
                        IsAvailable = hotelBranches.IsAvailable
                    };

                    dataContext.HotelBranches.Add(hotels);
                    dataContext.SaveChanges();

                    foreach (var item in hotelBranches.Location_Landmark)
                    {
                        if (string.IsNullOrEmpty(item.Location))
                        {
                            continue;
                        }
                        item.HotelBranchId = hotels.Id;
                        item.CreatedAt = DateTime.Now;

                        dataContext.LocationLandmarks.Add(item);
                        dataContext.SaveChanges();
                    }

                    if(files.Count != 0)
                    {
                        UploadImageRepo upload = new UploadImageRepo(dataContext,_config);
                        var image = upload.UploadMultipleImages(files, "hotel_branch");

                        foreach (var item in files)
                        {
                            contentType = item.ContentType;
                        }

                        foreach (var img in image.Result)
                        {
                            var photo = new Photos()
                            {
                                Filename = img.FileNames,
                                ReferenceId = hotels.Id,
                                Type = "hotel_branch",
                                Path = Path.Combine(img.Paths, img.FileNames),
                                Mime = contentType,
                                DiskType = "local_public"
                            };
                            dataContext.Photos.Add(photo);
                            dataContext.SaveChanges();
                        }
                    }

                    //var user = dataContext.User.Where(e => e.Id == user_id).FirstOrDefault();
                    //if (user != null)
                    //{
                    //    user.HotelBranchId = hotels.Id;

                    //    dataContext.User.Update(user);
                    //    dataContext.SaveChanges();
                    //}

                    return (hotels.Id, "Create hotel branch successfully.");
                }
                else
                {
                    var contentType = "";

                    data.UserId = user_id;
                    data.NameTh = hotelBranches.NameTh;
                    data.NameEn = hotelBranches.NameEn;
                    data.AddressTh = hotelBranches.AddressTh;
                    data.AddressEn = hotelBranches.AddressEn;
                    data.ProvinceId = hotelBranches.ProvinceId;
                    data.Email = hotelBranches.Email;
                    data.PhoneNumber = hotelBranches.PhoneNumber;
                    data.DistrictId = hotelBranches.DistrictId;
                    data.SubDistrictId = hotelBranches.SubDistrictId;
                    data.Lat = hotelBranches.Lat;
                    data.Lng = hotelBranches.Lng;
                    data.UpdatedAt = DateTime.Now;
                    data.CheckIn = hotelBranches.CheckIn;
                    data.CheckOut = hotelBranches.CheckOut;
                    data.IsAvailable = hotelBranches.IsAvailable;

                    dataContext.HotelBranches.Update(data);
                    dataContext.SaveChanges();

                    //var result = dataContext.LocationLandmarks.Where(p => p.HotelBranchId == data.Id).ToList();
                    
                    //result.ForEach(location =>
                    //{
                    //    foreach (var item in hotelBranches.Location_Landmark)
                    //    {
                    //        if (string.IsNullOrEmpty(item.Location))
                    //        {
                    //            continue;
                    //        }
                    //        location.Location = item.Location;
                    //        location.Kilometer = item.Kilometer;
                    //    }

                    //    dataContext.SaveChanges();
                    //});

                    foreach (var item in hotelBranches.Location_Landmark)
                    {
                        if (string.IsNullOrEmpty(item.Location))
                        {
                            continue;
                        }
                        item.HotelBranchId = data.Id;
                        item.CreatedAt = DateTime.Now;

                        dataContext.LocationLandmarks.Add(item);
                        dataContext.SaveChanges();
                    }

                    if (files.Count != 0)
                    {
                        UploadImageRepo upload = new UploadImageRepo(dataContext, _config);
                        var image = upload.UploadMultipleImages(files, "hotel_branch");

                        foreach (var item in files)
                        {
                            contentType = item.ContentType;
                        }

                        foreach (var img in image.Result)
                        {
                            var photo = new Photos()
                            {
                                Filename = img.FileNames,
                                ReferenceId = data.Id,
                                Type = "hotel_branch",
                                //Path = Path.Combine("upload", "image", "hotel_branch", img.FileNames),
                                Path = Path.Combine(img.Paths, img.FileNames),
                                Mime = contentType,
                                DiskType = "local_public"
                            };
                            dataContext.Photos.Add(photo);
                            dataContext.SaveChanges();
                        }
                    }
                    //var user = dataContext.User.Where(e => e.Id == user_id).FirstOrDefault();
                    //if (user != null)
                    //{
                    //    user.HotelBranchId = data.Id;

                    //    dataContext.User.Update(user);
                    //    dataContext.SaveChanges();
                    //}

                    return (data.Id, "Update hotel branch successfully.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HotelPayments> AddPayment(HotelPayments model,int hotel_id, int hotel_branch_id, int user_id)
        {
            try
            {
                var hotelPayment = new HotelPayments
                {
                    UserId = user_id,
                    HotelId = hotel_id,
                    HotelBranchId = hotel_branch_id,
                    BankName = model.BankName,
                    AccountNumber = model.AccountNumber,
                    AccountHolders = model.AccountHolders,
                    BranchName = model.BranchName,
                    BranchCode = model.BranchCode,
                    SwiftCode = model.SwiftCode,
                    PaymentMethod = model.PaymentMethod,
                    //CreatedAt = DateTime.Now()
                };

                dataContext.HotelPayments.Add(hotelPayment);
                dataContext.SaveChanges();

                return hotelPayment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

        public HotelPayments GetPayment(int id)
        {
            // query แบบตัวเดียว
            return dataContext.HotelPayments.SingleOrDefault(e => e.Id == id); 
        }

        public async Task<HotelPayments> EditPayment(HotelPayments hotelPayments, int id)
        {
            var result = GetPayment(id);
            if (result != null)
            {
                result.BankName = hotelPayments.BankName;
                result.AccountNumber = hotelPayments.AccountNumber;
                result.AccountHolders = hotelPayments.AccountHolders;
                result.BranchName = hotelPayments.BranchName;
                result.BranchCode = hotelPayments.BranchCode;
                result.SwiftCode = hotelPayments.SwiftCode;
                result.PaymentMethod = hotelPayments.PaymentMethod;
                result.UpdatedAt = DateTime.Now;

                dataContext.HotelPayments.Update(result);
                dataContext.SaveChanges();
            }
            return result;
        }
    }
}

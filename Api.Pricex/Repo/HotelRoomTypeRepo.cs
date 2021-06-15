using Api.Pricex.myDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class HotelRoomTypeRepo
    {
        private pedb_devContext dataContext;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HotelRoomTypeRepo(pedb_devContext dataContext, IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            this.dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }

        public async Task<Rooms> GetRoomType(int room_id)
        {
            return dataContext.Rooms.SingleOrDefault(e => e.Id == room_id);
        }
       
        public async Task<(int, string)> EditRoomType(Rooms room, int room_id, List<IFormFile> Files)
        {
            try
            {
                if (Files.Count > 20)
                {
                    return (400,"Maximum 20 Files");
                }

                var contentType = "";

                var result = await GetRoomType(room_id);

                if (result != null)
                {
                    if (Files.Count != 0)
                    {
                        UploadImageRepo upload = new UploadImageRepo(dataContext, _config);

                        var image = upload.UploadMultipleImages(Files, "roomtype");
                        if (image.Result != null)
                        {
                            foreach (var item in Files)
                            {
                                contentType = item.ContentType;
                            }

                            foreach (var img in image.Result)
                            {
                                var photo = new Photos()
                                {
                                    Filename = img.FileNames,
                                    ReferenceId = room_id,
                                    Type = "room_type",
                                    //Path = Path.Combine("upload", "image", "room_type", img.FileNames),
                                    Path = Path.Combine(img.Paths, img.FileNames),
                                    Mime = contentType,
                                    DiskType = "local_public"
                                };
                                dataContext.Photos.Add(photo);
                                dataContext.SaveChanges();
                            }
                        }
                    }

                    result.RoomTypeEn = room.NameEn;
                    result.RoomTypeTh = room.NameTh;
                    result.NameEn = room.NameEn;
                    result.NameTh = room.NameTh;
                    result.Detail = room.Detail;
                    result.MaxAdults = room.MaxAdults;
                    result.MaxChildren = room.MaxChildren;
                    result.IsBreakfast = room.IsBreakfast;
                    result.IsRoomOnly = room.IsRoomOnly;
                    result.RoomSize = room.RoomSize;
                    result.ExtraBed = room.ExtraBed;
                    result.View = room.View;
                    result.UpdatedAt = DateTime.Now;

                    dataContext.Rooms.Update(result);
                    dataContext.SaveChanges();
                }

                var roomType = await dataContext.RoomTypes.Where(r => r.Id == result.RoomTypeId).FirstOrDefaultAsync();

                if (roomType != null)
                {
                    roomType.NameEn = room.NameEn;
                    roomType.NameTh = room.NameTh;
                    roomType.UpdatedAt = DateTime.Now;
                }

                dataContext.RoomTypes.Update(roomType);
                dataContext.SaveChanges();

                return (result.Id, "Update room type successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<(int,string)> AddRoomType(Rooms hotelRoomType, int hotel_id, int hotel_branch_id, List<IFormFile> files)
        {
            try
            {
                if (files.Count > 20)
                {
                    return (400,"Maximum 20 Files");
                }

                var contentType = "";

                var roomType = new RoomTypes()
                {
                    NameEn = hotelRoomType.NameEn,
                    NameTh = hotelRoomType.NameTh,
                    CreatedAt = DateTime.Now
                };

                dataContext.RoomTypes.Add(roomType);
                dataContext.SaveChanges();

                var room = new Rooms()
                {
                    HotelId = hotel_id,
                    HotelBranchId = hotel_branch_id,
                    RoomTypeTh = hotelRoomType.NameEn,
                    RoomTypeEn = hotelRoomType.NameTh,
                    NameEn = hotelRoomType.NameEn,
                    NameTh = hotelRoomType.NameTh,
                    Detail = hotelRoomType.Detail,
                    MaxAdults = hotelRoomType.MaxAdults,
                    MaxChildren = hotelRoomType.MaxChildren,
                    IsBreakfast = hotelRoomType.IsBreakfast,
                    IsRoomOnly = hotelRoomType.IsRoomOnly,
                    RoomSize = hotelRoomType.RoomSize,
                    ExtraBed = hotelRoomType.ExtraBed,
                    View = hotelRoomType.View,
                    RoomTypeId = roomType.Id,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "test"
                };

                dataContext.Rooms.Add(room);
                dataContext.SaveChanges();

                if (files.Count > 0)
                {
                    UploadImageRepo upload = new UploadImageRepo(dataContext, _config);
                    var image = upload.UploadMultipleImages(files, "roomtype");

                    foreach (var item in files)
                    {
                        contentType = item.ContentType;
                    }

                    foreach (var imgs in image.Result)
                    {
                        var photo = new Photos()
                        {
                            Filename = imgs.FileNames,
                            ReferenceId = room.Id,
                            Type = "room_type",
                            Path = Path.Combine(imgs.Paths, imgs.FileNames),
                            Mime = contentType,
                            DiskType = "local_public"
                        };

                        dataContext.Photos.Add(photo);
                        dataContext.SaveChanges();
                    }
                }
               
                return (room.Id,"Create room type successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

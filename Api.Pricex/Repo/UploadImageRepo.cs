using Api.Pricex.myDB;
using Api.Pricex.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class UploadImageRepo
    {
        private readonly pedb_devContext _dataContext;
        private readonly IConfiguration _config;

        public UploadImageRepo(pedb_devContext dataContext, IConfiguration config)
        {
            _dataContext = dataContext;
            _config = config;
        }

        public async Task<List<PhotoFileName>> UploadMultipleImages(List<IFormFile> files, string category)
        {
            try
            {
                string fullPath = "";
                List<PhotoFileName> photoView = null;

                if (files.Count > 0)
                {
                    string folderName = Path.Combine("upload", "image", category);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var fileNameArray = new List<String>(); // multiple images case

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    foreach (var formFile in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(formFile.FileName); // unique name
                        // path.combine ใส่ \\ หรือ // ให้เอง 
                        fullPath = Path.Combine(filePath, fileName);

                        if (formFile.Length > 0)
                        {
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                await formFile.CopyToAsync(stream); // อัพโหลดรูปแบบไม่รอ แต่จะใช้ cpu เยอะ แต่ได้ไฟล์ชัว
                            }
                        }

                        fileNameArray.Add(fileName); // multiple images case
                    }

                    photoView = new List<PhotoFileName>();
                    PhotoFileName photoFileName;

                    foreach (var img in fileNameArray)
                    {
                        photoFileName = new PhotoFileName()
                        {
                            FileNames = img,
                            Paths = folderName
                        };

                        photoView.Add(photoFileName);
                    }

                    return photoView; 
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PhotoViewModel> UploadImage(IFormFile files, string page)
        {
            try
            {
                string fullPath = "";
                PhotoViewModel photoView = null;

                if (files.Length > 0)
                {
                    string folderName = Path.Combine("upload", "image", page);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    // Guid ทำให้รูปยาวๆ
                    string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(files.FileName);
                    fullPath = Path.Combine(filePath, fileName);

                    if (files.Length > 0)
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await files.CopyToAsync(stream); // อัพโหลดรูปแบบไม่รอ แต่จะใช้ cpu เยอะ แต่ได้ไฟล์ชัว
                        }
                    }

                    PhotoViewModel photoViewModel = new PhotoViewModel()
                    {
                        FileName = fileName,
                        Path = folderName
                    };

                    return photoViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UploadImageCenter(List<IFormFile> files, string category, int reference_id)
        {
            try
            {
                string contentType = "";
                string fileName = "";
                string fullPath = "";
                List<PhotoFileName> photoView = null;

                if (files.Count > 0)
                {
                    //string folderName = Path.Combine("upload", "image", category);
                    string folderName = Path.Combine("upload");
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var path = Path.Combine(_config.GetValue<string>("Resource:Env"), _config.GetValue<string>("Path:VenderTransactionPath"), folderName);
                    var fileNameArray = new List<PhotoFileName>();

                    //if (!Directory.Exists(path))
                    //{
                    //    Directory.CreateDirectory(path);
                    //}
                    PhotoFileName photoFileName;

                    foreach (var formFile in files)
                    {
                        photoFileName = new PhotoFileName()
                        {
                            FileNames = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(formFile.FileName),
                            Paths = Path.Combine(path, formFile.FileName),
                            ContentType = formFile.ContentType
                        };
                        //fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(formFile.FileName);
                        fullPath = Path.Combine(filePath, photoFileName.FileNames);

                        if (formFile.Length > 0)
                        {
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                await formFile.CopyToAsync(stream);
                            }
                        }

                        fileNameArray.Add(photoFileName);
                    }

                    photoView = new List<PhotoFileName>();

                    foreach (var img in fileNameArray)
                    {
                        var photo = new Photos()
                        {
                            Filename = img.FileNames,
                            ReferenceId = reference_id,
                            Type = category,
                            Path = Path.Combine(folderName, img.FileNames),
                            Mime = img.ContentType,
                            DiskType = "local_public"
                        };
                        _dataContext.Photos.Add(photo);
                        _dataContext.SaveChanges();

                        //photoView.Add(photoFileName);
                    }

                    //return photoView; 
                    return fullPath;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteImage(int reference_id)
        {
            try
            {
                int success = 0;

                var result = _dataContext.Photos.Where(e => e.Id == reference_id).FirstOrDefault();

                if (result == null)
                {
                    return 0;
                }
                string pathUpload = Path.Combine(Directory.GetCurrentDirectory(), result.Path);
                // Check if file exists with its full path    
                if (File.Exists(Path.Combine(pathUpload)))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(pathUpload));

                    if (result != null)
                    {
                        _dataContext.Photos.Remove(result);
                        success = await _dataContext.SaveChangesAsync();
                        return success;
                    }
                }

                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

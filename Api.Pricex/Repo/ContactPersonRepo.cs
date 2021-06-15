using Api.Pricex.myDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class ContactPersonRepo
    {
        private pedb_devContext dataContext;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ContactPersonRepo(pedb_devContext dataContext, IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
            this.dataContext = dataContext;
            this.config = config;
        }

        public ContactPerson GetContactPerson(int id)
        {
            // query แบบตัวเดียว
            return dataContext.ContactPerson.SingleOrDefault(e => e.Id == id);
        }

        public async Task<ContactPerson> AddContactPerson(ContactPerson contactPerson, IFormFile files, int hotel_id, int hotel_branch_id)
        {
            try
            {
                var contentType = "";

                if (files != null)
                {
                    UploadImageRepo uploadImage = new UploadImageRepo(dataContext, config);

                    var img = await uploadImage.UploadImage(files, "contactperson");

                    var models = new ContactPerson()
                    {
                        HotelId = hotel_id,
                        HotelBranchId = hotel_branch_id,
                        PreferName = contactPerson.PreferName,
                        FirstName = contactPerson.FirstName,
                        LastName = contactPerson.LastName,
                        Position = contactPerson.Position,
                        Responsibility = contactPerson.Responsibility,
                        Email = contactPerson.Email,
                        AlternativeEmail = contactPerson.AlternativeEmail,
                        Phone = contactPerson.Phone,
                        Fax = contactPerson.Fax,
                        ProfilePicture = String.Format("{0}/{1}", img.Path, img.FileName),
                        CreatedAt = DateTime.Now
                    };

                    dataContext.ContactPerson.Add(models);
                    dataContext.SaveChanges();

                    return models;
                }
                else
                {
                    var modelContactPerson = new ContactPerson()
                    {
                        HotelId = hotel_id,
                        HotelBranchId = hotel_branch_id,
                        PreferName = contactPerson.PreferName,
                        FirstName = contactPerson.FirstName,
                        LastName = contactPerson.LastName,
                        Position = contactPerson.Position,
                        Responsibility = contactPerson.Responsibility,
                        Email = contactPerson.Email,
                        AlternativeEmail = contactPerson.AlternativeEmail,
                        Phone = contactPerson.Phone,
                        Fax = contactPerson.Fax,
                        CreatedAt = DateTime.Now
                    };

                    dataContext.ContactPerson.Add(modelContactPerson);
                    dataContext.SaveChanges();

                    return modelContactPerson;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContactPerson> EditContactPerson(ContactPerson contactPerson, int id, IFormFile file)
        {
            var result = GetContactPerson(id);
            if (result != null)
            {
                UploadImageRepo upload = new UploadImageRepo(dataContext,config);
                if (file != null)
                {
                    var image = await upload.UploadImage(file, "contactperson");
                    if (!String.IsNullOrEmpty(image.FileName))
                    {
                        result.ProfilePicture = image.FileName;
                    }
                    result.PreferName = contactPerson.PreferName;
                    result.FirstName = contactPerson.FirstName;
                    result.LastName = contactPerson.LastName;
                    result.Position = contactPerson.Position;
                    result.Responsibility = contactPerson.Responsibility;
                    result.Email = contactPerson.Email;
                    result.AlternativeEmail = contactPerson.AlternativeEmail;
                    result.Phone = contactPerson.Phone;
                    result.Fax = contactPerson.Fax;
                    result.UpdatedAt = DateTime.Now;
                    result.ProfilePicture = String.Format("{0}/{1}",image.Path, image.FileName);

                    dataContext.ContactPerson.Update(result);
                    dataContext.SaveChanges();
                }
                else
                {
                    result.PreferName = contactPerson.PreferName;
                    result.FirstName = contactPerson.FirstName;
                    result.LastName = contactPerson.LastName;
                    result.Position = contactPerson.Position;
                    result.Responsibility = contactPerson.Responsibility;
                    result.Email = contactPerson.Email;
                    result.AlternativeEmail = contactPerson.AlternativeEmail;
                    result.Phone = contactPerson.Phone;
                    result.Fax = contactPerson.Fax;
                    result.UpdatedAt = DateTime.Now;

                    dataContext.ContactPerson.Update(result);
                    dataContext.SaveChanges();
                }
            }

            return result;
        }
    }
}

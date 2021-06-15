using Api.Pricex.Interface;
using Api.Pricex.Models;
using Api.Pricex.myDB;
using EmailService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class PartnerRegistrationActionRepo
    {
        public pedb_devContext dataContext { get; }
        private readonly IUserGroup _userGroup;
        private readonly IEmailSender _emailSender;
        public PartnerRegistrationActionRepo(pedb_devContext context, IUserGroup userGroup, IEmailSender emailSender)
        {
            dataContext = context;
            _userGroup = userGroup;
            _emailSender = emailSender;
        }

        public async Task<(bool, string)> RegistrationAction(PartnerRegistrationAction registration)
        {
            try
            {
                //var sendEmail = new Message(new string[] { registration.Email }, "Approved",
                //    string.Format("การลงทะเบียนของท่านเสร็จสมบูรณ์ หมายเลข Hotel Branch ID ของท่านคือ {0}  โปรดใช้ Hotel Branch ID , username, password ของท่านในการเข้าสู่ระบบเสมอ " +
                //    "Link : {1}", registration.HotelBranchId, registration.Link));

                //await _emailSender.SendEmailAsync(sendEmail);

                string message = "";
                bool success = false;

                var user = await _userGroup.GetUserGroup(registration.UserAdminId);
                if (user == null || user.GroupType != "admin")
                {
                    return (false, "Not an administrator");
                }

                var result = await dataContext.User.Where(e => e.Id == registration.UserId).FirstOrDefaultAsync();

                if (result.StatusId == null)
                {
                    result.StatusId = 0;
                }

                if (registration.Action == "approved" && result.StatusId == 0)
                {
                    if (result != null)
                    {
                        result.StatusId = 1;
                        //result.HotelBranchId = registration.HotelBranchId;
                        result.UpdatedAt = DateTime.Now;

                        dataContext.User.Update(result);
                        dataContext.SaveChanges();
                    }

                    var userGroup = new UserGroup
                    {
                        UserId = registration.UserId,
                        GroupType = "vender",
                        CreatedAt = DateTime.Now
                    };

                    dataContext.UserGroup.Add(userGroup);
                    dataContext.SaveChanges();

                    var userGroupAccess = new UserGroupAccess
                    {
                        UserId = registration.UserId,
                        //UserGroupId = userGroup.UserGroupId,
                        UserGroupId = 1,
                        CreatedAt = DateTime.Now
                    };

                    dataContext.UserGroupAccess.Add(userGroupAccess);
                    dataContext.SaveChanges();

                    //var sendEmail = new Message(new string[] { registration.Email }, "Approved", 
                    //    string.Format("การลงทะเบียนของท่านเสร็จสมบูรณ์ หมายเลข Hotel Branch ID ของท่านคือ {0}  โปรดใช้ Hotel Branch ID , username, password ของท่านในการเข้าสู่ระบบเสมอ " +
                    //    "Link : {1}", registration.HotelBranchId, registration.Link));

                    //await _emailSender.SendEmailAsync(sendEmail);

                    success = true;
                    message = "Registration successfully.";
                }
                else if (registration.Action == "rejected" && result.StatusId == 0)
                {
                    if (result != null)
                    {
                        result.StatusId = -1;
                        //result.HotelBranchId = registration.HotelBranchId;
                        result.UpdatedAt = DateTime.Now;

                        dataContext.User.Update(result);
                        dataContext.SaveChanges();
                    }

                    success = true;
                    message = "Rejected successfully.";
                }

                return (success, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<(bool, string)> HotelBranchAction(PartnerRegistrationAction registration)
        {
            try
            {
                string message = "";
                bool success = false;
                int status = 0;

                var user = await _userGroup.GetUserGroup(registration.UserAdminId);
                if (user == null || user.GroupType != "admin")
                {
                    return (false, "Not an administrator");
                }

                var result = await dataContext.HotelBranches.Where(e => e.Id == registration.HotelBranchId).FirstOrDefaultAsync();

                if (result.Status == null) {
                    result.Status = 0;
                }
                
                if (registration.Action == "approved" && result.Status == 0)
                {
                    if (result != null)
                    {
                        result.Status = 1;
                        result.UpdatedAt = DateTime.Now;
                        
                        dataContext.HotelBranches.Update(result);
                        dataContext.SaveChanges();
                    }

                    success = true;
                    message = "Approve hotel branch successfully.";
                }
                else if (registration.Action == "rejected" && result.Status == 0)
                {
                    if (result != null)
                    {
                        result.Status = -1;
                        result.UpdatedAt = DateTime.Now;

                        dataContext.HotelBranches.Update(result);
                        dataContext.SaveChanges();
                    }

                    success = true;
                    message = "Reject hotel branch successfully.";
                }

                return (success, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<(bool, string)> AddCommission(int hotel_branch_id, double commission)
        {
            try
            {
                string message = "";
                bool success = false;

                HotelBranches result = await dataContext.HotelBranches.Where(e => e.Id == hotel_branch_id).FirstOrDefaultAsync();

                if(result != null)
                {
                    result.Commission = commission;
                    result.UpdatedAt = DateTime.Now;

                    dataContext.HotelBranches.Update(result);
                    dataContext.SaveChanges();

                    success = true;
                    message = "Update commission hotel branch successfully";
                }

                return (success, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

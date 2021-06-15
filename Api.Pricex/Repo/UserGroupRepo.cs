using Api.Pricex.Interface;
using Api.Pricex.Models;
using Api.Pricex.myDB;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Pricex.Repo
{
    public class UserGroupRepo : IUserGroup
    {
        private pedb_devContext _dataContext;
        public UserGroupRepo(pedb_devContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<UserGroupModel> GetUserGroup(int userId)
        {
            var data = await (from u in _dataContext.User
                            join ug in _dataContext.UserGroup
                            on u.Id equals ug.UserId
                            where u.Id == userId
                            select new UserGroupModel()
                            {
                                UserId = u.Id,
                                UserGroupId = ug.UserGroupId,
                                GroupType = ug.GroupType,
                            }).FirstOrDefaultAsync();

            return data;
        }
    }
}

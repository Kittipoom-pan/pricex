using Api.Pricex.Models;
using System.Threading.Tasks;

namespace Api.Pricex.Interface
{
    public interface IUserGroup
    {
        Task<UserGroupModel> GetUserGroup(int userId);
    }
}

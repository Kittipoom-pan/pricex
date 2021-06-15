using Api.Pricex.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Pricex.Interface
{
    public interface ILocation
    {
        Task<List<ProvinceViewModel>> GetProvince(string lang);
        Task<List<DistrictViewModel>> GetDistrict(string lang, int provinceId);
        Task<List<SubDistrictViewModel>> GetSubDistrict(string lang, int districtId);
    }
}

using System.Threading.Tasks;
using Mmu.WpfGraphApiTool.Areas.UserInfos.ViewData;

namespace Mmu.WpfGraphApiTool.Areas.UserInfos.ViewServices
{
    public interface IUserDataService
    {
        Task<UserViewData> LoadAsync();
    }
}
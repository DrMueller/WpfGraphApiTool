using System.Threading.Tasks;
using Mmu.WpfGraphApiTool.Areas.UserInfos.ViewServices;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.WpfGraphApiTool.Areas.UserInfos.Views.MeetingsOverview
{
    public class CommandContainer : IViewModelCommandContainer<UserInfosViewModel>
    {
        private readonly IUserDataService _overviewService;
        private UserInfosViewModel _context;

        public CommandContainer(IUserDataService overviewService)
        {
            _overviewService = overviewService;
        }

        public async Task InitializeAsync(UserInfosViewModel context)
        {
            _context = context;
            _context.User = await _overviewService.LoadAsync();
        }
    }
}
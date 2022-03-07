using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.WpfGraphApiTool.Areas.UserInfos.ViewData;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels;
using Mmu.WpfGraphApiTool.Infrastructure.Wpf.MvvmShell.ViewModels.Behaviors;

namespace Mmu.WpfGraphApiTool.Areas.UserInfos.Views.MeetingsOverview
{
    [PublicAPI]
    public class UserInfosViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private UserViewData _user;
        public CommandContainer CommandContainer { get; }
        public string HeadingDescription { get; } = "User";
        public string NavigationDescription { get; } = "User infos";
        public int NavigationSequence { get; } = 1;

        public UserViewData User
        {
            get => _user;
            set => OnPropertyChanged(value, ref _user);
        }

        public UserInfosViewModel(
            CommandContainer commandContainer)
        {
            CommandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await CommandContainer.InitializeAsync(this);
        }
    }
}
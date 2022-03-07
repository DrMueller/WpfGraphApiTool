using JetBrains.Annotations;

namespace Mmu.WpfGraphApiTool.Areas.UserInfos.ViewData
{
    [PublicAPI]
    public class UserViewData
    {
        public string CurrentTimeDescription { get; set; }
        public string DisplayName { get; set; }
        public string JobTitle { get; set; }
        public string MobilePhone { get; set; }
    }
}
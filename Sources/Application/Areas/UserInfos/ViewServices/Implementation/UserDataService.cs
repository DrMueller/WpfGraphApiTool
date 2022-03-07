using System;
using System.Threading.Tasks;
using Mmu.WpfGraphApiTool.Areas.UserInfos.ViewData;
using Mmu.WpfGraphApiTool.Infrastructure.GraphApi.Services;

namespace Mmu.WpfGraphApiTool.Areas.UserInfos.ViewServices.Implementation
{
    public class UserDataService : IUserDataService
    {
        private readonly IGraphServiceClientFactory _graphUserClientFactory;

        public UserDataService(IGraphServiceClientFactory graphUserClientFactory)
        {
            _graphUserClientFactory = graphUserClientFactory;
        }

        public async Task<UserViewData> LoadAsync()
        {
            var client = await _graphUserClientFactory.CreateAsync();

            var user = await client.Me
                .Request()
                .GetAsync();

            return new UserViewData
            {
                JobTitle = user.JobTitle,
                MobilePhone = user.MobilePhone,
                DisplayName = user.DisplayName,
                CurrentTimeDescription = DateTime.Now.ToLongTimeString()
            };
        }
    }
}
using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using JetBrains.Annotations;
using Microsoft.Graph;
using Mmu.WpfGraphApiTool.Infrastructure.Settings.Services;

namespace Mmu.WpfGraphApiTool.Infrastructure.GraphApi.Services.Implementation
{
    [UsedImplicitly]
    public class GraphServiceClientFactory : IGraphServiceClientFactory
    {
        private static readonly string[] _scopes = { "User.Read" };
        private readonly IAppSettingsProvider _appSettingsProvider;
        private AccessToken? _token;

        public GraphServiceClientFactory(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<GraphServiceClient> CreateAsync()
        {
            var accessToken = await GetAccessTokenAsync();

            var authProvider = new DelegateAuthenticationProvider(
                request =>
                {
                    request.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", accessToken);
                    return Task.CompletedTask;
                });

            return new GraphServiceClient(authProvider);
        }

        private async Task<string> GetAccessTokenAsync()
        {
            if (_token != null && _token.Value.ExpiresOn > DateTime.Now)
            {
                return _token.Value.Token;
            }

            var tokenRequestContext = new TokenRequestContext(_scopes);

            var options = new InteractiveBrowserCredentialOptions
            {
                TenantId = _appSettingsProvider.Settings.GraphApiTenantId,
                ClientId = _appSettingsProvider.Settings.GraphApiClientId,
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
                RedirectUri = new Uri("http://localhost")
            };

            var initCred = new InteractiveBrowserCredential(options);
            _token = await initCred.GetTokenAsync(tokenRequestContext, CancellationToken.None);

            return _token.Value.Token;
        }

        // Not working
        //private async Task<AccessToken> CreateOptionsAsync()
        //{
        //    var tokenRequestContext = new TokenRequestContext(_scopes);

        //    var options = new InteractiveBrowserCredentialOptions
        //    {
        //        TenantId = _appSettingsProvider.Settings.GraphApiTenantId,
        //        ClientId = _appSettingsProvider.Settings.GraphApiClientId,
        //        AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        //        RedirectUri = new Uri("http://localhost")
        //    };

        //    if (!System.IO.File.Exists(AuthRecordPath))
        //    {
        //        var initCred = new InteractiveBrowserCredential(options);
        //        var authRecord = await initCred.AuthenticateAsync(tokenRequestContext, CancellationToken.None);
        //        await using var authRecordStream = new FileStream(AuthRecordPath, FileMode.Create, FileAccess.Write);
        //        await authRecord.SerializeAsync(authRecordStream);
        //        options.AuthenticationRecord = authRecord;
        //    }
        //    else
        //    {
        //        await using var authRecordStream = new FileStream(AuthRecordPath, FileMode.Open, FileAccess.Read);
        //        var authRecordDeserialized = await AuthenticationRecord.DeserializeAsync(authRecordStream);
        //        options.AuthenticationRecord = authRecordDeserialized;
        //    }

        //    var cred = new InteractiveBrowserCredential(options);
        //    var accessToken = await cred.GetTokenAsync(tokenRequestContext);

        //    return accessToken;
        //}
    }
}
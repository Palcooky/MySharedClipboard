using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MySharedClipboard
{
    class AuthenticationHelper
    {
        static String ClientID = "e0e7f53e-2bfa-4780-abab-0ee5a1a79bba";
        public static string[] Scopes = { "Files.ReadWrite.All", "User.Read" };

        public static IPublicClientApplication IdentityClientApp = PublicClientApplicationBuilder.Create(ClientID).Build();

        private static GraphServiceClient graphClient = null;

        public static string TokenForUser = null;

        public static DateTimeOffset Expiration;

        public static GraphServiceClient GetAuthenticatedClient()
        {
            if (graphClient == null)
            {
                try
                {
                    graphClient = new GraphServiceClient(
                        "https://graph.microsoft.com/v1.0",
                        new DelegateAuthenticationProvider(
                            async (requestMessage) =>
                            {
                                var token = await GetTokenForUserAsync();
                                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);

                            }));
                    return graphClient;
                }

                catch (Exception ex)
                {
                    Debug.WriteLine("Could not create a graph client: " + ex.Message);
                }
            }

            return graphClient;
        }



        public static async Task<string> GetTokenForUserAsync()
        {
            AuthenticationResult result;
            var accounts = await IdentityClientApp.GetAccountsAsync();

            try
            {
                result = await IdentityClientApp.AcquireTokenSilent(Scopes, accounts.FirstOrDefault()).ExecuteAsync();
                TokenForUser = result.AccessToken;
            }
            catch (MsalUiRequiredException)
            {
                if (TokenForUser == null || Expiration <= DateTimeOffset.UtcNow.AddMinutes(5))
                {
                    try
                    {
                        result = await IdentityClientApp.AcquireTokenInteractive(Scopes).ExecuteAsync();
                        TokenForUser = result.AccessToken;
                        Expiration = result.ExpiresOn;
                    }
                    catch (MsalClientException ex)
                    {
                        graphClient = null;
                        Console.WriteLine("USer Cancelled sign in: " + ex);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return TokenForUser;
        }

        /// <summary>
        /// Signs the user out of the service.
        /// </summary>
        public static void SignOut()
        {
            graphClient = null;
            TokenForUser = null;
        }
    }
}

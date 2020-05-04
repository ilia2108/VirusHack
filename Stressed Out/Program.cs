using System;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace Stressed_Out
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
                .Create("d81502a3-9729-448d-938b-e8b2dcccd437")
                .Build();

            String[] scopes = { "https://graph.microsoft.com/calendars.read" };
            // Create an authentication provider by passing in a client application and graph scopes.
            DeviceCodeProvider authProvider = new DeviceCodeProvider(publicClientApplication, scopes);
            // Create a new instance of GraphServiceClient with the authentication provider.
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);
           

            var calendars = await graphClient.Users["ilia.ryabukhin@studentpartner.com"].Calendar //  CalendarGroups[""].Calendars
                .Request()
                .GetAsync();
            Console.WriteLine("Hello World!");

        }
    }
}

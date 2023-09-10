using Microsoft.Extensions.DependencyInjection;
using StexchangeClient.Contracts;
using System;

namespace StexchangeClient.Extensions.DependencyInjection
{
    public static class StexchangeClientServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddStexchangeClient(this IServiceCollection services, string baseAddress)
        {
            return services.AddHttpClient<IStexchangeRestClient, StexchangeRestClient>(option =>
            {
                if (string.IsNullOrWhiteSpace(baseAddress))
                    throw new ArgumentNullException($"{nameof(baseAddress)} isn't provided!");

                option.BaseAddress = new Uri(baseAddress.ToString().TrimEnd('/'));
            });
        }
    }
}
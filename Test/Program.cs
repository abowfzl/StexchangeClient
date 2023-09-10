using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StexchangeClient.Contracts;
using StexchangeClient.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddStexchangeClient("http://95.217.159.219:8090/");

var host = builder.Build();

var client = host.Services.GetRequiredService<IStexchangeRestClient>();

var list = new { key = "test", value = "test" };
var result = await client.UpdateBalance(Random.Shared.Next(), 16, "USDT", "Test", Random.Shared.Next(), 0.001m, list, CancellationToken.None);

Console.ReadLine();
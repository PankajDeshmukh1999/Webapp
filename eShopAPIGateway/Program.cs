using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", optional:false, reloadOnChange:true);

//builder.Services.AddOcelot();// normal API

builder.Services.AddOcelot(builder.Configuration).AddCacheManager(setting =>
setting.WithDictionaryHandle()); // to handle request in time using cache manager for quick response

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();

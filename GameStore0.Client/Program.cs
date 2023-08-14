using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GameStore0.Client;
using GameStore0.FileServer.Interfaces;
using GameStore0.FileServer;
using GameStore0.Client.TempServ;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<TempRepo>();
//builder.Services.AddScoped<IFileGetter, FileGetter>();
//builder.Services.AddScoped<IFileReader, FileReader>();

await builder.Build().RunAsync();

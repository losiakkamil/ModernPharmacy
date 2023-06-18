global using ModernPharmacy.Shared.Entities;
global using ModernPharmacy.Shared;
global using ModernPharmacy.Client.Services.ArticleService;
global using ModernPharmacy.Shared.Models.ArticleDtos;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ModernPharmacy.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IArticleService, ArticleService>();

await builder.Build().RunAsync();

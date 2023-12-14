using Eshop.Web;
using Eshop.Web.Services;
using Eshop.Web.Services.Impl;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress = builder.Configuration["APIURL:BaseURL"] ?? "https://localhost:7256/";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();

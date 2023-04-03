using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Typist.WasmApp;

var builder = WebAssemblyHostBuilder.CreateDefault();
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<EventBus>();

await builder.Build().RunAsync();

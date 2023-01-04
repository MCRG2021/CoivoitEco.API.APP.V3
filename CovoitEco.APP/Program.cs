using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP;
using CovoitEco.APP.Extensions;
using CovoitEco.APP.Service.Annonce.Commands;
using CovoitEco.APP.Service.Annonce.Queries;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Injection dependency
//builder.Services.AddScoped<IAnnonceQueriesService, AnnonceQueriesService>();
//builder.Services.AddScoped<IAnnonceCommandsService, AnnonceCommandsService>();
builder.Services.AddServices();


// Type HttpClient
//builder.Services.AddHttpClient<AnnonceQueriesService>(client =>
//    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// HttpClient test
//builder.Services.AddHttpClient();

await builder.Build().RunAsync();

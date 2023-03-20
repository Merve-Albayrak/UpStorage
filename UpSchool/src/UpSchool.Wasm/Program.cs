using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;
using UpSchool.Domain.Services;
using UpSchool.Wasm;
using UpSchool.Wasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var titanicFluteApiUrl = builder.Configuration.GetConnectionString("TitanicFlute"); //appsetting json a ula�
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration.GetSection("ApiUrl").Value;

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
builder.Services.AddBlazoredToast();
//builder.Services.AddScoped(new HttpClient(
//    BaseAddress = new Uri("https://localhost:7230/api/");
//};
builder.Services.AddScoped<IToasterService,ToasterService>();// request bounca s�ren i�lemdir,  request bitince gider
//builder.Services.AddSingleton<IToasterService,ToasterService>(); nesne bir kez kaydedilir uygulama�n her yerinde o �a�r�l�r. tektir
//b�t�n uygulama boyunca ayn� instance kullan�l�r

//builder.Services.AddTransient<IToasterService, ToasterService>(); her i�lemde yeni instance olu�turulur

builder.Services.AddSingleton<IUrlHelperService>(new UrlHelperService(titanicFluteApiUrl));
builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});
await builder.Build().RunAsync();

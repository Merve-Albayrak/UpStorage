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
var titanicFluteApiUrl = builder.Configuration.GetConnectionString("TitanicFlute"); //appsetting json a ulaþ
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration.GetSection("ApiUrl").Value;

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
builder.Services.AddBlazoredToast();
//builder.Services.AddScoped(new HttpClient(
//    BaseAddress = new Uri("https://localhost:7230/api/");
//};
builder.Services.AddScoped<IToasterService,ToasterService>();// request bounca süren iþlemdir,  request bitince gider
//builder.Services.AddSingleton<IToasterService,ToasterService>(); nesne bir kez kaydedilir uygulamaýn her yerinde o çaðrýlýr. tektir
//bütün uygulama boyunca ayný instance kullanýlýr

//builder.Services.AddTransient<IToasterService, ToasterService>(); her iþlemde yeni instance oluþturulur

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

using app.Core.Model;
using Microsoft.AspNetCore.Components.Authorization;
using app.Data;
using Blazored.LocalStorage;
using app.WebClient.State;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddSingleton<MasterContext>();
builder.Services.AddSingleton<ApplicationState>();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddAntDesign();

builder.Services.AddBlazoredLocalStorage();   // local storage
builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);  // local storage

builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options => {
        options.RootDirectory = "/WebClient/Pages";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

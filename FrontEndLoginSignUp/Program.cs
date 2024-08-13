using Blazored.LocalStorage;
using Blazored.SessionStorage;
using FrontEndLoginSignUp.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register CustomAuthenticationStateProvider as the default AuthenticationStateProvider
builder.Services.AddScoped<CustomAuthenticationStateProvider>();builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


// Register CustomAuthorizationMessageHandler
builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpContextAccessor();

// Register HttpClient with CustomAuthorizationMessageHandler
builder.Services.AddHttpClient("AuthApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7001"); // Replace with your API base address
}).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddBlazoredSessionStorage();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

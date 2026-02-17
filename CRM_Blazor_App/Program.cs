using CRM_Blazor_App.Components;


var builder = WebApplication.CreateBuilder(args);

//var apiBaseAddress = builder.Configuration["ApiBaseAddress"];
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new(apiBaseAddress!)});


//builder.Services.AddHttpClient("CRMAPI", client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration["ApiBaseAddress"]!);
//});
var apiBaseAddress = builder.Configuration["ApiBaseAddress"];

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseAddress!)
});

// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();

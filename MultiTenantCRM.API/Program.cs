using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MultiTenantCRM.API.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MultiTenantCRMAPIDBContextConnection") ?? throw new InvalidOperationException("Connection string 'MultiTenantCRMAPIDBContextConnection' not found.");

builder.Services.AddDbContext<MultiTenantCRMAPIDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MultiTenantCRMAPIUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MultiTenantCRMAPIDBContext>();

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});





builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRM API", Version = "v1" })
    ); 


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c=>c.SwaggerEndpoint("swagger/v1/swagger.json", "CRM API V1")
//        );
//}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRM API V1");
        // Optional: make Swagger appear at root URL instead of /swagger
        // c.RoutePrefix = string.Empty;
    });
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.Run();

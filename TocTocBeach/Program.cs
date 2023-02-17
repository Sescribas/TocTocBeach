using TocTocBeach.Repository;
using Microsoft.EntityFrameworkCore;
using TocTocBeach.Repository.Interface;
using Microsoft.Extensions.Options;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Reflection.PortableExecutable;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly("TocTocBeach")));
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Toc Toc Beach API",
        Version = "v1",
        Description = "Toc Toc Beach API for beach resorts, developed by a group of friends, provides a comprehensive platform for managing and promoting beach resort properties. The API allows resort owners and managers to easily create and maintain listings for their properties, as well as manage bookings and reservations.\r\n\r\nWith its intuitive interface, resort owners can quickly and easily update information about their properties, including photos, descriptions, and amenities. They can also view and manage bookings and reservations made through the platform, and keep track of occupancy and availability in real-time."
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

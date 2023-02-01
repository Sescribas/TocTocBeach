using TocTocBeach.Repository;
using Microsoft.EntityFrameworkCore;
using TocTocBeach.Repository.Interface;

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

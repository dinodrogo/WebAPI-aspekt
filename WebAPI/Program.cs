using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Data.Profiles;
using WebAPI.Services.Interfaces;
using WebAPI.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();







var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new CompanyProfile());
    mc.AddProfile(new ContactProfile());
    mc.AddProfile(new CountryProfile());
});
builder.Services.AddDbContextPool<WebAPIDbContext>((serviceProvider, options) =>
{
    options
    .UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=WebAPIAspektDB;Trusted_Connection=True;",
        x => x.MigrationsAssembly("WebAPI.Models"));
    options
        .UseInternalServiceProvider(serviceProvider);
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IContactService, ContactService>();







var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

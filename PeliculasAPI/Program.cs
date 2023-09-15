using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI;
using PeliculasAPI.Helpers;
using PeliculasAPI.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().
    AddNewtonsoftJson();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"))); //el builder.Configuration es importante

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosAzure>();


builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});

builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
    x.MultipartHeadersLengthLimit = int.MaxValue;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

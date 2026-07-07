using BeRme.Repository;
using BeRme.Data;
using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1",
//        new Microsoft.OpenApi.Models.OpenApiInfo
//        {
//            Title = "Demo JWT API",
//            Version = "v1",
//            Description = "Belajar ASP.NET Core Web API dengan JWT Authentication",
//            Contact = new Microsoft.OpenApi.Models.OpenApiContact
//            {
//                Name = "Sumarto",
//                Email = "your@email.com"
//            }
//        });
//});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


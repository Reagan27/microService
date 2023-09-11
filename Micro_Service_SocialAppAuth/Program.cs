using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MicroService_MessageBus;
using MicroServiceAuthentication.Data;
using MicroServiceAuthentication.Extensions;
using MicroServiceAuthentication.Services;
using MicroServiceAuthentication.Services.IServices;
using MicroServiceAuthentication.Utilities;

var builder = WebApplication.CreateBuilder(args);
//Register IdentityUser

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Db Connection
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

//Register Identity Framework

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

//configure JWtOptions 
builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JwtOptions"));

// Register Services

builder.Services.AddScoped<IJWtTokenGenerator, JWTServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IMessageBus, MessageBus>();

//Register Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Run any Pending Migrations
app.UseMigration();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();

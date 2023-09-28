global using EfCoreRelationships.Data;
global using Microsoft.EntityFrameworkCore;
using BuisnessLogic_Layer;
using BuisnessLogic_Layer.Services;
using DataAccess_Layer;
using DataAccess_Layer.Interfaces;
using DataAccess_Layer.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CharacterService>();
builder.Services.AddScoped<SkillService>();
builder.Services.AddScoped<WeaponService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IWeaponRepository, WeaponRepository>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//Configure the HTTP request pipeline.

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Before the next call");
//    await next();
//    Console.WriteLine("After the next call");

//});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use(async (ctx, next) =>
{
    var start = DateTime.UtcNow;
    await next.Invoke(ctx);
    app.Logger.LogInformation($"Request {ctx.Request.Path} Duration{(DateTime.UtcNow-start).TotalMilliseconds}");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


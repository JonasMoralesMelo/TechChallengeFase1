using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TechChallengeFase1.Data;
using TechChallengeFase1.Data.Mapping;
using TechChallengeFase1.Services;
using TechChallengeFase1.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContatoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        opt=>opt.CommandTimeout((int) TimeSpan.FromMinutes(3).TotalSeconds));
});

builder.Services.AddSingleton<IBrasilApiService, BrasilApiService>();
builder.Services.AddSingleton<IDDDService, DDDService>();
builder.Services.AddScoped<IContatoService, ContatoService>();

builder.Services.AddAutoMapper(typeof(DDDMapping));

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

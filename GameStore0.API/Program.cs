using GameStore0.API.TempFileRepo;
using GameStore0.FileServer;
using GameStore0.FileServer.InMemoryData;
using GameStore0.FileServer.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMemoryRepo, MemoryRepo>();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("OpenCors", opt =>
        opt.AllowAnyOrigin(). //wont talk to api from another locations (another url)
        AllowAnyHeader(). //if you pass headers along with ur api it may block them
        AllowAnyMethod()); //only alows get, won't allow some other (delete, put)});
});

var app = builder.Build();
app.UseCors("OpenCors"); //не забываем использовать

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
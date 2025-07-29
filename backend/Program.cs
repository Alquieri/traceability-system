using backend.Repository;
using backend.Repository.InMemory;
using backend.Services;
using backend.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPartService, PartService>();
builder.Services.AddSingleton<IPartRepository, InMemoryPartRepository>();
builder.Services.AddSingleton<IMovementService, MovementService>();
builder.Services.AddSingleton<IMovementRepository, InMemoryMovementRepository>();
builder.Services.AddSingleton<IStationRepository, InMemoryStationRepository>();



builder.Services.AddControllers(); 


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/hello-world", () =>
{
    return "Hello world!";
});

app.MapControllers();
app.Run();


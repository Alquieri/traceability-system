using backend.Repository;
using backend.Repository.InMemory;
using backend.Services;
using backend.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Rastreabilidade de Peças",
        Description = "API para gerenciar o fluxo de peças em estações de processo."
    });

    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<IPartService, PartService>();
builder.Services.AddSingleton<IPartRepository, InMemoryPartRepository>();
builder.Services.AddSingleton<IMovementService, MovementService>();
builder.Services.AddSingleton<IMovementRepository, InMemoryMovementRepository>();
builder.Services.AddSingleton<IStationRepository, InMemoryStationRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors();

app.MapControllers();
app.Run();

using backend.Repository;
using backend.Repository.InMemory;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PartService>();
builder.Services.AddSingleton<IPartRepository, InMemoryPartRepository>();
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


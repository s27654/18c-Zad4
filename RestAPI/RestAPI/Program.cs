using Microsoft.AspNetCore.Mvc;
using RestAPI;
using RestAPI.Models;

var builder = WebApplication.CreateBuilder(args);
// Searches 
builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/zwierzeta", () =>
{
    var student = DB.Zwierzeta;
    return Results.Ok(student);
});

// GET /api/students/io
app.MapGet("/api/zwierzeta/{id:int}", (int id) =>
{
    var zwierz = DB.Zwierzeta.FirstOrDefault(st => st.Id == id);
    return zwierz is null ? Results.NotFound($"Zwierz with id {id} not found") : Results.Ok(zwierz);
});

// POST /api.students
app.MapPost("/api/zwierzeta", ([FromBody] Zwierz data) =>
{
    var zwierz = DB.Zwierzeta.Exists(s => s.Id == data.Id);
    if (zwierz) return Results.Conflict($"Zwierz with id {data.Id} already exists");
    return Results.Created($"/api/zwierzeta/{data.Id}", data);
});

// GET /api/students/10/appointments
// POST /api/students/10/appointments

// GET /api/appointments?studentId=10
app.MapGet("/api/appointments", ([FromQuery] int zwierzId) =>
{
    var zwierz = DB.Zwierzeta.Exists(s => s.Id == zwierzId);
    return Results.Ok();
});
// POST /api/appointments


// Maps controllers to endpoints
app.MapControllers();


app.UseHttpsRedirection();

// RUn the application on free port
app.Run();

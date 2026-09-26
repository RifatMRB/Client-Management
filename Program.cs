using System.ComponentModel.DataAnnotations;
using Client_Management.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

List<Client> clients = new List<Client>();

app.MapGet("/api/clients", () =>
{
    return Results.Ok(clients);
});
app.MapPost("/api/clients", (Client clientData) =>
{
    var client = new Client
    {
        ClientId = Guid.NewGuid(),
        Name = clientData.Name,
        Email = clientData.Email,
        Phone = clientData.Phone,
        Address = clientData.Address,
        CreatedAt = DateTime.UtcNow
    };
    clients.Add(client);
    return Results.Created($"/api/clients/{client.ClientId}", client);
});

app.MapPut("/api/clients/{id:guid}", (Guid id,Client clientData) =>
{
    var client = clients.FirstOrDefault(c => c.ClientId==id);
    if(client==null) return Results.NotFound();
    client.Name = clientData.Name ?? client.Name;
    client.Email = clientData.Email ?? client.Email;
    client.Phone = clientData.Phone ?? client.Phone;
    client.Address = clientData.Address ?? client.Address;
    return Results.Ok(client);
});

app.MapDelete("/api/clients/{id:guid}", (Guid id) =>
{
    var client = clients.FirstOrDefault(c => c.ClientId==id);
    if(client==null) return Results.NotFound();
    clients.Remove(client);
    return Results.NoContent();
});

app.Run(); 



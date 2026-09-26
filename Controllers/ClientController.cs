using Client_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client_Management.Controllers;

[ApiController]
[Route("/api/clients")]
public class ClientController : ControllerBase
{
    public static List<Client> clients = new List<Client>();

    [HttpGet]
    public IActionResult GetAllClient()
    {
        return Ok(clients);
    }

    [HttpGet("{Id:guid}")]
    public IActionResult GetClientById(Guid Id)
    {
        var client = clients.FirstOrDefault(c => c.ClientId == Id);
        if (client == null) return NotFound();
        return Ok(client);
    }

    [HttpPost]
    public IActionResult CreateClient(Client clientData)
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
        return Created($"/api/clients/{client.ClientId}", client);
    }

    [HttpPut("{Id:guid}")]
    public IActionResult UpdateClientById(Guid Id, Client clientData)
    {
        var client = clients.FirstOrDefault(c => c.ClientId == Id);
        if (client == null) return NotFound();
        client.Name = clientData.Name ?? client.Name;
        client.Email = clientData.Email ?? client.Email;
        client.Phone = clientData.Phone ?? client.Phone;
        client.Address = clientData.Address ?? client.Address;
        return Ok(client);
    }

    [HttpDelete("{Id:guid}")]
    public IActionResult DeleteClientById(Guid Id)
    {
        var client = clients.FirstOrDefault(c => c.ClientId == Id);
        if (client == null) return NotFound();
        clients.Remove(client);
        return NoContent();
    }
}
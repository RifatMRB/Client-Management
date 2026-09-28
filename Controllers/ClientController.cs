using Client_Management.DTOs;
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
        var ReadClients = clients.Select(c=>
            new ClientReadDto
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                CreatedAt = c.CreatedAt
            }
        ).ToList();
        return Ok(ApiResponse<List<ClientReadDto>>.SuccessResponse(ReadClients,
        200,"found client successfully"));
    }

    [HttpGet("{Id:guid}")]
    public IActionResult GetClientById(Guid Id)
    {
        var client = clients.FirstOrDefault(c => c.ClientId == Id);
        if (client == null) return NotFound();
        var ReadClient = new ClientReadDto
        {
            ClientId = client.ClientId,
            Name = client.Name,
            Email = client.Email,
            Phone = client.Phone,
            Address = client.Address,
            CreatedAt = client.CreatedAt
        };
        return Ok(ApiResponse<ClientReadDto>.SuccessResponse(ReadClient,200,"found client successfully"));
    }

    [HttpPost]
    public IActionResult CreateClient(ClientCreateDto clientData)
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

        var ReadClient = new ClientReadDto
        {
            ClientId = client.ClientId,
            Name = client.Name,
            Email = client.Email,
            Phone = client.Phone,
            Address = client.Address,
            CreatedAt = client.CreatedAt
        };
        return Created($"/api/clients/{ReadClient.ClientId}", ApiResponse<ClientReadDto>.
        SuccessResponse(ReadClient,201,"Client created successfully"));
    }

    [HttpPut("{Id:guid}")]
    public IActionResult UpdateClientById(Guid Id, ClientUpdateDto clientData)
    {
        var client = clients.FirstOrDefault(c => c.ClientId == Id);
        if (client == null) return NotFound(ApiResponse<object>.ErrorResponse(new List<string>
        {"Client not Found"},404
        ,"Validation failed"));
        client.Name = clientData.Name ?? client.Name;
        client.Email = clientData.Email ?? client.Email;
        client.Phone = clientData.Phone ?? client.Phone;
        client.Address = clientData.Address ?? client.Address;

        var ReadClient = new ClientReadDto
        {
            ClientId = client.ClientId,
            Name = client.Name,
            Email = client.Email,
            Phone = client.Phone,
            Address = client.Address,
            CreatedAt = client.CreatedAt
        };
        return Ok(ApiResponse<ClientReadDto>.SuccessResponse(ReadClient,200,"Update client successfully"));
    }

    [HttpDelete("{Id:guid}")]
    public IActionResult DeleteClientById(Guid Id)
    {
        var client = clients.FirstOrDefault(c => c.ClientId == Id);
        if (client == null) return NotFound(ApiResponse<object>.ErrorResponse(new List<string>
        {"Client not Found"},404
        ,"Validation failed"));
        clients.Remove(client);
        return Ok(ApiResponse<object>.SuccessResponse(null,204,"Deleted successfully"));
    }
}
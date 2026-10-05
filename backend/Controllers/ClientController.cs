using Client_Management.DTOs;
using Client_Management.Interfaces;
using Client_Management.Models;
using Client_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace Client_Management.Controllers;

[ApiController]
[Route("/api/clients")]
public class ClientController : ControllerBase
{

    private IClientService _clientService;
    public ClientController(IClientService CS)
    {
        _clientService = CS;
    }
    

    [HttpGet]
    public async Task<IActionResult> GetAllClient()
    {
        var ReadClients = await _clientService.GetAllClient();
        return Ok(ApiResponse<List<ClientReadDto>>.SuccessResponse(ReadClients,
        200,"found client successfully"));
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetClientById(Guid Id)
    {
        var client = await _clientService.GetClientById(Id);
        if (client == null) return NotFound();
        var ReadClient = client;
        return Ok(ApiResponse<ClientReadDto>.SuccessResponse(ReadClient,200,"found client successfully"));
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(ClientCreateDto clientData)
    {
        

        var ReadClient = await _clientService.CreateClient(clientData);
        return Created($"/api/clients/{ReadClient.ClientId}", ApiResponse<ClientReadDto>.
        SuccessResponse(ReadClient,201,"Client created successfully"));
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> UpdateClientById(Guid Id, ClientUpdateDto clientData)
    {
        var client = await _clientService.UpdateClientById(Id,clientData);
        if (client == null) return NotFound(ApiResponse<object>.ErrorResponse(new List<string>
        {"Client not Found"},404
        ,"Validation failed"));

        var ReadClient = client;
        return Ok(ApiResponse<ClientReadDto>.SuccessResponse(ReadClient,200,"Update client successfully"));
    }

    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> DeleteClientById(Guid Id)
    {
        var client = await _clientService.DeleteClientById(Id);
        if (!client ) return NotFound(ApiResponse<object>.ErrorResponse(new List<string>
        {"Client not Found"},404
        ,"Validation failed"));
        return Ok(ApiResponse<object>.SuccessResponse(null,204,"Deleted successfully"));
    }
}
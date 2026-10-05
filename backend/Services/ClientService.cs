using AutoMapper;
using Client_Management.Data;
using Client_Management.DTOs;
using Client_Management.Interfaces;
using Client_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Client_Management.Services;

public class ClientService : IClientService
{
    //private static readonly List<Client> _clients = new List<Client>();
    private readonly AppDbContext _appDbContext;

    private readonly IMapper _mapper;
    public ClientService(IMapper mapper,AppDbContext appDbContext)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
    }

    public async Task<List<ClientReadDto>> GetAllClient()
    {
        // return _clients.Select(c=>
        //     new ClientReadDto
        //     {
        //         ClientId = c.ClientId,
        //         Name = c.Name,
        //         Email = c.Email,
        //         Phone = c.Phone,
        //         Address = c.Address,
        //         CreatedAt = c.CreatedAt
        //     }
        // ).ToList();
        var clients = await _appDbContext.Clients.ToListAsync();
        return _mapper.Map<List<ClientReadDto>>(clients);
    }

    public async Task<ClientReadDto?> GetClientById(Guid Id)
    {
        var client = await _appDbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == Id);
        if (client == null) return null;
        // return new ClientReadDto
        // {
        //     ClientId = client.ClientId,
        //     Name = client.Name,
        //     Email = client.Email,
        //     Phone = client.Phone,
        //     Address = client.Address,
        //     CreatedAt = client.CreatedAt
        // };
        return _mapper.Map<ClientReadDto>(client);
    }

    public async Task<ClientReadDto> CreateClient(ClientCreateDto clientData)
    {
        // var client = new Client
        // {
        //     ClientId = Guid.NewGuid(),
        //     Name = clientData.Name,
        //     Email = clientData.Email,
        //     Phone = clientData.Phone,
        //     Address = clientData.Address,
        //     CreatedAt = DateTime.UtcNow
        // };
        var client = _mapper.Map<Client>(clientData);
        await _appDbContext.Clients.AddAsync(client);
        await _appDbContext.SaveChangesAsync();

        // return new ClientReadDto
        // {
        //     ClientId = client.ClientId,
        //     Name = client.Name,
        //     Email = client.Email,
        //     Phone = client.Phone,
        //     Address = client.Address,
        //     CreatedAt = client.CreatedAt
        // };

        return _mapper.Map<ClientReadDto>(client);
    }

    public async Task<ClientReadDto?> UpdateClientById(Guid Id, ClientUpdateDto clientData)
    {
        var client = await _appDbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == Id);
        if (client == null) return null;
        // client.Name = clientData.Name ?? client.Name;
        // client.Email = clientData.Email ?? client.Email;
        // client.Phone = clientData.Phone ?? client.Phone;
        // client.Address = clientData.Address ?? client.Address;
        _mapper.Map(clientData,client);
        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<ClientReadDto>(client);
    }

    public async Task<bool> DeleteClientById(Guid Id)
    {
        var client = await _appDbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == Id);
        if (client == null) return false;

        _appDbContext.Clients.Remove(client);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}
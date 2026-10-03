using AutoMapper;
using Client_Management.DTOs;
using Client_Management.Interfaces;
using Client_Management.Models;

namespace Client_Management.Services;

public class ClientService : IClientService
{
    private static readonly List<Client> _clients = new List<Client>();

    private readonly IMapper _mapper;
    public ClientService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public  List<ClientReadDto> GetAllClient()
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
        return _mapper.Map<List<ClientReadDto>>(_clients);
    }

    public ClientReadDto? GetClientById(Guid Id)
    {
        var client = _clients.FirstOrDefault(c => c.ClientId == Id);
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

    public ClientReadDto CreateClient(ClientCreateDto clientData)
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
        var client =_mapper.Map<Client>(clientData);
        _clients.Add(client);

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

    public ClientReadDto? UpdateClientById(Guid Id, ClientUpdateDto clientData)
    {
        var client = _clients.FirstOrDefault(c => c.ClientId == Id);
        if (client == null) return null;
        // client.Name = clientData.Name ?? client.Name;
        // client.Email = clientData.Email ?? client.Email;
        // client.Phone = clientData.Phone ?? client.Phone;
        // client.Address = clientData.Address ?? client.Address;
        _mapper.Map(clientData,client);

        return _mapper.Map<ClientReadDto>(client);
    }

    public bool DeleteClientById(Guid Id)
    {
        var client = _clients.FirstOrDefault(c => c.ClientId == Id);
        if (client == null) return false;
        _clients.Remove(client);
        return true;
    }
}
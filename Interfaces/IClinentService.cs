using Client_Management.DTOs;

namespace Client_Management.Interfaces;

public interface IClientService
{
    Task<List<ClientReadDto>> GetAllClient();

    Task<ClientReadDto?> GetClientById(Guid Id);
    Task<ClientReadDto> CreateClient(ClientCreateDto clientData);

    Task<ClientReadDto?> UpdateClientById(Guid Id, ClientUpdateDto clientData);

    Task<bool> DeleteClientById(Guid Id);
}
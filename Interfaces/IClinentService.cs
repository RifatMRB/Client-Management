using Client_Management.DTOs;

namespace Client_Management.Interfaces;

public interface IClientService
{
    List<ClientReadDto> GetAllClient();

    ClientReadDto? GetClientById(Guid Id);
    ClientReadDto CreateClient(ClientCreateDto clientData);

    ClientReadDto? UpdateClientById(Guid Id, ClientUpdateDto clientData);

    bool DeleteClientById(Guid Id);
}
using AutoMapper; //dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

using Client_Management.DTOs;
using Client_Management.Models;

namespace Client_Management.Profiles;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientReadDto>();
        CreateMap<ClientCreateDto, Client>();
        CreateMap<ClientUpdateDto, Client>();
    }
}
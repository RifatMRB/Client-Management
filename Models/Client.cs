using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Client_Management.Models;

public class Client
{
    public Guid ClientId {get;set;}
    public string? Name {get;set;} 
    public string? Email {get;set;}
    public string? Phone {get;set;}
    public string? Address {get;set;}
    public DateTime CreatedAt  { get; set;}

    internal static void Remove(Client client)
    {
        throw new NotImplementedException();
    }
}
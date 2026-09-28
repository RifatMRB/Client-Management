namespace Client_Management.DTOs;

public class ClientReadDto
{
    public Guid ClientId { get; set; }
    public string? Name { get; set; } 

    public string? Email { get; set; } 

    public string? Phone { get; set; } 

    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }


}

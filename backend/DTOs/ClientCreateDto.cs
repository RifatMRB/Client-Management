using System.ComponentModel.DataAnnotations;

namespace Client_Management.DTOs;

public class ClientCreateDto
{
[Required(ErrorMessage = "Name is required.")]
[StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
public string Name { get; set; } = string.Empty;

[Required(ErrorMessage = "Email is required.")]
[EmailAddress(ErrorMessage = "Invalid email format.")]
public string Email { get; set; } = string.Empty;

[Required(ErrorMessage = "Phone number is required.")]
[RegularExpression(@"^01[3-9]\d{8}$", ErrorMessage = "Phone must be a valid Bangladeshi number (e.g., 019XXXXXXXX).")]
public string Phone { get; set; } = string.Empty;

[Required(ErrorMessage = "Address is required.")]
[StringLength(200, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 200 characters.")]
public string Address { get; set; } = string.Empty;


}

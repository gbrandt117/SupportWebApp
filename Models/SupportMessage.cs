using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SupportWebApp.Models;

public class SupportMessage
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Navn er påkrævet")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Email er påkrævet")]
    [EmailAddress(ErrorMessage = "Indtast en gyldig email")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Telefon er påkrævet")]
    public string Phone { get; set; } = "";

    [Required(ErrorMessage = "Beskrivelse er påkrævet")]
    public string Description { get; set; } = "";

    [Required(ErrorMessage = "Kategori er påkrævet")]
    public string Category { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
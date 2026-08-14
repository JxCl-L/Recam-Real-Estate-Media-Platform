using System.ComponentModel.DataAnnotations;

namespace RECAM.Models.Entities;

public class CaseContact
{
    [Key]
    public int ContactId { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string CompanyName { get; set; } = string.Empty;

    [MaxLength(500)]
    public string ProfileUrl { get; set; } = string.Empty;

    [Required]
    [EmailAddress, MaxLength(254)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string PhoneNumber { get; set; } = string.Empty;

    public int ListingCaseId { get; set; } 
    public ListingCase ListingCase { get; set; } = null!; // null! null-forgiving 

}

using System.ComponentModel.DataAnnotations;
using RECAM.Models.Enums;

namespace RECAM.Models.Entities;

public class MediaAsset
{
    [Key]
    public int Id { get; set; }

    public MediaType MediaType { get; set; }

    [Required]
    [MaxLength(500)]
    public string MediaUrl { get; set; } = string.Empty;

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public bool IsSelect { get; set; }

    public bool IsHero { get; set; }

    public int ListingCaseId { get; set; }
    public ListingCase ListingCase { get; set; } = null!;

    [Required]
    [MaxLength(450)]
    public string UserId { get; set; } = string.Empty; // User is company not agent
    [Required] 
    public ApplicationUser User { get; set; } = null!;

    public bool IsDeleted { get; set; }



}

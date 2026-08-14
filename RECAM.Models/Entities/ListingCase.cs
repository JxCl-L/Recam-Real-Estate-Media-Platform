using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RECAM.Models.Enums;

namespace RECAM.Models.Entities;

public class ListingCase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string State { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Postcode { get; set; } = string.Empty;

    public decimal Longitude { get; set; }

    public decimal Latitude { get; set; }

    public decimal Price { get; set; }

    // no [required] for value type(int double decinal bool enum Datetime) 
    // => value not set? => auto assign 0/default, cannot be null, [required] 冗余

    public int Bedrooms { get; set; }

    public int Bathrooms { get; set; }

    public int Garages { get; set; }

    public double FloorArea { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // best pratice: set in dbcontext

    public bool IsDeleted { get; set; }

    public PropertyType PropertyType { get; set; }

    public SaleCategory SaleCategory { get; set; }

    public ListCaseStatus ListCaseStatus { get; set; }

    [Required]
    [MaxLength(450)]
    public string UserId { get; set; } = string.Empty; // user is company not agent
    [Required]
    public ApplicationUser User { get; set; } = null!;

    public ICollection<MediaAsset> MediaAssets { get; set; } = new List<MediaAsset>();
    // ICollection => "Program to interfaces, not implementations" => easy to change list to eg set

    public ICollection<CaseContact> CaseContacts { get; set; } = new List<CaseContact>();

    public ICollection<Agent> Agents { get; set; } = new List<Agent>();

    
}

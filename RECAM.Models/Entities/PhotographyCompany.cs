using System.ComponentModel.DataAnnotations;

namespace RECAM.Models.Entities;

public class PhotographyCompany
{
    [Key]
    [MaxLength(450)]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // string id cannot use this
    public string Id { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string PhotographyCompanyName { get; set; } = string.Empty;

    [Required]
    public ApplicationUser User { get; set; } = null!;
    // [Required]
    // public string UserId { get; set; } = string.Empty; // same as PhotographyCompany.Id

    // M:N 到 Agent（显式中间表）
    public ICollection<AgentPhotographyCompany> AgentPhotographyCompanies { get; set; } = new List<AgentPhotographyCompany>();


}

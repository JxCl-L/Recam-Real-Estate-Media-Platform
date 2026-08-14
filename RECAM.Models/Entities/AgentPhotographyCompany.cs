using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RECAM.Models.Entities;

[PrimaryKey(nameof(AgentId), nameof(PhotographyCompanyId))]
public class AgentPhotographyCompany
{
    [MaxLength(450)]
    public string AgentId { get; set; } = string.Empty;
    public Agent Agent { get; set; } = null!;

    [MaxLength(450)]
    public string PhotographyCompanyId { get; set; } = string.Empty;
    public PhotographyCompany PhotographyCompany { get; set; } = null!;

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; }

}

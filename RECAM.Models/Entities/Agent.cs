using System.ComponentModel.DataAnnotations;

namespace RECAM.Models.Entities;

public class Agent
{
    [Key]
    [MaxLength(450)]
    public string Id { get; set; } = string.Empty;
    // agent 依赖于 application user 存在 => agent.id == userId
    // => for agent:user 1:1, only add User navigation, no need add UserId navigation, because it is same as Agent.id

    [Required]
    [MaxLength(100)]
    public string AgentFirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string AgentLastName { get; set; } = string.Empty;

    [MaxLength(500)]
    public string AvatarUrl { get; set; } = string.Empty;

    // [Required] // may not have a company now
    [MaxLength(100)]
    public string CompanyName { get; set; } = string.Empty;

    // public string CompanyId { get; set; } = string.Empty; // dont need this here, just have company name for convenience eg show by the side with agent info. company id and further details see agentphotographycompany join table.

    [Required]
    public ApplicationUser User { get; set; } = null!; 
    // not new User but null!
    // => new User() 会创造一个"垃圾对象"

    // [Required]
    // public string UserId { get; set; } = string.Empty; // same as agent.id

    // M:N 到 ListingCase（skip navigation，EF Core 自动生成隐藏中间表）
    public ICollection<ListingCase> ListingCases { get; set; } = new List<ListingCase>();

    // M:N 到 PhotographyCompany（显式中间表）
    public ICollection<AgentPhotographyCompany> AgentPhotographyCompanies { get; set; } = new List<AgentPhotographyCompany>();

}

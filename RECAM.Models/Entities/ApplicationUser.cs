using Microsoft.AspNetCore.Identity;
using RECAM.Common.Interfaces;

namespace RECAM.Models.Entities;

public class ApplicationUser : IdentityUser, IAuditable // IdentityUser 自带 IdentityUserRole，IdentityRole
{
    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}

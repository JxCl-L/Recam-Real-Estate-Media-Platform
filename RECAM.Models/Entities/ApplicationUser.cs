using Microsoft.AspNetCore.Identity;

namespace RECAM.Models.Entities;

public class ApplicationUser : IdentityUser // 自带 IdentityUserRole，IdentityRole
{
    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}

using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Models;

public class UserRole
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public int RoleId { get; set; }

    #region Navigation Properties
    public User User { get; set; }
    public Role Role { get; set; }
    #endregion
}
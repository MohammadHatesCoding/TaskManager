using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Models.BaseModel;
using TaskManager.Shared.Enums;

namespace TaskManager.Domain.Models;

public class Role : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    [Required]
    public RoleType Type { get; set; }

    #region Navigation Properties
    public List<UserRole> UserRoles { get; set; }
    #endregion
}
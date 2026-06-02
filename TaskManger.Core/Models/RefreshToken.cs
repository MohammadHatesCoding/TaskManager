using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Models;

public class RefreshToken
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Token { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime ExpiresAt { get; set; } = DateTime.Now.AddDays(1);
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public Guid UserId { get; set; }
    public bool IsRevoked { get; set; } = false;
    public bool IsDeleted { get; set; } = false;

    #region Navigation Properties
    public User User { get; set; }
    #endregion
}
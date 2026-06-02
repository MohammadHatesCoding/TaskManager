using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Models;

public class PasswordResetToken
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string Token { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddMinutes(10);
    public bool IsUsed { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    #region Navigation Properties
    public User User { get; set; }
    #endregion
}
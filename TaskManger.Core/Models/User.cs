using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Models;

public class User
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string NationalCode { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime BirthDate { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string OtpHash { get; set; } = string.Empty;
    public DateTime? OTPDuration { get; set; }
    public bool EmailConfirmed { get; set; } = false;
    public DateTime? LockOutEnd { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime? UpdateDate { get; set; }
    public string CreateUser { get; set; } = "System";
    public string UpdateUser { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public bool IsBlocked { get; set; } = false;
    public bool IsActive { get; set; } = true;

    #region Navigation Properties
    public List<UserRole> UserRoles { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }
    public List<PasswordResetToken> PasswordResetTokens { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Company> Companies { get; set; } // یک شخص حقیقی میتونه صاحب چندتا کمپانی باشه

    #endregion
}
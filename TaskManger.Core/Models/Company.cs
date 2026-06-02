using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Models.BaseModel;

namespace TaskManager.Domain.Models;

public class Company : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MaxLength(300)]
    public string Address { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public DateTime EstablishDate { get; set; }
    [Required]
    public int RegisterationNumber { get; set; }
    [DataType(DataType.Url)]
    public string Blog { get; set; } = string.Empty;
    public Guid? LogoId { get; set; }
    public Guid OwnerId { get; set; }

    #region Navigation Properties
    public Attachment? Logo { get; set; }
    public User Owner { get; set; }
    public List<Department> Departments { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Project> Projects { get; set; }
    #endregion
}
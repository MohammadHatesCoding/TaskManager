using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Models.BaseModel;

namespace TaskManager.Domain.Models;

public class Department : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    public int? ManagerId { get; set; }
    [Required]
    public int CompanyId { get; set; }

    #region Navigation Properties
    public Employee? Manager { get; set; }
    public Company Company { get; set; }
    public List<Employee> Employees { get; set; }
    #endregion
}

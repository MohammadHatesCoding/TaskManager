using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Models.BaseModel;

namespace TaskManager.Domain.Models;

public class ProjectEmployee : BaseEntity
{
    [Required]
    public int ProjectId { get; set; }
    [Required]
    public int EmployeeId { get; set; }

    #region Navigation Properties
    public Project Project { get; set; }
    public Employee Employee { get; set; }
    #endregion
}

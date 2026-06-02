using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Models.BaseModel;

namespace TaskManager.Domain.Models;

public class AssignmentEmployee : BaseEntity
{
    [Required]
    public int AssignmentId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    #region Navigation Properties
    public Assignment Assignment { get; set; }
    public Employee Employee { get; set; }
    #endregion
}

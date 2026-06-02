using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Models.BaseModel;

namespace TaskManager.Domain.Models;

public class Employee : BaseEntity
{
    [Required]
    public int PersonnelCode { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public int Salary { get; set; }
    public int? DepartmentId { get; set; } //اگه کارمند باشه این پر میشه
    public int? CompanyId { get; set; } // برای این اینجاست که تو گزارش گیری های کل کارمندای شرکت دیگه از دپارتمان نیایم لود کنیم
    [DataType(DataType.DateTime)]
    public DateTime ContractStartDate { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime ContractEndDate { get; set; }

    #region Navigation Properties
    public User User { get; set; }
    public Department Department { get; set; }
    public Company Company { get; set; }
    public List<AssignmentEmployee> AssignmentEmployees { get; set; }
    public List<ProjectEmployee> ProjectEmployees { get; set; }
    public List<Comment> Comments { get; set; }
    #endregion
}

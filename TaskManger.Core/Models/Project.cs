
using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Models.BaseModel;
using TaskManager.Shared.Enums;

namespace TaskManager.Domain.Models;

public class Project : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    [Required]
    [MaxLength(500)]
    public string Describtion { get; set; }
    [Required]
    public int CompanyId { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime? EndDate { get; set; }
    public ProjectStatus Status { get; set; }

    #region Navigation Properties
    public Company Company { get; set; }
    public List<ProjectEmployee> ProjectEmployees { get; set; }
    public List<Assignment> Assignments { get; set; }
    #endregion
}
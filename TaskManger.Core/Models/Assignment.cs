using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Models.BaseModel;
using TaskManager.Shared.Enums;

namespace TaskManager.Domain.Models;

public class Assignment : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(700)]
    public string Description { get; set; } = string.Empty;
    
    [DataType(DataType.DateTime)]
    public DateTime Deadline { get; set; }
    
    [Required]
    public AssignmentPriority Priority { get; set; }
    public Status Status { get; set; } = Status.NotStarted;

    [Required]
    public int ProjectId { get; set; }

    #region Navigation Properties
    public Project Project { get; set; }
    public List<Attachment> Attachments { get; set; }
    public List<AssignmentEmployee> AssignmentEmployees { get; set; }
    public List<Comment> Comments { get; set; }
    #endregion
}

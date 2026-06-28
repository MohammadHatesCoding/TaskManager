using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Models.BaseModel;

namespace TaskManager.Domain.Models;

public class Comment : BaseEntity
{
    [Required]
    [MaxLength(1000)]
    public string Content { get; set; } = string.Empty;
    [Required]
    public int AssignmentId { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    public int? RepliedToId { get; set; }//ایدی کامنتی که روش ریپلای شده

    #region Navigation Properties
    public Assignment Assignment { get; set; }
    public Employee Employee { get; set; }
    public List<Attachment> Attachments { get; set; }
    #endregion
}
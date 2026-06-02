using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Models;

public class Attachment
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public int AssignmentId { get; set; }
    [Required]
    public int CommentId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Path { get; set; }
    [Required]
    public string Type { get; set; }
    public bool IsDeleted { get; set; } = false;    

    #region Navigation Properties
    public Assignment Assignment { get; set; }
    public Comment Comment { get; set; }
    #endregion
}

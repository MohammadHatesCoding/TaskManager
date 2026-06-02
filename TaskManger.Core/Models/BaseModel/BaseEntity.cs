namespace TaskManager.Domain.Models.BaseModel;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime? UpdateDate { get; set; }
    public string CreateUser { get; set; } = "System";
    public string UpdateUser { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public bool IsBlocked { get; set; } = false;
    public bool IsActive { get; set; } = true;
}
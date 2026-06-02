namespace TaskManager.Domain.Models.BaseModel;

public interface IBaseEntity
{
    int Id { get; set; }
    DateTime CreateDate { get; set; }
    DateTime? UpdateDate { get; set; }
    string CreateUser { get; set; }
    string UpdateUser { get; set; }
    bool IsDeleted { get; set; }
}

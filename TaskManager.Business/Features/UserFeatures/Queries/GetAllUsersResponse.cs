namespace TaskManager.Business.Features.UserFeatures.Queries;

public record GetAllUsersResponse(Guid Id, string Name, string LastName,/*DateTime LastLogin,*/ bool IsActive, bool IsBlocked);
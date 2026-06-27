using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.RoleFeatures.Queries;

public record GetAllRolesResponse(int Id, string Title, RoleType Type);
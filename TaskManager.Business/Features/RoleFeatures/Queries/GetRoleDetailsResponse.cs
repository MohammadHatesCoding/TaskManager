using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.RoleFeatures.Queries;

public record GetRoleDetailsResponse(int Id, string Title, RoleType Type);
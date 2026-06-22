using TaskManager.Business.Features.UserRoleFeatures.Queries;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public record UpdateUserRequest(Guid Id, string Name, string LastName, string NationalCode, DateTime BirthDate, string Email, string PhoneNumber,
    string Username, bool IsActive, bool IsBlocked, List<GetUserRoleDetailsByUserIdResponse> UserRoles);
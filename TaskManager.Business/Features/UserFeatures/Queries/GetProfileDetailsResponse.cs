using TaskManager.Business.Features.UserRoleFeatures.Queries;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public record GetProfileDetailsResponse(Guid Id, string Name, string LastName, string NationalCode, DateTime BirthDate, string Email, string PhoneNumber,
    string Username, bool IsActive, bool IsBlocked, List<GetUserRoleDetailsByUserIdResponse> UserRoles);
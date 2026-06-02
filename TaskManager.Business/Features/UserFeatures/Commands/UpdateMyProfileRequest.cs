namespace TaskManager.Business.Features.UserFeatures.Commands;

public record UpdateMyProfileRequest(Guid Id, string Name, string LastName, string NationalCode,
    DateTime BirthDate, string Email, string PhoneNumber, string Username);
namespace TaskManager.Business.Features.UserFeatures.Commands;

public record CreateUserRequest(string Name, string LastName, string NationalCode, DateTime BirthDate, string Email, string PhoneNumber);
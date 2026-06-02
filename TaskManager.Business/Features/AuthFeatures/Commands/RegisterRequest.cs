namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record RegisterRequest(string Name, string LastName, string NationalCode, DateTime BirthDate, string Username, string Email, string PhoneNumber);
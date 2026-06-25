namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public record GetEmployeeDetailsResponse(int Id, string Name, string LastName, int Salary, int CompanyId, string CompanyTitle,
    int DepartmentId, string DepartmentTitle, DateTime ContractStartDate, DateTime ContractEndDate, bool IsActive, bool IsBlocked);
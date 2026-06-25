namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public record UpdateEmployeeRequest(int Id, int PersonnelCode, Guid UserId, 
    int Salary, int DepartmentId, int CompanyId);
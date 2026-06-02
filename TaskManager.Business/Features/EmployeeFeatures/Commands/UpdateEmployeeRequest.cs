namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public record UpdateEmployeeRequest(int Id, int PersonnelCode, int UserId, 
    int Salary, int DepartmentId, int CompanyId);
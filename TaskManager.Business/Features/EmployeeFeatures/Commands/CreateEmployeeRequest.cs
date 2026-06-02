namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public record CreateEmployeeRequest(int PersonnelCode, int UserId, int Salary, 
    int DepartmentId, int CompanyId);
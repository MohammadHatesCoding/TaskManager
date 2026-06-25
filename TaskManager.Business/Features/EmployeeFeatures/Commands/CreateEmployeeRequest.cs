namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public record CreateEmployeeRequest(int PersonnelCode, Guid UserId, int Salary, 
    int DepartmentId, int CompanyId, DateTime ContractStartDate, DateTime ContractEndDate);
using AutoMapper;
using TaskManager.Business.Features.AssignmentEmployeeFeatures.Commands;
using TaskManager.Business.Features.AssignmentEmployeeFeatures.Queries;
using TaskManager.Business.Features.AssignmentFeatures.Commands;
using TaskManager.Business.Features.AssignmentFeatures.Queries;
using TaskManager.Business.Features.AuthFeatures.Commands;
using TaskManager.Business.Features.CommentFeatures.Commands;
using TaskManager.Business.Features.CommentFeatures.Queries;
using TaskManager.Business.Features.CompanyFeatures.Commands;
using TaskManager.Business.Features.CompanyFeatures.Queries;
using TaskManager.Business.Features.DepartmentFeatures.Commands;
using TaskManager.Business.Features.DepartmentFeatures.Queries;
using TaskManager.Business.Features.EmployeeFeatures.Commands;
using TaskManager.Business.Features.EmployeeFeatures.Queries;
using TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;
using TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;
using TaskManager.Business.Features.ProjectFeatures.Commands;
using TaskManager.Business.Features.ProjectFeatures.Queries;
using TaskManager.Business.Features.RoleFeatures.Commands;
using TaskManager.Business.Features.RoleFeatures.Queries;
using TaskManager.Business.Features.UserFeatures.Commands;
using TaskManager.Business.Features.UserFeatures.Queries;
using TaskManager.Business.Features.UserRoleFeatures.Commands;
using TaskManager.Business.Features.UserRoleFeatures.Queries;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region AssignmentEmployee Mappers

        CreateMap<CreateAssignmentEmployeeRequest, AssignmentEmployee>();
        CreateMap<CreateAssignmentEmployeeRequest, AssignmentEmployee>().ReverseMap();
        CreateMap<UpdateAssignmentEmployeeRequest, AssignmentEmployee>();
        CreateMap<UpdateAssignmentEmployeeRequest, AssignmentEmployee>().ReverseMap();
        CreateMap<AssignmentEmployee, GetAllAssignmentEmployeesResponse>();

        #endregion

        #region Assignment Mappers

        CreateMap<CreateAssignmentRequest, Assignment>();
        CreateMap<CreateAssignmentRequest, Assignment>().ReverseMap();
        CreateMap<UpdateAssignmentRequest, Assignment>();
        CreateMap<UpdateAssignmentRequest, Assignment>().ReverseMap();
        CreateMap<Assignment, GetAllAssignmentsResponse>();

        #endregion

        #region Auth Mappers

        CreateMap<RegisterRequest, User>();
        
        #endregion

        #region Comment Mappers

        CreateMap<CreateCommentRequest, Comment>();
        CreateMap<CreateCommentRequest, Comment>().ReverseMap();
        CreateMap<UpdateCommentRequest, Comment>();
        CreateMap<UpdateCommentRequest, Comment>().ReverseMap();
        CreateMap<Comment, GetAllCommentsResponse>();

        #endregion

        #region Company Mappers

        CreateMap<CreateCompanyRequest, Company>();
        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
        CreateMap<UpdateCompanyRequest, Company>();
        CreateMap<UpdateCompanyRequest, Company>().ReverseMap();
        CreateMap<Company, GetAllCompaniesResponse>();

        #endregion

        #region Department Mappers

        CreateMap<CreateDepartmentRequest, Department>();
        CreateMap<CreateDepartmentRequest, Department>().ReverseMap();
        CreateMap<UpdateDepartmentRequest, Department>();
        CreateMap<UpdateDepartmentRequest, Department>().ReverseMap();
        CreateMap<Department, GetAllDepartmentsResponse>();

        #endregion

        #region Employee Mappers

        CreateMap<CreateEmployeeRequest, Employee>();
        CreateMap<CreateEmployeeRequest, Employee>().ReverseMap();
        CreateMap<UpdateEmployeeRequest, Employee>();
        CreateMap<UpdateEmployeeRequest, Employee>().ReverseMap();
        CreateMap<Employee, GetAllEmployeesResponse>();

        #endregion

        #region ProjectEmployee Mappers

        CreateMap<CreateProjectEmployeeRequest, ProjectEmployee>();
        CreateMap<CreateProjectEmployeeRequest, ProjectEmployee>().ReverseMap();
        CreateMap<UpdateProjectEmployeeRequest, ProjectEmployee>();
        CreateMap<UpdateProjectEmployeeRequest, ProjectEmployee>().ReverseMap();
        CreateMap<ProjectEmployee, GetAllProjectEmployeesResponse>();

        #endregion

        #region Project Mappers

        CreateMap<CreateProjectRequest, Project>();
        CreateMap<CreateProjectRequest, Project>().ReverseMap();
        CreateMap<UpdateProjectRequest, Project>();
        CreateMap<UpdateProjectRequest, Project>().ReverseMap();
        CreateMap<Project, GetAllProjectsResponse>();

        #endregion

        #region Role Mappers

        CreateMap<CreateRoleRequest, Role>();
        CreateMap<CreateRoleRequest, Role>().ReverseMap();
        CreateMap<UpdateRoleRequest, Role>();
        CreateMap<UpdateRoleRequest, Role>().ReverseMap();
        CreateMap<Role, GetAllRolesResponse>();

        #endregion

        #region User Mappers

        CreateMap<CreateUserRequest, User>();
        CreateMap<CreateUserRequest, User>().ReverseMap();
        CreateMap<UpdateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>().ReverseMap();
        CreateMap<User, GetAllUsersResponse>();

        #endregion

        #region UserRole Mappers

        CreateMap<CreateUserRoleRequest, UserRole>();
        CreateMap<CreateUserRoleRequest, UserRole>().ReverseMap();
        CreateMap<UserRole, GetAllUserRolesResponse>();

        #endregion
    }
}
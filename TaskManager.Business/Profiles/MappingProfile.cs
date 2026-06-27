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

        CreateMap<CreateAssignmentEmployeeRequest, AssignmentEmployee>().ReverseMap();
        CreateMap<GetAllAssignmentEmployeesResponse, AssignmentEmployee>().ReverseMap();
        

        #endregion

        #region Assignment Mappers

        CreateMap<CreateAssignmentRequest, Assignment>().ReverseMap();
        CreateMap<UpdateAssignmentRequest, Assignment>().ReverseMap();
        CreateMap<GetAllAssignmentsResponse, Assignment>().ReverseMap();
        CreateMap<GetAssignmentDetailsResponse, Assignment>()
            .ForMember(x => x.AssignmentEmployees, opt => opt.Ignore())
            .ReverseMap();
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

        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
        CreateMap<UpdateCompanyRequest, Company>().ReverseMap();
        CreateMap<GetAllCompaniesResponse, Company>().ReverseMap();
        CreateMap<GetCompanyDetailsResponse, Company>()
            .ForMember(x => x.Departments, opt => opt.Ignore())
            .ReverseMap();
        #endregion

        #region Department Mappers

        CreateMap<CreateDepartmentRequest, Department>().ReverseMap();
        CreateMap<UpdateDepartmentRequest, Department>().ReverseMap();
        CreateMap<GetAllDepartmentsResponse, Department>().ReverseMap();
        CreateMap<GetAllDepartmentsByCompanyIdResponse, Department>().ReverseMap();
        CreateMap<GetDepartmentDetailsResponse, Department>()
            .ForMember(x => x.Employees, opt => opt.Ignore())
            .ReverseMap();

        #endregion

        #region Employee Mappers

        CreateMap<CreateEmployeeRequest, Employee>().ReverseMap();
        CreateMap<UpdateEmployeeRequest, Employee>().ReverseMap();
        CreateMap<GetAllEmployeesResponse, Employee>().ReverseMap();
        CreateMap<GetEmployeesByDepartmentId, Employee>().ReverseMap();
        CreateMap<GetEmployeeDetailsResponse, Employee>().ReverseMap();

        #endregion

        #region ProjectEmployee Mappers
        
        CreateMap<CreateProjectEmployeeRequest, ProjectEmployee>().ReverseMap();
        
        #endregion

        #region Project Mappers

        CreateMap<CreateProjectRequest, Project>().ReverseMap();
        CreateMap<UpdateProjectRequest, Project>().ReverseMap();
        CreateMap<GetAllProjectsResponse, Project>().ReverseMap();
        CreateMap<GetProjectDetailsResponse, Project>()
            .ForMember(x => x.ProjectEmployees, opt => opt.Ignore())
            .ReverseMap();
        #endregion

        #region Role Mappers

        CreateMap<CreateRoleRequest, Role>().ReverseMap();
        CreateMap<UpdateRoleRequest, Role>().ReverseMap();
        CreateMap<GetAllRolesResponse, Role>().ReverseMap();
        CreateMap<GetRoleDetailsResponse, Role>().ReverseMap();

        #endregion

        #region User Mappers

        CreateMap<CreateUserRequest, User>().ReverseMap();
        CreateMap<UpdateUserRequest, User>()
            .ForMember(x => x.UserRoles, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<User, GetAllUsersResponse>().ReverseMap();
        CreateMap<GetProfileDetailsResponse, User>().ReverseMap();
        CreateMap<UpdateMyProfileRequest, User>().ReverseMap();
        CreateMap<GetUserDetailsResponse, User>().ReverseMap();

        #endregion

        #region UserRole Mappers

        CreateMap<CreateUserRoleRequest, UserRole>().ReverseMap();
        CreateMap<GetUserRolesByRoleIdResponse, UserRole>().ReverseMap();
        CreateMap<GetUserRolesByUserIdResponse, UserRole>().ReverseMap();

        #endregion
    }
}
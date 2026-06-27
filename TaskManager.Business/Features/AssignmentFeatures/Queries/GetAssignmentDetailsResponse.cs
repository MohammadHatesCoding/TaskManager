using System.Net.Mail;
using TaskManager.Business.Features.AssignmentFeatures.Commands;
using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public record GetAssignmentDetailsResponse(int Id, string Title, string Description,
    DateTime Deadline, AssignmentPriority Priority, Status Status, int ProjectId,
    List<GetAllAssignmentEmployeesByAssignmentId> AssignmentEmployees/*, List<Comments>  Comments, List<Attachment> Attachments*/);
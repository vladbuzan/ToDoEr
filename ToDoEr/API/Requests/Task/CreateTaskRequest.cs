using System.ComponentModel.DataAnnotations;
using Domain.Constants;

namespace API.Requests.Task;

public record CreateTaskRequest(
    [Required]
    Guid BoardId,
    [Required]
    [MaxLength(TaskConstants.MaxTitleLength, ErrorMessage = ValidationMessages.StringPropertyIsTooLong)]
    [MinLength(TaskConstants.MinTitleLength, ErrorMessage = ValidationMessages.StringPropertyIsTooShort)]
    string Title,
    [Required]
    [MaxLength(TaskConstants.MaxDescriptionLength, ErrorMessage = ValidationMessages.StringPropertyIsTooLong)]
    string Description);

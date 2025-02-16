using System.ComponentModel.DataAnnotations;
using Domain.Constants;

namespace API.Requests.Board;

public record UpdateBoardRequest(
    [Required]
    [MaxLength(BoardConstants.MaxNameLength, ErrorMessage = ValidationMessages.StringPropertyIsTooLong)]
    [MinLength(BoardConstants.MinNameLength, ErrorMessage = ValidationMessages.StringPropertyIsTooShort)]
    string Name,
    [Required] [MaxLength(BoardConstants.MaxDescriptionLength, ErrorMessage = ValidationMessages.StringPropertyIsTooLong)]
    string Description
);
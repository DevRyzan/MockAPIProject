using Application.Features.MockAPIModels.Commands.Create;
using FluentValidation;

namespace Application.Features.ObjectModels.Commands.Delete;
/// <summary>
/// Id validation class for Delete Command Class
/// </summary>
internal class DeleteObjectCommandValidation : AbstractValidator<DeleteObjectCommand>
{
    public DeleteObjectCommandValidation()
    {
        RuleFor(c => c.ObjectId)
            .NotEmpty()
            .WithMessage("ObjectId is required.")
            .MinimumLength(1)
            .WithMessage("ObjectId must be at least 2 characters long.");

        

    }

}

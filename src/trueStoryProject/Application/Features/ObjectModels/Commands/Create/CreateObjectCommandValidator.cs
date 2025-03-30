using Application.Features.MockAPIModels.Commands.Create;
using FluentValidation;

namespace Application.Features.ObjectModels.Commands.Create;
/// <summary>
/// This class was written for validation of properties in the Create Command.
/// </summary>
public class CreateObjectCommandValidator: AbstractValidator<CreateObjectCommand>
{
    public CreateObjectCommandValidator()
    {
        RuleFor(c => c.CreateObjectDto.Name)
             .NotEmpty()
             .WithMessage("Name is required.")
             .MinimumLength(2)
             .WithMessage("Name must be at least 2 characters long.");

        RuleFor(c => c.CreateObjectDto.CreateDataDto.Year)
             .NotEmpty()
             .WithMessage("Year is required.")
             .Length(4)
             .WithMessage("Year must be exactly 4 characters long.");

        RuleFor(c => c.CreateObjectDto.CreateDataDto.Price)
            .NotEmpty()
            .WithMessage("Price is required.")
            .Must(price => IsValidValue(value:price))
            .WithMessage("Price must be a valid positive number.");
        
        RuleFor(c => c.CreateObjectDto.CreateDataDto.CpuModel)
            .NotEmpty()
            .WithMessage("CpuModel is required.")
            .MinimumLength(1)
            .WithMessage("CpuModel must be at least 1 characters long.");

        RuleFor(c => c.CreateObjectDto.CreateDataDto.HardDiskSize)
            .NotEmpty()
            .WithMessage("HardDiskSize is required.")
            .MinimumLength(1)
            .WithMessage("HardDiskSize must be at least 1 characters long.");
         
    }

    /// <summary>
    /// To parse the String property type to int and check if the value is greater than zero
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private bool IsValidValue(string value)
    {
        if (string.IsNullOrEmpty(value)) return false;

        if (int.TryParse(value, out var result))
        {
            return result > 0; 
        }
        return false; 
    }
}

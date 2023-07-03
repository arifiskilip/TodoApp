using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CreateWorkDtoValidator : AbstractValidator<CreateWorkDto>
    {
        public CreateWorkDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Title).MinimumLength(3);
            RuleFor(x => x.Title).MaximumLength(99);
            RuleFor(x => x.Definition).NotEmpty();
            RuleFor(x => x.Definition).MinimumLength(3);
            RuleFor(x => x.Definition).MaximumLength(99);
        }
    }
}

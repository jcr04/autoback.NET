using autoback.application.Fabricantes.Commands;
using FluentValidation;

namespace autoback.application.Fabricantes.Validators
{
    public class CreateFabricanteValidator : AbstractValidator<CreateFabricanteCommand>
    {
        public CreateFabricanteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(80);
        }
    }
}

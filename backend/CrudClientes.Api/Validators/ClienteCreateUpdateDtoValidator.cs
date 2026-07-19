using CrudClientes.Api.DTOs;
using FluentValidation;

namespace CrudClientes.Api.Validators;

public class ClienteCreateUpdateDtoValidator : AbstractValidator<ClienteCreateUpdateDto>
{
    public ClienteCreateUpdateDtoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(200);

        RuleFor(x => x.Telefone)
            .NotEmpty()
            .MaximumLength(50);
    }
}

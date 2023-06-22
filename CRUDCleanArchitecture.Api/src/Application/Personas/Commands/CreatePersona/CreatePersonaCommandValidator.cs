using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using FluentValidation;

namespace CRUDCleanArchitecture.Application.Personas.Commands.CreatePersona;
internal class CreatePersonaCommandValidator : AbstractValidator<CreatePersonaCommand>
{
    public CreatePersonaCommandValidator()
    {
        RuleFor(v => v.Dni).LessThan(99999999);
    }
}
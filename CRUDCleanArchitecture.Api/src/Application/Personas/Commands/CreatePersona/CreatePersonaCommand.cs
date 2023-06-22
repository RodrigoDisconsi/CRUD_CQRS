using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Application.Common.Interfaces;
using CRUDCleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CRUDCleanArchitecture.Domain.Entities;
using CRUDCleanArchitecture.Domain.Events;
using MediatR;

namespace CRUDCleanArchitecture.Application.Personas.Commands.CreatePersona;
public class CreatePersonaCommand : IRequest<int>
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Dni { get; set; }
}

public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePersonaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
    {
        var entity = new Persona
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            DNI = request.Dni
        };

        entity.AddDomainEvent(new PersonasCreatedEvent(entity));

        _context.Personas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

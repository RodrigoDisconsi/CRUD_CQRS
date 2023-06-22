using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Application.Common.Exceptions;
using CRUDCleanArchitecture.Application.Common.Interfaces;
using CRUDCleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using CRUDCleanArchitecture.Domain.Entities;
using CRUDCleanArchitecture.Domain.Events;
using MediatR;

namespace CRUDCleanArchitecture.Application.Personas.Commands.DeletePersona;
public record DeletePersonaCommand(int Id) : IRequest;

public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePersonaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Personas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Persona), request.Id);
        }

        _context.Personas.Remove(entity);

        entity.AddDomainEvent(new PersonasDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

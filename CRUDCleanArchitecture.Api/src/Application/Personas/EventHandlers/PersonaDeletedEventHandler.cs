using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Application.Common.Models;
using CRUDCleanArchitecture.Application.TodoItems.EventHandlers;
using CRUDCleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CRUDCleanArchitecture.Application.Personas.EventHandlers;
public class PersonaDeletedEventHandler : INotificationHandler<DomainEventNotification<PersonasDeletedEvent>>
{
    private readonly ILogger<PersonaDeletedEventHandler> _logger;

    public PersonaDeletedEventHandler(ILogger<PersonaDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(PersonasDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CRUDCleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }

    public Task Handle(DomainEventNotification<PersonasDeletedEvent> notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CRUDCleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}

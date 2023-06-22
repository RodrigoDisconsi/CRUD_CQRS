using CRUDCleanArchitecture.Domain.Common;

namespace CRUDCleanArchitecture.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCleanArchitecture.Domain.Events;
public class PersonasCreatedEvent : DomainEvent
{
    public PersonasCreatedEvent(Persona persona)
    {
        Persona = persona;
    }

    public Persona Persona { get; }
}

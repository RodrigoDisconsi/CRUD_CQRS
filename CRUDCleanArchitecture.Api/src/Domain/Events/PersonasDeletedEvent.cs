using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCleanArchitecture.Domain.Events;
public class PersonasDeletedEvent : DomainEvent
{
    public PersonasDeletedEvent(Persona persona)
    {
        Persona = persona;
    }

    public Persona Persona { get; }
}

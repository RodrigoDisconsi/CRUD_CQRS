using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Application.Common.Mappings;
using CRUDCleanArchitecture.Domain.Queries;

namespace CRUDCleanArchitecture.Application.Personas.Queries.GetPersonas.Responses;
public class PersonaDto : IMapFrom<PersonaView>
{
    public int PersonaId { get; set; }

    public int DNI { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }
}
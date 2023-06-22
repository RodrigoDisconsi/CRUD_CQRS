using CRUDCleanArchitecture.Application.Common.Models;
using CRUDCleanArchitecture.Application.Common.Wrapper;

namespace CRUDCleanArchitecture.Application.Personas.Queries.GetPersonas.Responses;
public class GetPersonasResponse : Response
{
    public PaginatedList<PersonaDto> Personas { get; set; }
}
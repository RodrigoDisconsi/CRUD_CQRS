using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Application.Common.Models;
using CRUDCleanArchitecture.Application.Personas.Queries.GetPersonas;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;
using CRUDCleanArchitecture.Domain.Queries;

namespace CRUDCleanArchitecture.Application.Common.Interfaces.Repositories;
public interface IPersonasRepository
{
    Task<PaginatedList<PersonaView>> GetPersonas(GetPersonasRequest request);
}

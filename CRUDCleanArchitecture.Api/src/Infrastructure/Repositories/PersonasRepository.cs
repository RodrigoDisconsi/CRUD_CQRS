using Dapper;
using CRUDCleanArchitecture.Application.Common.Interfaces.Repositories;
using CRUDCleanArchitecture.Application.Common.Models;
using CRUDCleanArchitecture.Application.Personas.Queries.GetPersonas;
using CRUDCleanArchitecture.Domain.Queries;
using CRUDCleanArchitecture.Infrastructure.Extensions;
using System;
using System.Data;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Domain.Constants;

namespace CRUDCleanArchitecture.Infrastructure.Repositories;
internal class PersonasRepository : BaseRepository, IPersonasRepository
{
    private readonly IDbConnection _connection;

    public PersonasRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<PaginatedList<PersonaView>> GetPersonas(GetPersonasRequest request)
    {
        DynamicParameters parameters = new DynamicParameters();

        var query = $"SELECT * FROM {ViewConstants.Personas}";
        query += this.AplicarBusqueda(request.TextoBusqueda, parameters, typeof(PersonaView));
        query += string.IsNullOrWhiteSpace(request.OrderCriteria.Column) ? " ORDER BY APELLIDO DESC" :
            String.Format(" ORDER BY {0} {1}", request.OrderCriteria.Column,
                request.OrderCriteria.Ascending ? string.Empty : "DESC");

        return await _connection.PaginatedListAsync<PersonaView>(query, parameters, request.PageNumber, request.PageSize);
    }
}


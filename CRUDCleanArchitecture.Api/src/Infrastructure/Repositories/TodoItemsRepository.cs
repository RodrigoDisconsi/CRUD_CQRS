using Dapper;
using CRUDCleanArchitecture.Application.Common.Interfaces.Repositories;
using CRUDCleanArchitecture.Application.Common.Models;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;
using CRUDCleanArchitecture.Domain.Constants;
using CRUDCleanArchitecture.Domain.Queries;
using CRUDCleanArchitecture.Infrastructure.Extensions;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CRUDCleanArchitecture.Infrastructure.Repositories;
public class TodoItemsRepository : BaseRepository, ITodoItemRepository
{
    private readonly IDbConnection _connection;

    public TodoItemsRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<PaginatedList<TodoItemsView>> GetTodoItems(GetTodoItemsRequest request)
    {
        DynamicParameters parameters = new DynamicParameters();

        var query = $"SELECT * FROM [dbo].[TodoItems]";
        //query += this.AplicarBusqueda(request.TextoBusqueda, parameters, typeof(TodoItemsView));
        query += string.IsNullOrWhiteSpace(request.OrderCriteria.Column) ? " ORDER BY TITLE DESC" :
            String.Format(" ORDER BY {0} {1}", request.OrderCriteria.Column,
                request.OrderCriteria.Ascending ? string.Empty : "DESC");

        return await _connection.PaginatedListAsync<TodoItemsView>(query, parameters, request.PageNumber, request.PageSize);
    }
}

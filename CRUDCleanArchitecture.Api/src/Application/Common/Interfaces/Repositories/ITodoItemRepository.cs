using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Application.Common.Models;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;
using CRUDCleanArchitecture.Domain.Queries;

namespace CRUDCleanArchitecture.Application.Common.Interfaces.Repositories;
public interface ITodoItemRepository
{
    Task<PaginatedList<TodoItemsView>> GetTodoItems(GetTodoItemsRequest request);
}

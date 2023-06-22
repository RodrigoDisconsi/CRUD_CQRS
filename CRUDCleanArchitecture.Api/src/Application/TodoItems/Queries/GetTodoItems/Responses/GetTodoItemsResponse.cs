using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Application.Common.Models;
using CRUDCleanArchitecture.Application.Common.Wrapper;

namespace CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems.Responses;
public class GetTodoItemsResponse : Response
{
    public PaginatedList<TodoItemsDto> TodoItems { get; set; }
}

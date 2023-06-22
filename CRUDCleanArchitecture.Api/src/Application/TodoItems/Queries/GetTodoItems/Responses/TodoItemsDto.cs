using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDCleanArchitecture.Application.Common.Mappings;
using CRUDCleanArchitecture.Domain.Queries;

namespace CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems.Responses;
public class TodoItemsDto : IMapFrom<TodoItemsView>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}

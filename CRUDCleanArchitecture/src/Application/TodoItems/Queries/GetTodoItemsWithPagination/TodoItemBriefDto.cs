using CRUDCleanArchitecture.Application.Common.Mappings;
using CRUDCleanArchitecture.Domain.Entities;

namespace CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;
public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}

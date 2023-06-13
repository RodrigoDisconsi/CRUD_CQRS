﻿using CRUDCleanArchitecture.Application.Common.Mappings;
using CRUDCleanArchitecture.Domain.Entities;

namespace CRUDCleanArchitecture.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}

using AutoMapper;
using CRUDCleanArchitecture.Application.Common.Base;
using CRUDCleanArchitecture.Application.Common.Interfaces.Repositories;
using CRUDCleanArchitecture.Application.Common.Models;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems.Responses;
using MediatR;

namespace CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;
public class GetTodoItemsRequest : PagerBase, IRequest<GetTodoItemsResponse>
{
    public string? TextoBusqueda { get; set; }
}

public class GetTodoItemsRequestHandler : IRequestHandler<GetTodoItemsRequest, GetTodoItemsResponse>
{
    private readonly ITodoItemRepository _todoItemsRepository;
    private readonly IMapper _mapper;

    public GetTodoItemsRequestHandler(ITodoItemRepository todoItemsRepository, IMapper mapper)
    {
        _todoItemsRepository = todoItemsRepository;
        _mapper = mapper;
    }

    public async Task<GetTodoItemsResponse> Handle(GetTodoItemsRequest request, CancellationToken cancellationToken)
    {
        var response = new GetTodoItemsResponse
        {
            TodoItems = (await _todoItemsRepository.GetTodoItems(request)).Map<TodoItemsDto>(_mapper.ConfigurationProvider)
        };
        return await Task.FromResult(response);
    }
}

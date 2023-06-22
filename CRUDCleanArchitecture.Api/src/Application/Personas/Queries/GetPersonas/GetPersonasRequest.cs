using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CRUDCleanArchitecture.Application.Common.Base;
using CRUDCleanArchitecture.Application.Common.Interfaces.Repositories;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems.Responses;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;
using MediatR;
using CRUDCleanArchitecture.Application.Personas.Queries.GetPersonas.Responses;

namespace CRUDCleanArchitecture.Application.Personas.Queries.GetPersonas;
public class GetPersonasRequest : PagerBase, IRequest<GetPersonasResponse>
{
    public string? TextoBusqueda { get; set; }
}

public class GetPersonasRequestHandler : IRequestHandler<GetPersonasRequest, GetPersonasResponse>
{
    private readonly IPersonasRepository _personasRepository;
    private readonly IMapper _mapper;

    public GetPersonasRequestHandler(IPersonasRepository personasRepository, IMapper mapper)
    {
        _personasRepository = personasRepository;
        _mapper = mapper;
    }

    public async Task<GetPersonasResponse> Handle(GetPersonasRequest request, CancellationToken cancellationToken)
    {
        var response = new GetPersonasResponse
        {
            Personas = (await _personasRepository.GetPersonas(request)).Map<PersonaDto>(_mapper.ConfigurationProvider)
        };
        return await Task.FromResult(response);
    }
}


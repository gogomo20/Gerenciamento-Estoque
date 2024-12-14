
using AutoMapper;
using GerenciamentoDeEstoque.Configuration;
using GerenciamentoDeEstoque.Entities;
using GerenciamentoDeEstoque.UseCases.Users.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeEstoque.UseCases.Users.Queries;

public class GetUserByIdQuery : IRequest<UserResponse>
{
    public long Id { get; set; }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Id == request.Id);
            return _mapper.Map<UserResponse>(user);
        }
    }
}
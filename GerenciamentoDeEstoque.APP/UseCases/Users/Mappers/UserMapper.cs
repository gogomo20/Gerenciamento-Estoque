using AutoMapper;
using GerenciamentoDeEstoque.Entities;
using GerenciamentoDeEstoque.UseCases.Users.Responses;

namespace GerenciamentoDeEstoque.UseCases.Users.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserResponse>();
    }
}
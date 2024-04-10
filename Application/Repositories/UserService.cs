using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Repositories
{
    internal class UserService(IRepository<UserEntity> repository, IMapper mapper) : BaseService<UserEntity, UserModel>(repository, mapper), IUserService
    {
    }
}

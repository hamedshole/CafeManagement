using Domain.Entities;
using Shared.Model;

namespace Application.Interfaces
{
    public interface IUserService:IBaseService<UserEntity,UserModel>
    {
    }
}

using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Repositories
{
    internal class UnitService(IRepository<UnitEntity> repository, IMapper mapper) : BaseService<UnitEntity, UnitModel, UnitDetailModel>(repository, mapper), IUnitService
    {
       
    }
}

using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Repositories
{
    internal class FactorService(IRepository<InventoryFactorEntity> repository, IMapper mapper) : BaseService<InventoryFactorEntity, FactorModel>(repository, mapper), IFactorService
    {
    }
}

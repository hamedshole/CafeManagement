using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Repositories
{
    internal class InventoryService(IRepository<InventoryEntity> repository, IMapper mapper) : BaseService<InventoryEntity, InventoryModel>(repository, mapper), IInventoryService
    {
    }
}

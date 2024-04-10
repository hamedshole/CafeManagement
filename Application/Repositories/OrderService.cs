using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Repositories
{
    internal class OrderService(IRepository<OrderEntity> repository, IMapper mapper) : BaseService<OrderEntity, OrderModel>(repository, mapper), IOrderService
    {
    }
}

using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Repositories
{
    internal class CustomerService(IRepository<CustomerEntity> repository, IMapper mapper) : BaseService<CustomerEntity, CustomerModel>(repository, mapper), ICustomerService
    {
    }
}

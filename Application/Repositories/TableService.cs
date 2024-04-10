using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Model;

namespace Application.Services
{
    internal class TableService(IRepository<TableEntity> repository,IMapper mapper) : BaseService<TableEntity, TableModel>(repository,mapper), ITableService
    {
    }
}

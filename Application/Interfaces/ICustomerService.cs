using Domain.Entities;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomerService:IBaseService<CustomerEntity,CustomerModel>
    {
    }
}

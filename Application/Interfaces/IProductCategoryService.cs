﻿using Domain.Entities;
using Shared.Model;

namespace Application.Interfaces
{
    public interface IProductCategoryService:IBaseService<ProductCategoryEntity,ProductCategoryModel>
    {
        Task UpdateOrder(UpdateCategoryOrderParameterCollection parameters);
    }
}

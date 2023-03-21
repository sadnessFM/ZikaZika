﻿using ZikaZika.Shared.DTO;
using ZikaZika.Shared.Models;

namespace ZikaZika.Client.Repositories.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceModel<Category>> AddCategory(Category newCategory);
        Task<ServiceModel<Category>> DeleteCategory(int id);
        Task<ServiceModel<Category>> UpdateCategory(Category newCategory);
        Task<ServiceModel<Category>> GetCategory(int id);
        Task<ServiceModel<Category>> GetCategories();
    }
}

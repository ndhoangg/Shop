using System;
using DAL.Repositories.Interface;
using DTO.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class CategoryRepository : RepositoryBase<Category>,ICategoryRepository
	
    {
		public CategoryRepository(DbContext context) : base(context) { }

        
    }
}


using System;
using DAL.Repositories.Interface;
using DTO.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class ProductRepository : RepositoryBase<Product>,IProductRepository
	
    {
		public ProductRepository(DbContext context) : base(context) { }

        
    }
}


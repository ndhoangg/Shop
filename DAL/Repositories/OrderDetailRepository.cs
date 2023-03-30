using System;
using DAL.Repositories.Interface;
using DTO.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class OrderDetailRepository : RepositoryBase<OrderDetail>,IOrderDetailRepository
	
    {
		public OrderDetailRepository(DbContext context) : base(context) { }

        
    }
}


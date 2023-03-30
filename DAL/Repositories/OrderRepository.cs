using System;
using DAL.Repositories.Interface;
using DTO.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class OrderRepository : RepositoryBase<Order>,IOrderRepository
	
    {
		public OrderRepository(DbContext context) : base(context) { }

        
    }
}


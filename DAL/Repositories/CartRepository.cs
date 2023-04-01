using System;
using DAL.Repositories.Interface;
using DTO.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class CartRepository : RepositoryBase<CartItem>,ICartItemRepository
	
    {
		public CartRepository(DbContext context) : base(context) { }

        
    }
}

    
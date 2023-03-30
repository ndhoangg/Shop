using System;
using DAL.Repositories.Interface;

namespace DAL.Interface
{
	public interface IUnitOfWork
	{
        IProductRepository ProductRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IOrderDetailRepository OrderDetailRepository { get; }

        IOrderRepository OrderRepository { get; }

        ICartRepository CartRepository { get; }

        void SaveChanges();
	}
}


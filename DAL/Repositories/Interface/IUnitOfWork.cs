using System;
namespace DAL.Interface
{
	public interface IUnitOfWork
	{
		IMemberRepository MemberRepository { get; }

		void SaveChanges();
	}
}


using System;
using DAL.Interface;
using DTO;
using DTO.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class MemberRepository : RepositoryBase<User>, IMemberRepository
	{
		public MemberRepository(DbContext context) : base(context)
		{

		}
	}
}


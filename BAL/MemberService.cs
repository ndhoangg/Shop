using System;
using BAL.Interfaces;
using DAL.Interface;
using DTO.Entity;

namespace BAL
{
	public class MemberService : IMemberService
	{
		//private readonly IMemberRepository _memberRepository;

		private readonly IUnitOfWork _unitOfWork;

		public MemberService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public User GetId(int id)
		{
			return _unitOfWork.MemberRepository.GetId(id);
		}

	}
}


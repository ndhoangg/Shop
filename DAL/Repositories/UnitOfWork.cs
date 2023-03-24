using System;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly DbContext _context;
        private IMemberRepository? _memberRepository;
      
        public UnitOfWork(DbContext context)
        {
            _context = context;
           // MemberRepository = memberRepository;
        }



        public IMemberRepository MemberRepository
        {
            get
            {
                if (_memberRepository == null)
                {
                    _memberRepository = new MemberRepository(_context);
                }
                return _memberRepository;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}


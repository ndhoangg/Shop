using System;
using DTO.Entity;

namespace BAL.Interfaces
{
	public interface IMemberService
	{
       // IEnumerable<Member> GetAll();
        // Member GetByName(string productName);
        //IEnumerable<Member> GetListByName(string productName);
        User GetId(int id);
    }
}


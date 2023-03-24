using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DTO.Entity
{
	public class MyDbContext : IdentityDbContext<User>
	{
		
		public MyDbContext(DbContextOptions opt) : base(opt)
		{

		}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // You don't actually ever need to call this
        //}

        public DbSet<Cart>? Cart { get; set; }
		
	}
}


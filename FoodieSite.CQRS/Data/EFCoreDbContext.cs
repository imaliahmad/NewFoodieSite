using FoodieSite.CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Data
{
	public class EFCoreDbContext:DbContext
	{
		public EFCoreDbContext()
		{

		}
		public DbSet<RestaurantMaster> RestaurantMaster { get; set; }
	}
}

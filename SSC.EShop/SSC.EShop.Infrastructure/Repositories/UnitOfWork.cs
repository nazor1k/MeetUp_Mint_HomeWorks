using SSC.EShop.Core.Interfaces;
using SSC.EShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.EShop.Infrastructure.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly EshopDbContext _context;
        public UnitOfWork(EshopDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}

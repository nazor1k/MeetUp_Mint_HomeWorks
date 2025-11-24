using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.EShop.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangesAsync();

    }
}

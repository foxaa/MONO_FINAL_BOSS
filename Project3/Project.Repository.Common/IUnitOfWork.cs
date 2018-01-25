using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace Project.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Save();
        void Dispose(bool disposed);
    }
}

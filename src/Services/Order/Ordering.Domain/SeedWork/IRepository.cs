using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.SeedWork
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

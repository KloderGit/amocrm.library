using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Interfaces
{
    internal interface IRepositoryCreator
    {
        IQueryableRepository<T> GetRepository<T>();
    }
}

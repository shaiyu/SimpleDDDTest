using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void Commit();

        void Rollback();

    }
}

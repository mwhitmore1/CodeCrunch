using CodeCrunch.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCrunch.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly UserContext _dataContext;

        public UserContext GetDataContext()
        {
            return _dataContext ?? new UserContext();
        }

        public DatabaseFactory()
        {
            _dataContext = new UserContext();
        }

        protected override void DisposeCore()
        {
            _dataContext.Dispose();
        }
    }
}

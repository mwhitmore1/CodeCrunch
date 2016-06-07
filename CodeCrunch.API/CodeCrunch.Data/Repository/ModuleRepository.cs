using CodeCrunch.Core.Domain;
using CodeCrunch.Core.Repository;
using CodeCrunch.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCrunch.Data.Repository
{
    public class ModuleRepository : Repository<Module>, IModuleRepository
    {
        public ModuleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}

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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}

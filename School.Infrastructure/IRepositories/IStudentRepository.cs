using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.IRepositories
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        IQueryable<Student> GetQueryableStudentPaginated(Expression<Func<Student, bool>> filterExpression);

    }
}

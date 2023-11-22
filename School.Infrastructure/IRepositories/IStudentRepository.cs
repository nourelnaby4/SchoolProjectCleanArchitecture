using School.Data.Entities;
using System.Linq.Expressions;

namespace School.Infrastructure.IRepositories
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        IQueryable<Student> GetQueryableStudentPaginated(Expression<Func<Student, bool>> filterExpression);

    }
}

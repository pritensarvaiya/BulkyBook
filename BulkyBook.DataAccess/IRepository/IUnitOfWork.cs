using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository CoverType { get; }
        IEmployeeRepository Employee { get; }
        IDepartmentRepository Department { get; }
        IUserRepository User { get; }
        IFeeCollectionRepository FeeCollection { get; }
        void Save();
    }
}

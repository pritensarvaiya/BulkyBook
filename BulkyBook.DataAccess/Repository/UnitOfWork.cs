using BulkyBook.Data;
using BulkyBook.DataAccess.IRepository;
using BulkyBook.Models;
using DemoWebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category{get;private set;}
        public ICoverTypeRepository CoverType{get;private set;}
		public IEmployeeRepository Employee { get; private set; }
		public IDepartmentRepository Department { get; private set; }
		public IUserRepository User { get; private set; }
		public IFeeCollectionRepository FeeCollection { get; private set; }

		private protected ApplicationDbContext _context;
		private readonly DapperContext _dapperContext;
		public UnitOfWork(ApplicationDbContext context, DapperContext dapperContext)
        {
            _context = context;
			_dapperContext = dapperContext;
			Category = new CategoryRepository(_context,_dapperContext);
            CoverType = new CoverTypeRepository(_context);
            Employee = new EmployeeRepository(_context);
			Department = new DepartmentRepository(_context);
            User=new UserRepository(_context);
            FeeCollection = new FeeCollectionRepository(_context);
		}

        void IUnitOfWork.Save()
        {
            _context.SaveChanges();
        }
    }
}

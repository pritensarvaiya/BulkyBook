using BulkyBook.Data;
using BulkyBook.DataAccess.IRepository;
using BulkyBook.Models;
using DemoWebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
		private readonly DapperContext _dapperContext;

		public CategoryRepository(ApplicationDbContext context, DapperContext dapperContext) : base(context) 
        {
            _context = context;
			_dapperContext = dapperContext;
		}
        public void Update(Category category)
        {
            /* Not a right way to update records */
            //_context.Categories.Update(category); 
            var categoryFromDB = _context.Categories.FirstOrDefault(u => u.Id == category.Id);
            if (categoryFromDB != null)
            {
                categoryFromDB.Name = category.Name;
                categoryFromDB.DisplayOrder = category.DisplayOrder;
            }
        }

        public async Task<List<Category>> getCategoriesDemo()
        {
			using var connection = _dapperContext.CreateConnection();
			var query = "sp_get_category_details";
			var users = await connection.QueryAsync<Category>(query, new { id = 0 },commandType: CommandType.StoredProcedure);
			var multi = await connection.QueryMultipleAsync(query, new { id = 0 },commandType:CommandType.StoredProcedure);
			return users.ToList();
		}
    }
}
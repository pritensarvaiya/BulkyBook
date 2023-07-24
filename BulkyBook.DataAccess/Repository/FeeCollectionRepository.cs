using BulkyBook.Data;
using BulkyBook.DataAccess.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class FeeCollectionRepository : Repository<FeeCollection>, IFeeCollectionRepository
    {
        public FeeCollectionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

using Library.Data.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Bussiness
{
    public class BaseService<T> : Service<T> where T : class
    {
        public BaseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

using RESTAPI.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPI.DataAccess.Abstract
{
    public interface IBaseRepository<T>:IReadAccess<T>
    {
        Task<bool> CreateByAddRange(List<T> entity);
        Task<int> GetCount();
    }
}

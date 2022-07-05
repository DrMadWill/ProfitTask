using RESTAPI.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPI.DataAccess.Abstract
{
    public interface IReadAccess<T>
    {
        Task<List<T>> GetAll();
        IQueryable<T> GetAllQuery();

    }
}

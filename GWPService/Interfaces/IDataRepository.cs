using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GWPService.Interfaces
{
    public interface IDataRepository<T>
    {
        Task<IEnumerable<T>> GetAllWhere(string country, string[] lob);
    }
}

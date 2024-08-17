using Store.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Abstractions
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
    }
}

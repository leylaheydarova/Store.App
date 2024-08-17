using Store.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Abstractions
{
    public interface IReadRepository<T>:IRepository<T> where T : BaseEntity
    {

    }
}

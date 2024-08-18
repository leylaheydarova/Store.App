using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Abstractions
{
    internal interface ICategoryReadRepository:IReadRepository<Category>
    {
    }
}

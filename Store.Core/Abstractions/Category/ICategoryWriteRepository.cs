using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Abstractions
{
    public interface ICategoryWriteRepository:IWriteRepository<Category>
    {
    }
}

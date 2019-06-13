using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdinLib.Interfaces
{
    public interface IEdin
    {
        IEnumerable<string> GetList();
    }
}

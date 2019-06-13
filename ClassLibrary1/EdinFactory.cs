using EdinLib.Helpers;
using EdinLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdinLib
{
    public static class EdinFactory
    {
        public static IEdin CreateEdin() => new EdinHelper();
    }
}

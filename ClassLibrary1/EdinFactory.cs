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
        public static IEdin CreateEdin() => new EdinHelper("uaunicom", "80d10ffd63edf7fd340f120e0fa480a0");
    }
}

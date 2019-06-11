using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.edinsoap;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Edin edin = new Edin();
            edinsoap.ServiceWsService serv = new ServiceWsService();
            getListRequest request = new getListRequest();

            request.user = new ediLogin() { login = "uaunicom", pass = "80d10ffd63edf7fd340f120e0fa480a0" };//pass = "e50326d7738278dffc3e8d82e73be8f10"};
            var resp = serv.getList(request);
        }
    }
}

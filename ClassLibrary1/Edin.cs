using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdinLib.EdinServiceReference;


namespace EdinLib
{
    public class Edin
    {
        public Edin()
        {
            ServiceWsClient srvClient = new ServiceWsClient();
            srvClient.Open();
            getListRequest request = new getListRequest();

            request.user = new ediLogin() {login = "uaunicom", pass = "e50326d7738278dffc3e8d82e73be8f1" };//pass = "e50326d7738278dffc3e8d82e73be8f10"};
            //request.user.login = "uaunicom";
            //request.user.pass = "e50326d7738278dffc3e8d82e73be8f1";//uaunicom2
            var responce = srvClient.getList(request);
        }
    }
}

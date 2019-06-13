using EdinLib.EdinServiceReference;
using EdinLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdinLib.Helpers
{
    internal class EdinHelper : EdinHelperBase, IEdin
    {
        public EdinHelper(string login, string password) : base(login, password)
        {

        }

        private ServiceWsClient getSeriveClient()
        {
            var serviceClient =  new ServiceWsClient();
            serviceClient.Open();
            return serviceClient;
        }

        public IEnumerable<string> GetList()
        {
            var serviceClient = getSeriveClient();
            getListRequest request = new getListRequest();
            request.user = new ediLogin() { login = this.Login, pass = this.Password};
            var responce = serviceClient.getList(request);
            if (responce.result.errorCode == 0)
            {
                return responce.result.list;
            }
            else
            {
                throw new Exception($"Error: {responce.result.errorMessage} Error code: {responce.result.errorCode}");
            }
        }
    }
}

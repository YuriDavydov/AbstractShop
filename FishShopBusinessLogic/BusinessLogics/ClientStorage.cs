using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogics
{
    public class ClientStorage : IClientStorage
    {
        private Dictionary<string, Client> _clients = new Dictionary<string, Client>();
        public Client GetElement(ClientBindingModel clientBindingModel)
        {
            if (!_clients.TryGetValue(clientBindingModel.Email, out Client client))
            {
                client = new Client() { Id = _clients.Count };
                _clients.Add(clientBindingModel.Email, client);
            }
            return client;
        }
    }
}

using BusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IClientStorage
    {
        Client GetElement(ClientBindingModel clientBindingModel);
    }
}

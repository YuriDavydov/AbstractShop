using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientLogic _logic;
        public ClientController(ClientLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public async Task<ClientViewModel?> Login(string login, string password) => await _logic.getUser(new
ClientBindingModel
        { Login = login, Password = password });
        
        [HttpPost]
        public async Task Register(ClientBindingModel model) => await _logic.Create(model);
        
        [HttpPut]
        public async Task UpdateData(ClientBindingModel model) => await _logic.Update(model);

        [HttpDelete]
        public async Task DeleteData(string login) => await _logic.Delete(login);

    }
}

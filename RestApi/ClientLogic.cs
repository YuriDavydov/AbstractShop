using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace RestApi
{
    public class ClientLogic
    {
        public async Task<ClientViewModel?> getUser(ClientBindingModel clientBindingModel)
        {
            using var connection = new Database();
            return await connection.Users
               .Where(user => user.Login == clientBindingModel.Login && user.Password == clientBindingModel.Password)
               .Select(user => new ClientViewModel
               {
                   Email = user.Login,
                   Password = user.Password
               })
               .SingleOrDefaultAsync();
        }

        public async Task Create(ClientBindingModel clientBindingModel) 
        {
            using var connection = new Database();
            User user = new User();
            user.Login = clientBindingModel.Login;
            user.Password = clientBindingModel.Password;
            connection.Users.Add(user);
            await connection.SaveChangesAsync();
        }

        public async Task Update(ClientBindingModel clientBindingModel)
        {
            using var connection = new Database();
            var user = await connection.Users.FindAsync(clientBindingModel.Login);
            if (user != null)
            {
                user.Password = clientBindingModel.Password;
                connection.Users.Update(user);
                await connection.SaveChangesAsync();
            }
        }

        public async Task Delete(string login)
        {
            using var connection = new Database();
            var user = await connection.Users.FindAsync(login);
            if (user != null)
            {
                connection.Users.Remove(user);
                await connection.SaveChangesAsync();
            }
        }

    }
}

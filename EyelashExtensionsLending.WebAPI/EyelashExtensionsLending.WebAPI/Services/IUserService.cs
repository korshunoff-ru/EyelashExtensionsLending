using System.Collections.Generic;
using EyelashExtensionsLending.WebAPI.Entities;

namespace EyelashExtensionsLending.WebAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
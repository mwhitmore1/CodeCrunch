using CodeCrunch.Core.Domain;
using CodeCrunch.Core.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCrunch.Core.Repository
{
    public interface IAuthorizationRepository : IDisposable
    {
        Task<IdentityResult> RegisterUser(BootcampRegistrationModel userModel);

        Task<User> FindUser(string userName, string password);
        Task<User> FindUserByIdAsync(int id);
        Task<User> FindUserByName(string name);
        
    }
}

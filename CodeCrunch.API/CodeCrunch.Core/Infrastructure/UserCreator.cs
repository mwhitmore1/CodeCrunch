using CodeCrunch.Core.Domain;
using CodeCrunch.Core.Models;

namespace CodeCrunch.Core.Infrastructure
{
    public class UserCreator
    {
        public User CreateUser(BootcampRegistrationModel model)
        {
            return new Bootcamp()
            {
                BootcampName = model.BootcampName,
                UserName = model.EmailAddress,
                Email = model.EmailAddress,
                BootcampState = model.BootcampState
            };
        }
    }
}
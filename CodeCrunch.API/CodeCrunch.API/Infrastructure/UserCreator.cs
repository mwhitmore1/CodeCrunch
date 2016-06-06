using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCrunch.API.Models;

namespace CodeCrunch.API.Infrastructure
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
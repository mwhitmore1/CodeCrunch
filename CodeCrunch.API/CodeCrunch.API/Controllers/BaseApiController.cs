using CodeCrunch.API.Infrastructure;
using CodeCrunch.Core.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CodeCrunch.API.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly IUserRepository _userRepository;

        protected BaseApiController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string i in result.Errors)
                    {
                        ModelState.AddModelError("", i);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
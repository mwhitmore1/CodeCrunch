using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using CodeCrunch.API.Infrastructure;
using CodeCrunch.API.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeCrunch.API.Controllers
{
    [RoutePrefix("Account")]
    public class AccountsController : BaseApiController
    {
        private AuthorizationRepository _repo = new AuthorizationRepository();
        
        [Authorize(Roles = "Admin")]
        [Route("user/{id.guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {
            User appUser = await _repo.FindUserByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            IList<string> currentRoles = await _repo.GetUsersRolesById(appUser.Id);

            // rolesNotExist will only have a value if the role to be added does not exist. 
            var rolesNotExist = rolesToAssign.Except(_repo.GetRoles().Select(x => x.Name)).ToArray();

            if (rolesNotExist.Count() > 0)
            {
                ModelState.AddModelError("", string.Format("Roles '{0}' does not exist in the system", string.Join(",", rolesNotExist)));
                return BadRequest(ModelState);
            }

            IdentityResult removeResult = await _repo.RemoveUserFromRoleAsync(appUser.Id, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await _repo.AddUserToRolesAsyc(appUser.Id, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();
        }

        //POST Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(BootcampRegistrationModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
    }
}

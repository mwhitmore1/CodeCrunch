using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace CodeCrunch.API.Models
{
    public class RoleModelFactory
    {
        public RoleReturnModel Create(IdentityRole appRole)
        {
            UrlHelper _UrlHelper = new UrlHelper();
            return new RoleReturnModel()
            {
                Url = _UrlHelper.Link("GetRoleById", new { id = appRole.Id }),
                Id = appRole.Id,
                Name = appRole.Name
            };
        }
    }

    public class RoleReturnModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
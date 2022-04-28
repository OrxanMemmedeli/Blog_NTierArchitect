using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace Blog_NTierArchitect.Customattributes
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] Roles;
        public CustomAuthorizeAttribute(string roles)
        {
            Roles = roles.Split(",");
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var originalUrl = context.HttpContext.Request.Path.ToUriComponent();
            var userInRole = false;
            foreach (var item in Roles)
            {
                userInRole = context.HttpContext.User.IsInRole(item.Trim());
                if (userInRole)
                    break;
            }

            if (!userInRole)
            {
                //context.Result = new RedirectResult(originalUrl);
                //context.Result = new RedirectToRouteResult(originalUrl);
                context.Result = new RedirectResult("/Account/AccessDenied");

            }

        }
    }
}

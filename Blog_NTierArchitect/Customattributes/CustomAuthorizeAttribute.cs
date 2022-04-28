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
[CustomAuthorize("Admin")]   Roles = roles.Split(",");
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
[CustomAuthorize("Admin")]   var originalUrl = context.HttpContext.Request.Path.ToUriComponent();
[CustomAuthorize("Admin")]   var userInRole = false;
[CustomAuthorize("Admin")]   foreach (var item in Roles)
[CustomAuthorize("Admin")]   {
[CustomAuthorize("Admin")]       userInRole = context.HttpContext.User.IsInRole(item);
[CustomAuthorize("Admin")]       if (userInRole)
[CustomAuthorize("Admin")][CustomAuthorize("Admin")]  break;
[CustomAuthorize("Admin")]   }

[CustomAuthorize("Admin")]   if (!userInRole)
[CustomAuthorize("Admin")]   {
[CustomAuthorize("Admin")]       //context.Result = new RedirectResult(originalUrl);
[CustomAuthorize("Admin")]       //context.Result = new RedirectToRouteResult(originalUrl);
[CustomAuthorize("Admin")]       context.Result = new RedirectResult("/Account/AccessDenied");

[CustomAuthorize("Admin")]   }

        }
    }
}

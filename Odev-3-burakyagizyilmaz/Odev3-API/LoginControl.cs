using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Odev3_Data;
using System;
using System.Linq;

namespace Odev3_API
{
    public class LoginControl : Attribute, IActionFilter
    {
        private readonly AppDbContext _dbContext;
        private readonly int[] _userGroups;

        public LoginControl(int[] userGroup)
        {
            _dbContext = new AppDbContext();
            _userGroups = userGroup;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            string mail = context.HttpContext.Request.Query["email"].ToString();
            string password = context.HttpContext.Request.Query["password"].ToString();

            if (_dbContext.Users.Any(x => x.Email == mail && x.Password == password))
            {
                //string actionName = context.RouteData.Values["action"].ToString();
                //string controllerName = context.RouteData.Values["controller"].ToString();
                int userGroupId = _dbContext.Users.Single(x => x.Email == mail && x.Password == password).Id;

                if (_userGroups.Contains(userGroupId))
                {
                    //Continue
                }

                else
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Error" }, { "action", "Error" } });
                }
            }

            else
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Error" }, { "action", "Error" } });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}

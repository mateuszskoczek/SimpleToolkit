using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToolkit.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiresClaimAttribute : Attribute, IAuthorizationFilter
    {
        #region FIELDS

        private readonly Predicate<Claim> _predicate;

        #endregion



        #region CONSTRUCTORS

        public RequiresClaimAttribute(Predicate<Claim> predicate)
        {
            _predicate = predicate;
        }

        #endregion



        #region PUBLIC METHODS

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.HasClaim(_predicate))
            {
                context.Result = new ForbidResult();
            }
        }

        #endregion
    }
}

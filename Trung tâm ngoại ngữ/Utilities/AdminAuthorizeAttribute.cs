using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LinguaCenter.Utilities;
public class AdminAuthorizeAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!Function.IsLogin())
        {
            context.Result = new RedirectToActionResult(
                "Index",
                "Login",
                new { area = "Admin" }
            );
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsApp.Filters
{
    public class GlobalModelStateValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Controller controller = context.Controller as Controller;
                object model = context.ActionArguments.Any()
                   ? context.ActionArguments.First().Value
                   : null;

                context.Result = (IActionResult)controller?.View(model)
                   ?? new BadRequestResult();
            }

            base.OnActionExecuting(context);
        }
    }
}

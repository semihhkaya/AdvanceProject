using AdvanceProject.Bll.Abstract;
using AdvanceProject.Dal.UnitofWork;
using AdvanceProject.Dto.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace AdvanceProject.API.Filters
{
	public class EmailUniqueCheckAttribute:ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
            var employeeManager = (IEmployeeManager)context.HttpContext.RequestServices.GetService(typeof(IEmployeeManager));

            var unitOfWork = (IUnitOfWork)context.HttpContext.RequestServices.GetService(typeof(IUnitOfWork));

            if (context.ActionArguments.TryGetValue("dto", out object dtoObject) &&
                dtoObject is EmployeeRegisterDTO dto)
            {
                var existingUser = await employeeManager.GetUserByMail(dto.Email);
                if (existingUser.Success)
                {
                    context.Result = new BadRequestObjectResult(existingUser.Message);

                    return;
                }
            }

            await base.OnActionExecutionAsync(context, next);
        }
	}
}

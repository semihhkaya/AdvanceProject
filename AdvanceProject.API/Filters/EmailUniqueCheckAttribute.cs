using AdvanceProject.Bll.Abstract;
using AdvanceProject.Dal.UnitofWork;
using AdvanceProject.Dto.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceProject.API.Filters
{
	public class EmailUniqueCheckAttribute:ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
            var employeeManager = (IEmployeeManager)context.HttpContext.RequestServices.GetService(typeof(IEmployeeManager));

            var unitOfWork = (IUnitOfWork)context.HttpContext.RequestServices.GetService(typeof(IUnitOfWork));


            // E-posta adresi al
            if (context.ActionArguments.TryGetValue("dto", out object dtoObject) &&
                dtoObject is EmployeeRegisterDTO dto)
            {
                var existingUser = await employeeManager.GetUserByMail(dto.Email);
                if (existingUser.Success)
                {
                    //zaten kayıtlı ise
                    context.Result = new BadRequestObjectResult(existingUser.Message);
                    return;
                }
            }

            // Eğer e-posta kontrolü başarılı ise işleme devam et
            await base.OnActionExecutionAsync(context, next);
        }
	}
}

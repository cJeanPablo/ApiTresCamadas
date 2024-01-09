﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected bool OperacaoValida()
        {
            
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida()) 
            {
                return new ObjectResult(result);
            }

            return BadRequest(new
            {

            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!ModelState.IsValid) {}
            return CustomResponse(modelState);
        }

        protected void NotificarErro(string mensagem)
        {

        }
    }
}

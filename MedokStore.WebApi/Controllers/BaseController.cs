﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedokStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[aclion]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

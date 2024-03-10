using System;
using OrderPurches.WebApi.Features.Common.Entities;
using OrderPurches.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace OrderPurches.WebApi.Features.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly CommonService _commonService;
        public CommonController(CommonService commonService)
        {
            _commonService = commonService;
        }      
     

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OrderPurches.WebApi.Features.Common.Dto;
using OrderPurches.WebApi.Features.Common.Entities;
using OrderPurches.WebApi.Helpers;
using OrderPurches.WebApi.Infraestructure;
using Microsoft.AspNetCore.Http;

namespace OrderPurches.WebApi.Features.Common
{
    public class CommonService
    {
        private readonly OrderPurchesDbContext _OrderPurchesDbContext;
        public CommonService(OrderPurchesDbContext logisticaBtdDbContext)
        {
            _OrderPurchesDbContext = logisticaBtdDbContext;
        }
 
  
     

       
       
        
       
        

    }
}

using OrderPurches.WebApi.Features.DataMaster.Services;
using Microsoft.AspNetCore.Mvc;

namespace OrderPurches.WebApi.Features.DataMaster
{
    [ApiController]
    [Route("[controller]")]
    public class DataMasterController : ControllerBase
    {

        private readonly DataMasterService _dataMasterService;

        public DataMasterController(DataMasterService dataMasterService)
        {
            _dataMasterService = dataMasterService;
        }

        //[HttpGet("GetItems")]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        var result = _dataMasterService.GetItems();
        //        return Ok(result);
        //    }
        //    catch (System.Exception ex)
        //    {

        //        return BadRequest(new { mesagge = ex.Message });
        //    }
        //}

        //[HttpGet("GetSupplier")]
        //public IActionResult GetSupplier()
        //{
        //    try
        //    {
        //        var result = _dataMasterService.GetSupplir();
        //        return Ok(result);
        //    }
        //    catch (System.Exception ex)
        //    {

        //        return BadRequest(new { mesagge = ex.Message });
        //    }
        //}

    }
}

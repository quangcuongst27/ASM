using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Enum;
using DataService.Models.Filter;
using DataService.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Web.API.Controllers
{
    //[Authorize]
    [Route("api/around_provider")]
    [ApiController]
    public class AroundProviderController : ControllerBase
    {
        private readonly AroundProviderService _service;
        public AroundProviderController(AroundProviderService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAroundProviderById(int id)
        {
            var result = _service.GetAroundProviderById(id);
            if (result == null)
            {
                return new JsonResult(new
                {
                    status = StatusMessage.FAILED,
                    message = "ID not exist"
                });
            }
            else
            {
                return new JsonResult(new
                {
                    status = StatusMessage.SUCCESS,
                    message = "Get around provider by id success",
                    data = result
                });


            }

        }
        [HttpGet]
        public IActionResult GetAroundProviderByFilter([FromQuery]AroundPrividerGetFilter filter)
        {
            var result = _service.GetAllAroundProvider(filter).ToList();
            if (result.Count == 0)
            {
                return new JsonResult(new
                {
                    status = StatusMessage.FAILED,
                    message = "Data is empty"
                });
            }
            else
            {

                return new JsonResult(new
                {
                    status = StatusMessage.SUCCESS,
                    message = "Get all around provider success",
                    data = result
                });
            }
        }
    }
}
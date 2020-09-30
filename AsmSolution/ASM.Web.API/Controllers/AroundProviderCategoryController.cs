using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Enum;
using DataService.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Web.API.Controllers
{
    //[Authorize]
    [Route("api/around_provider_category")]
    [ApiController]
    public class AroundProviderCategoryController : ControllerBase
    {
        private readonly AroundProviderCategoryService _service;
        public AroundProviderCategoryController(AroundProviderCategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAroundProviderCategoryById(int id)
        {
            var result = _service.GetAroundProviderCategoryById(id);
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
                    message = "Get around provider category by id success",
                    data = result
                });


            }
        }

        
        [HttpGet]
        public IActionResult GetAroundProviderByFilter()
        {
            var result = _service.GetAllProviderCategory().ToList();
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
                    message = "Get all around provider category success",
                    data = result
                });
            }
        }
    }
}
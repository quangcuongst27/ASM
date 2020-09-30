using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataService.Enum;
using DataService.Models.RequestModels;
using DataService.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Web.API.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequestModel model)
        {
            var user = _service.CheckLogin(model);
            if (user == null)
            {
                return new JsonResult(new
                {
                    status = StatusMessage.FAILED,
                    message = "Username or Password not correct"
                });
            }
            else
            {
                return new JsonResult(new
                {
                    status = StatusMessage.SUCCESS,
                    message = "Login success",
                    data = user

                });
            }
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById(int id)
        {

            int accountId = int.Parse(User.FindFirst(ClaimTypes.Name)?.Value ?? null);
            if (accountId != id)
            {
                return StatusCode(401);
            }
            else
            {
                var result = _service.GetInfoUserById(id);
                if (result == null)
                {
                    return new JsonResult(new
                    {
                        status = StatusMessage.FAILED,
                        message = "Id not exist"
                    });
                }
                else
                {
                    return new JsonResult(new
                    {
                        status = StatusMessage.SUCCESS,
                        message = "Get info user success",
                        data = result

                    });
                }
            }
        }
    }
}

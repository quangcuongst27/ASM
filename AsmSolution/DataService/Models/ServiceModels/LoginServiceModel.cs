using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.ServiceModels
{
    public class LoginServiceModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string SecretKey { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.ServiceModels
{
    public class UserServiceModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ProfileImage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Idnumber { get; set; }
        public DateTime? IdcreatedDate { get; set; }
        public int? Gender { get; set; }
        public string Fullname { get; set; }
        public string SendPasswordTo { get; set; }
        public string BlockName { get; set; }
        public string Floor { get; set; }
        public string HouseName { get; set; }



    }
}

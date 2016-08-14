using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YOChat.DataModel
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string CountryPhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}

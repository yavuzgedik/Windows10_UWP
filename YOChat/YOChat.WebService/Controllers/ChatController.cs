using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using YOChat.DataModel;

namespace YOChat.WebService.Controllers
{
    public class ChatController : ApiController
    {
        [Route("chat/createuser")]
        [HttpGet]
        // /chat/createuser?id=1&fullName=yavuz&password=123456&phoneNumber=5062928064&countryPhoneCode=90
        public User CreateUser(string id, string fullName, string password, string phoneNumber, string countryPhoneCode)
        {
            var user = (from u in Database.Instance.UserTable
                        where u.Id == id
                        select u).FirstOrDefault();

            if (user == null)
            {
                // Create User
                user = new User() {
                    Id = id,
                    Password = password,
                    FullName = fullName,
                    CountryPhoneCode = countryPhoneCode,
                    PhoneNumber = phoneNumber,
                    ProfileImageUrl = "https://secure.gravatar.com/avatar/" + id + "?d=identicon&s=32"

                };
                Database.Instance.UserTable.Add(user);
            }

            return user;
        }
    }
}
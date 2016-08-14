using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YOChat.DataModel;

namespace YOChat.WebService
{
    public class Database
    {
        private Database()
        {

        }

        public static Database Instance = new Database();

        public List<User> UserTable = new List<User>();
    }
}
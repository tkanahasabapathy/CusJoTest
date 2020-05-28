using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusJo_Test.ViewModel
{
 public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }

    public class Response
    {
        public string Status { set; get; }
        public string Message { set; get; }
    }

    public class Menu
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string URL { get; set; }
    }

    public class Privilege
    {
        public int UserID { get; set; }
        public int MenuID { get; set; }
    }

}
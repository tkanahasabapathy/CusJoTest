using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;

using CusJo_Test.Models;
using CusJo_Test.ViewModel;

namespace CusJo_Test.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        CusJoTestEntities db = new CusJoTestEntities();
        [Route("AddUser")]
        [HttpPost]
        public Response AddUser(User Reg)
        {
            try
            {
                tblUser user = new tblUser();
                if (user.UserID == 0)
                {
                    user.UserName = Reg.UserName;
                    user.Email = Reg.Email;
                    user.Mobile = Reg.Mobile;
                    user.Password = Reg.Password;
                    user.UserType = Reg.UserType;
                    db.tblUsers.Add(user);
                    db.SaveChanges();
                }
                return new Response { Status = "Success", Message = "Record SuccessFully Saved." };
            }
            catch (Exception ex)
            {
                return new Response { Status = "Error", Message = ex.Message };
            }
        }

        [Route("Login")]
        [HttpPost]
        public Response Login(Login login)
        {
            var log = db.tblUsers.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password)).FirstOrDefault();
            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
            {
                HttpContext.Current.Session["CurrentUserID"] = log.UserID;
                HttpContext.Current.Session["CurrentUserName"] = log.UserName;
                HttpContext.Current.Session["CurrentUserType"] = log.UserType;
                return new Response { Status = "Success", Message = "Login Successfully" };
            }
        }

        [Route("GetUsers")]
        [HttpGet]
        public List<User> GetUsers()
        {
            List<tblUser> dbUsers = db.tblUsers.ToList();
            List<User> users = new List<User>();

            if (dbUsers != null)
            {
                foreach (var u in dbUsers)
                {
                    User usr = new User();
                    usr.UserID = u.UserID;
                    usr.UserName = u.UserName;
                    users.Add(usr);
                }
                return users;
            }
            else
                return null;
        }

        [Route("GetMenus")]
        [HttpGet]
        public List<Menu> GetMenus()
        {
            List<tblMenu> dbMenus = db.tblMenus.ToList();
            List<Menu> menus = new List<Menu>();

            if (dbMenus.Count > 0)
            {
                foreach (var m in dbMenus)
                {
                    Menu me = new Menu();
                    me.MenuID = m.MenuID;
                    me.MenuName = m.MenuName;
                    menus.Add(me);
                }
                return menus;
            }
            else
                return null;
        }

        [Route("GetUserMenus")]
        [HttpGet]
        public List<Menu> GetUserMenus()
        {
            int CurrentUserID = (int) HttpContext.Current.Session["CurrentUserID"];
            List<tblUserMenu> dbMenus = db.tblUserMenus.Where(m => m.UserID.Equals(CurrentUserID)).ToList();
            List<Menu> menus = new List<Menu>();

            if (dbMenus.Count > 0)
            {
                foreach (var m in dbMenus)
                {
                    tblMenu desc = db.tblMenus.Where(a => a.MenuID.Equals(m.MenuID)).FirstOrDefault();
                    Menu me = new Menu();
                    me.MenuID = m.MenuID;
                    me.MenuName = desc.MenuName;
                    me.URL = desc.URL;
                    menus.Add(me);
                }
                return menus;
            }
            else
                return null;
        }

        [Route("SavePrivileges")]
        [HttpPost]
        public Response SavePrivileges(List<Privilege> Privs)
        {
            try
            {
                int CurUserID = Privs[0].UserID;
                List<tblUserMenu> del = db.tblUserMenus.Where(d => d.UserID.Equals(CurUserID)).ToList();
                if (del.Count > 0)
                {
                    db.tblUserMenus.RemoveRange(del);
                    db.SaveChanges();
                }

                foreach (Privilege p in Privs)
                {
                    tblUserMenu um = new tblUserMenu();
                    if (p.MenuID != 0 && p.UserID != 0)
                    {
                        um.UserID = p.UserID;
                        um.MenuID = p.MenuID;
                        db.tblUserMenus.Add(um);
                    }
                }
                db.SaveChanges();
                return new Response { Status = "Success", Message = "Record SuccessFully Saved." };
            }
            catch (Exception ex)
            {
                return new Response { Status = "Error", Message = ex.Message };
            }            
        }

    }

}
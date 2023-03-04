using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Mvc3ToolsUpdateWeb_Default.Models;
using MusicStore.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Mvc3ToolsUpdateWeb_Default.Controllers
{
    public class AccountController : Controller
    {
        public const string LOGGEDINUSER_SESSION_KEY = "LoggedInUser";
        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string UserName, string Password, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                #region 暂时无法使用
                //if (Membership.ValidateUser(model.UserName, model.Password))
                //{
                //    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                //    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                //        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                //    {
                //        return Redirect(returnUrl);
                //    }
                //    else
                //    {
                //        return RedirectToAction("Index", "Home");
                //    }
                //}
                #endregion
                string sql_cmd2 = "select UserName,Password from Users";
                SqlDataReader loginread = data_read(sql_cmd2);
                List<LogOnModel> logon_list = new List<LogOnModel>();
                while (loginread.Read())
                {
                    logon_list.Add(new LogOnModel { UserName =Convert.ToString( loginread["UserName"].ToString()), Password =Convert.ToString( loginread["Password"].ToString()) });
                }
                int index = 0;
                bool igaz = false;
                for (int i = 0; i < logon_list.Count; i++)
                {
                    if (Convert.ToString(logon_list[i].UserName) == UserName && Convert.ToString(logon_list[i].Password) == Password)
                    {
                        index = i;
                        igaz=true;
                    }
                }
                if (Convert.ToString( logon_list[index].UserName) == UserName &&Convert.ToString( logon_list[index].Password) == Password&&igaz==true)
                {
                    MigrateShoppingCart(UserName);
                    FormsAuthentication.SetAuthCookie(UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
                

                

            }

            return View();
        }
        //public ActionResult LogOn(string UserName, string Password, string returnUrl)
        //{
        //    string sql_cmd2 = "select UserName,Password from Users where UserName='" + UserName + "' and Password='" + Password + "'";
        //    SqlDataReader loginread = data_read(sql_cmd2);
        //    List<LogOnModel> logon_list = new List<LogOnModel>();
        //    while (loginread.Read())
        //    {
        //        logon_list.Add(new LogOnModel { UserName = loginread["UserName"].ToString(), Password=loginread["Password"].ToString()});
        //    }
        //    for (int i = 0; i < logon_list.Count; i++)
        //    {
        //        if (logon_list[i].UserName==UserName && logon_list[i].Password==Password)
        //        {

        //        }
        //    }
        //    return View();

        //}

        //
        // GET: /Account/LogOff
        //public ActionResult LogOff()
        //{
        //    FormsAuthentication.SignOut();

        //    return RedirectToAction("Index", "Home");
        //}
        public ActionResult LogOff() //Mi Kijelentkezésünk
        {
            Session[LOGGEDINUSER_SESSION_KEY] = null;
            Guid tempCartId = Guid.NewGuid();
            Session[ShoppingCart.CartSessionKey] = tempCartId.ToString();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //
        // GET: /Account/Register

        public void sql_parancsok(string sql)//eljárás SQL parancsok futtatására az adatbázisban
        {
            string con_str = ConfigurationManager.ConnectionStrings["MusicStoreEntities"].ConnectionString;//1: kiszedi a conn stringet a webconfigból, mert azt fel kell használni amikor SqlConnectiont hozunk létre
            SqlConnection connection = new SqlConnection(con_str);//2: ez az SqlConnection változó tartalmazza a Connection string ahhoz, hogy az adatbázishoz hozzáférjunk           
            SqlCommand sql_cmd = new SqlCommand(sql, connection);//3: az SQLCommand kezeli le a csatlakozást az adatbázishoz(SqlConnection) és használja fel az SQL parancsunkat(bemenö pramétere ennek is és a fuggvénynek is)
            sql_cmd.Connection.Open();//4 :kapcsolat nyitása
            sql_cmd.ExecuteNonQuery();//5: sql parancs futtatása
            sql_cmd.Connection.Close();//6: kapcsolat bontás
        }
        public SqlDataReader data_read(string sql)//fuggvény az adattáblából való adatkiolvasáshoz
        {
            string con_str = ConfigurationManager.ConnectionStrings["MusicStoreEntities"].ConnectionString;//1: kiszedi a conn stringet a webconfigból, mert azt fel kell használni amikor SqlConnectiont hozunk létre
            SqlConnection connection = new SqlConnection(con_str);//2: ez az SqlConnection változó tartalmazza a Connection string ahhoz, hogy az adatbázishoz hozzáférjunk           
            SqlCommand sql_cmd = new SqlCommand(sql, connection);//3: az SQLCommand kezeli le a csatlakozást az adatbázishoz(SqlConnection) és használja fel az SQL parancsunkat(bemenö pramétere ennek is és a fuggvénynek is)
            sql_cmd.Connection.Open();//4: kapcsolat nyitása
            SqlDataReader data_reader = sql_cmd.ExecuteReader();//5: tábla adatainak kiolvasása sqldatareader-be
            return data_reader;//6: visszaadjuk a datareader értéket
        }
        public ActionResult Register()
        {
            return View();
        }
        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(string UserName,string Email,string Password)
        {
            //string sql_cmd1 = "select count(UserName) as id from Users;";
            //SqlDataReader sqlDataReader = data_read(sql_cmd1);
            //int id=0;
            //while (sqlDataReader.Read())
            //{
            //    id =Convert.ToInt32( sqlDataReader["id"].ToString());
            //}
            //id++;
            string sql_cmd = "insert into Users(UserName,Email,Password) values('"+UserName+"','"+Email+"','"+Password+"'); ";
            sql_parancsok(sql_cmd);

            return RedirectToAction("LogOn","Account");
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {


                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }


            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        /// <param name="UserName"></param>
        private void MigrateShoppingCart(string UserName)
        {
            // Associate shopping cart items with logged-in user
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.MigrateCart(UserName);
            Session[ShoppingCart.CartSessionKey] = UserName;
        }
        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}

using Netriks_Project.Models;
using Netriks_Project.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Netriks_Project.Controllers
{
    public class SalonController : ApiController
    {

        BL bl = new BL();
        #region Admin Related


        [HttpGet]
        [Route("Api/GetAllSuperAdmin")]
        public IEnumerable<SuperAdmin> GetAllAdmin(string action)
        {
            var res = bl.GetAllSuperAdmin(action);
            return res;
        }

        [HttpGet]
        [Route("Api/GetSuperAdmin")]
        public SuperAdmin GetAdmin(string action,int Id)
        {
            var res = bl.GetSuperAdmin(action,Id);
            return res;
        }

        [HttpPost]
        [Route("Api/AddSuperAdmin")]
        public void AddSAdmin(string Action, SuperAdmin adm)
        {
            bl.AddSuperAdmin(Action,adm);
        }


        [HttpGet]
        [Route("Api/ValidateSuperLogin")]
        public SuperAdmin ValidateLogin(string username,string  password)
        {
            var res = bl.ValidateSuperADmin(username,password);
            return res;
        }

        [HttpGet]
        [Route("Api/ValidateAdminLogin")]
        public Admin ValidateADmin(string c_contact, string c_password)
        {
         
            var res = bl.ValidateADmin(c_contact, c_password);
            return res;
        }

        [HttpGet]
        [Route("Api/VerifyLogin")]
        public string ValidateCredentials(string c_contact, string c_password)
        {

            var res = bl.AdminLogin(c_contact, c_password);
            return res;
        }


        [Route("Api/DeleteAdmin")]
        public void DeleteAdmin(string Action,int Id)
        {
            bl.DeleteAdmin(Action,Id);
        }
        #endregion

        #region User Related

        [HttpGet]
        [Route("Api/GetAllUsers")]
        public IEnumerable<Users> GetAllUser(string Action, int? Cid,int? Bid)
        {
            var res = bl.GetAllUsers(Action, Cid,Bid);
            return res;
        }

        [HttpGet]
        [Route("Api/GetUserById")]
        public Users GetUser(string Action, int? Id)
        {
            var res = bl.GetUserDetails(Action, Id);
            return res;
        }

        [HttpPost]
        [Route("Api/AddUserDetails")]
        public int? AddUser(string Action, Users data)
        {
            int? res = 0;
            res = bl.AddUser(Action, data);
            return res;
        }

        [HttpPost]
        [Route("Api/UpdateUserDetails")]
        public int? UpdateUSer(string Action, Users data,int? Id)
        {
            int? res = 0;
            res = bl.UpdateUser(Action, data,Id);
            return res;
        }


        [Route("Api/DeleteUser")]
        public void DeleteUser(string Action, int Id, int? Cid)
        {
            bl.DeleteUser(Action, Id,Cid);
        }
        #endregion
    }
}

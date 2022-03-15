using Netriks_Project.Auth;
using Netriks_Project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Netriks_Project.Controllers
{
    public class AccountController : Controller
    {

        string BaseUrl = "http://localhost:50664/";
        String Token = string.Empty;
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SuperAdmin()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult SuperLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SuperAdminLogin(string Username,string Password)
        {
            string Message = null;
            SuperAdmin admin = new SuperAdmin();
            if (!string.IsNullOrEmpty(Username)&&!string.IsNullOrEmpty(Password))
            {
                admin = await CheckSuperAdmin(Username,Password);
                if (admin != null && admin.S_id!=0)
                {
                    Session["SuperId"] = admin.S_id;
                    Session["SuperUser"] = admin.Username;
                    return RedirectToAction("Index","Home");
                }
                else {
                    Message = "Invalid Login";
                    TempData["Error"] = Message;
                    TempData.Keep();
                    Session.Abandon();
                    return RedirectToAction("AdminLogin", "Account",new { Message=Message});
                }
            }
            return RedirectToAction("AdminLogin","Account");
        }



        [HttpPost]
        public async Task<ActionResult> AdminLogin(string Username, string Password)
        {
            string Message = null;
            Admin admin = new Admin();
            Token tok = new Token()
            {
                Mobile = Username,
                Password = Password,
                grant_type = "password"
            };
            Token = await Tokens(tok);
            if (string.IsNullOrEmpty(Token) || Token=="")
            {
                Message = "Invalid Login";
                TempData["Error"] = Message;
                TempData.Keep();
                Session.Abandon();
                return RedirectToAction("AdminLogin", "Account", new { Message = Message });
            }
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                admin = await CheckAdmin(Username, Password);
                if (admin != null && admin.c_id != 0)
                {
                    Session["CID"] = admin.c_id;
                    Session["Token"] = Token;
                    Session["c_username"] = admin.c_name;
                    Session["c_password"] = admin.c_password;
                    FormsAuthentication.SetAuthCookie(Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Message = "Invalid Login";
                    TempData["Error"] = Message;
                    TempData.Keep();
                    Session.Abandon();
                    return RedirectToAction("AdminLogin", "Account", new { Message = Message });
                }
            }
            return RedirectToAction("AdminLogin", "Account");
        }



        [HttpPost]
        public async Task<string> Tokens(Token Model)
        {
            // Invoke the "token" OWIN service to perform the login: /api/token
            // Ugly hack: I use a server-side HTTP POST because I cannot directly invoke the service (it is deeply hidden in the OAuthAuthorizationServerHandler class)
            var request = BaseUrl + "/token";
            var tokenServiceUrl = request;
            var guid = Guid.NewGuid().ToString();
            string Token = null;

            using (var client = new HttpClient())
            {
                var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type",Model.grant_type),
                new KeyValuePair<string, string>("username", Model.Mobile),
                new KeyValuePair<string, string>("password",Model.Password)
            };

                var checklogin = await ValidateLogins(Model.Mobile,Model.Password);
                if (!string.IsNullOrEmpty(checklogin) && checklogin!="")
                {
                    Token = guid;
                }
                //var responseCode = tokenServiceResponse.StatusCode;
                //var responseMsg = new HttpResponseMessage(responseCode)
                //{
                //    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                //};
                return Token;
            }
        }



        public async Task<IEnumerable<SuperAdmin>> GetAllAdmin()
        {

            IEnumerable<SuperAdmin> adm = new List<SuperAdmin>();

            string apiUrl = BaseUrl + "/Api/GetAllSuperAdmin?Action=";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    adm = JsonConvert.DeserializeObject<IEnumerable<SuperAdmin>>(data);
                }

                return adm;
            }
        }

        public async Task<SuperAdmin> GetOnlyAdmin(int? Id)
        {

            SuperAdmin adm = new SuperAdmin();

            string apiUrl = BaseUrl + "/Api/GetSuperAdmin?Action=&Id=" + Id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    adm = JsonConvert.DeserializeObject<SuperAdmin>(data);
                }

                return adm;
            }
        }

        public async Task<SuperAdmin> CheckSuperAdmin(string Username,string Password)
        {

            SuperAdmin adm = new SuperAdmin();

            string apiUrl = BaseUrl + "/Api/ValidateSuperLogin?username=" + Username+ "&password="+Password;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    adm = JsonConvert.DeserializeObject<SuperAdmin>(data);
                }

                return adm;
            }
        }

        

        public async Task<Admin> CheckAdmin(string c_contact, string c_password)
        {

            Admin adm = new Admin();

            string apiUrl = BaseUrl + "/Api/ValidateAdminLogin?c_contact=" + c_contact + "&c_password=" + c_password;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    adm = JsonConvert.DeserializeObject<Admin>(data);
                }

                return adm;
            }
        }

        public async Task<string> ValidateLogins(string c_contact, string c_password)
        {

            string id = null;

            string apiUrl = BaseUrl + "/Api/VerifyLogin?c_contact=" + c_contact + "&c_password=" + c_password;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    id = JsonConvert.DeserializeObject<string>(data);
                }

                return id;
            }
        }




        public string AddSuperAdmin(SuperAdmin admin)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var myContent = JsonConvert.SerializeObject(admin);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HTTP POST5
                var postTask = client.PostAsync("Api/AddSuperAdmin", byteContent);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return "added";
                }
            }
            return "";
        }

        public string UpdateData(SuperAdmin admin, int? Id)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(BaseUrl);
                var myContent = JsonConvert.SerializeObject(admin);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var putTask = Client.PostAsync("Api/UpdateAppointments?Id=" + Id, byteContent);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return "updated";
                }
            }
            return "";
        }


        public async Task<string> DeleteAdmin(int? Id)
        {
            string apiUrl = BaseUrl + "/Api/DeleteAdmin?Id=" + Id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return "Deleted";
                }
            }
            return "";
        }

        public ActionResult LogOut()
        {
          
            Session.Abandon();
            Session.Clear();
            Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin", "Account", new { mode = "logout" });
        }
    }
}
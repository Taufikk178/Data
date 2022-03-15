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

namespace Netriks_Project.Controllers
{
    public class HomeController : Controller
    {
        string BaseUrl = "http://localhost:50664/";

        [SessionTimeOut]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> Add_visitor(int? Id)
        {
            Users user = new Users();
            if (Id!=null)
            {
                user = await GetOnlyUser(Id);
            }
            ViewBag.Message = "Your contact page.";

            return View(user);
        }

        public ActionResult Add_Employee()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Employee_List()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        //visitor 

        public ActionResult Add_Customer()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddCustomerDetails()
        {
            return RedirectToAction("");
        }

        public ActionResult Customer_details()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddVisitor(Users user)
        {
            int? Cid = null;
            int? Bid = null;
            string role = "Visitor";
            bool? status = true;
            Random rand = new Random();
            string password = user.u_contact;
            if (Session["CID"] != null)
            {
                Cid = Convert.ToInt32(Session["CID"]);
            }
            if (Session["BID"] != null)
            {
                Bid = Convert.ToInt32(Session["BID"]);
            }
            try
            {
                Users usr = new Users()
                {
                    Auto_id=1,
                    u_name = user.u_name,
                    u_contact= user.u_contact,
                    u_email = user.u_email,
                    u_role = role,
                    username = user.u_contact,
                    password = password,
                    c_id = Cid,
                    b_id=Bid,
                    u_status=status,
                    u_createdOn = DateTime.Now,
                    u_createdBy="Admin",
                };
                var res = AddUsers(usr);
                if (res=="added")
                {
                    TempData["Message"] = "added";
                    TempData.Keep();
                    return RedirectToAction("Visitors","Home");
                }
                else
                {
                    TempData["Message"] = "failed";
                    TempData.Keep();
                    return RedirectToAction("Add_visitor", "Home");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateVisitor(Users user,int? Id)
        {
            int? Cid = null;
            int? Bid = null;
            string role = "Visitor";
            bool? status = true;
            Random rand = new Random();
            Users data = new Users();
            string password = user.u_contact;
            if (Session["CID"] != null)
            {
                Cid = Convert.ToInt32(Session["CID"]);
            }
            if (Session["BID"] != null)
            {
                Bid = Convert.ToInt32(Session["BID"]);
            }
            try
            {
                if (Id!=null)
                {
                    data = await GetOnlyUser(Id);
                }
                Users usr = new Users()
                {
                    Auto_id = 1,
                    u_name = user.u_name,
                    u_contact = user.u_contact,
                    u_email = user.u_email,
                    u_updatedOn = DateTime.Now,
                    c_id=Cid,
                    b_id =Bid,
                    u_createdOn= data.u_createdOn,
                    u_createdBy = data.u_createdBy,
                    u_state=data.u_state,
                    u_role = data.u_role,
                    u_status=data.u_status,
                    username = data.username,
                    password = data.password
                };

                var res = UpdateUser(usr,Id);
                if (res == "updated")
                {
                    TempData["Message"] = "Updated";
                    TempData.Keep();
                    return RedirectToAction("Visitors", "Home");
                }
                else
                {
                    TempData["Message"] = "failed";
                    TempData.Keep();
                    return RedirectToAction("Add_visitor", "Home",new { Id=Id});
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ActionResult> Visitors()
        {
            int? Cid = null;
            int? Bid = null;
            IEnumerable<Users> user = new List<Users>();
            if (Session["CID"] != null)
            {
                Cid = Convert.ToInt32(Session["CID"]);
            }
            if (Session["BID"] != null)
            {
                Bid = Convert.ToInt32(Session["BID"]);
            }
            try
            {
                user = await GetAllUsers();
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(user);
        }

       
        [HttpPost]
        public ActionResult AddAdmin(SuperAdmin data)
        {
            SuperAdmin adm = new SuperAdmin
            {
                Name = data.Name,
                Contact = data.Contact,
                Username = data.Username,
                Password = data.Password,
                CreatedOn = DateTime.Now
            };
            var res = AddSuperAdmin(adm);
            if (res=="added")
            {
                return RedirectToAction("Index", "Home",new { Message="added"});
            }
            return RedirectToAction("Index","Home");
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

            string apiUrl = BaseUrl + "/Api/GetSuperAdmin?Action=&Id="+Id;

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

                var putTask = Client.PostAsync("Api/UpdateAppointments?Id=" + Id , byteContent);
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

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            int? Cid = null;
            int? Bid = null;
            if (Session["CID"]!=null)
            {
                Cid = Convert.ToInt32(Session["CID"]);
            }
            if (Session["BID"] != null)
            {
                Bid = Convert.ToInt32(Session["BID"]);
            }
            IEnumerable<Users> user = new List<Users>();

            string apiUrl = BaseUrl + "/Api/GetAllUsers?Action=&Cid="+Cid+ "&Bid="+Bid;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    user = JsonConvert.DeserializeObject<IEnumerable<Users>>(data);
                }

                return user;
            }
        }

        public async Task<Users> GetOnlyUser(int? Id)
        {

            Users user = new Users();

            string apiUrl = BaseUrl + "/Api/GetUserById?Action=&Id=" + Id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    user = JsonConvert.DeserializeObject<Users>(data);
                }

                return user;
            }
        }

        public string AddUsers(Users user)
        {
            int res = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                var myContent = JsonConvert.SerializeObject(user);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //HTTP POST5
                var postTask = client.PostAsync("Api/AddUserDetails?Action=", byteContent);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return "added";
                }
            }
            return "";
        }

        public string UpdateUser(Users user, int? Id)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(BaseUrl);
                var myContent = JsonConvert.SerializeObject(user);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var putTask = Client.PostAsync("Api/UpdateUserDetails?Action=&Id=" + Id, byteContent);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return "updated";
                }
            }
            return "";
        }


        public async Task<string> Delete(int? Id)
        {
            string apiUrl = BaseUrl + "/Api/DeleteUser?Id=" + Id;

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


    }
}
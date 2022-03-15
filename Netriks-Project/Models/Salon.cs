using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netriks_Project.Models
{
    public class Salon
    {
    }
    public class Token
    {
        public string Mobile { get; set; }
        public string Password { get; set; }

        public string grant_type { get; set; }
    }
    public class SuperAdmin
    {
        public int S_id { get; set; }
        public string Name  { get; set; }
        public string Contact  { get; set; }
        public string Username  { get; set; }
        public string Password  { get; set; }
        public DateTime? CreatedOn  { get; set; }
    }
    public class Admin
    {
        public int c_id { get; set; }
        public string c_name { get; set; }
        public string c_branch { get; set; }
        public string c_gst_no { get; set; }
        public string c_address { get; set; }
        public string c_country { get; set; }
        public string c_state { get; set; }
        public string c_city { get; set; }
        public string c_contact { get; set; }
        public string c_owner_name { get; set; }
        public string c_owner_email { get; set; }
        public string c_website { get; set; }
        public string c_status { get; set; }
        public string c_password { get; set; }

        public DateTime? CreatedOn { get; set; }
    }

    public class ClientRegistration
    {
        public int c_id { get; set; }
        public string CName { get; set; }
        public string Branch { get; set; }
        public string GstNo { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public string Website { get; set; }
        public string OwnerName { get; set; }
        public string OwnerContact { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string  CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string  Logo { get; set; }
        public string Terms { get; set; }
        public bool? Status { get; set; }
    }

    public class Users
    {
        public int u_id { get; set; }
        public int Auto_id { get; set; }
        public string u_name { get; set; }
        public string u_contact { get; set; }
        public string u_email { get; set; }
        public string u_role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int? c_id { get; set; }
        public int? b_id { get; set; }
        public string U_Stat { get; set; }
        public string u_profile_img { get; set; }
        public bool? u_status { get; set; }
        public string u_mtoken { get; set; }
        public string u_state { get; set; }
        public string u_comment { get; set; }
        public DateTime? u_nextfollowupdate { get; set; }
        public DateTime? u_createdOn { get; set; }
        public string u_createdBy { get; set; }
        public DateTime? u_updatedOn { get; set; }
    }
}
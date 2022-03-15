using Netriks_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Netriks_Project.Repo
{
    public class BL
    {
        string conn = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;

        #region Admin Related

        public IEnumerable<SuperAdmin> GetAllSuperAdmin(string Action)
        {
            int count = 0;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "SelectAll";
            }
            List<SuperAdmin> admin = new List<SuperAdmin>();
            IEnumerable<SuperAdmin> adminlist = new List<SuperAdmin>();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("SP_SuperAccess", Conn);
                objCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = Action;
                objCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    count += 1;
                    SuperAdmin list = new SuperAdmin();
                    list.S_id = Convert.ToInt32(_Reader["S_id"]);
                    if (_Reader["s_name"] != DBNull.Value)
                    {
                        list.Name = Convert.ToString(_Reader["s_name"]);
                    }
                    if (_Reader["s_contact"] != DBNull.Value)
                    {
                        list.Contact = Convert.ToString(_Reader["s_contact"]);
                    }
                    if (_Reader["s_username"] != DBNull.Value)
                    {
                        list.Username = Convert.ToString(_Reader["s_username"]);
                    }
                    if (_Reader["s_password"] != DBNull.Value)
                    {
                        list.Password = Convert.ToString(_Reader["s_password"]);
                    }
                    if (_Reader["s_createdOn"] != DBNull.Value)
                    {
                        list.CreatedOn = Convert.ToDateTime(_Reader["s_createdOn"]);
                    }
                    admin.Add(list);
                }
                adminlist = admin.AsEnumerable().ToList();
                return adminlist;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }

        }



        public SuperAdmin GetSuperAdmin(string Action,int Id)
        {
            int count = 0;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Select";
            }
            SuperAdmin list = new SuperAdmin();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("SP_SuperAccess", Conn);
                objCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = Action;
                objCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                objCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                   
                    list.S_id = Convert.ToInt32(_Reader["S_id"]);
                    if (_Reader["s_name"] != DBNull.Value)
                    {
                        list.Name = Convert.ToString(_Reader["s_name"]);
                    }
                    if (_Reader["s_contact"] != DBNull.Value)
                    {
                        list.Contact = Convert.ToString(_Reader["s_contact"]);
                    }
                    if (_Reader["s_username"] != DBNull.Value)
                    {
                        list.Username = Convert.ToString(_Reader["s_username"]);
                    }
                    if (_Reader["s_password"] != DBNull.Value)
                    {
                        list.Password = Convert.ToString(_Reader["s_password"]);
                    }
                    if (_Reader["s_createdOn"] != DBNull.Value)
                    {
                        list.CreatedOn = Convert.ToDateTime(_Reader["s_createdOn"]);
                    }
                }
                return list;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }

        }



        public SuperAdmin ValidateSuperADmin(string username,string pasword)
        {
            int count = 0;
            string Action = null;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Login";
            }
            SuperAdmin list = new SuperAdmin();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("SP_SuperAccess", Conn);
                objCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = Action;
                objCommand.Parameters.Add("@s_username", SqlDbType.NVarChar).Value = username;
                objCommand.Parameters.Add("@s_password", SqlDbType.NVarChar).Value = pasword;
                objCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    count += 1;
                    list.S_id = Convert.ToInt32(_Reader["S_id"]);
                    if (_Reader["s_name"] != DBNull.Value)
                    {
                        list.Name = Convert.ToString(_Reader["s_name"]);
                    }
                    if (_Reader["s_contact"] != DBNull.Value)
                    {
                        list.Contact = Convert.ToString(_Reader["s_contact"]);
                    }
                    if (_Reader["s_username"] != DBNull.Value)
                    {
                        list.Username = Convert.ToString(_Reader["s_username"]);
                    }
                    if (_Reader["s_password"] != DBNull.Value)
                    {
                        list.Password = Convert.ToString(_Reader["s_password"]);
                    }
                    if (_Reader["s_createdOn"] != DBNull.Value)
                    {
                        list.CreatedOn = Convert.ToDateTime(_Reader["s_createdOn"]);
                    }
                }
                return list;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }

        }



        public Admin ValidateADmin(string c_contact, string pasword)
        {
            int count = 0;
            string Action = null;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Login";
            }
            Admin list = new Admin();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("CompanyRegistration", Conn);
                objCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = Action;
                objCommand.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = c_contact;
                objCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pasword;
                objCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    count += 1;
                    list.c_id = Convert.ToInt32(_Reader["c_id"]);
                    if (_Reader["c_name"] != DBNull.Value)
                    {
                        list.c_name = Convert.ToString(_Reader["c_name"]);
                    }
                    if (_Reader["c_contact"] != DBNull.Value)
                    {
                        list.c_contact = Convert.ToString(_Reader["c_contact"]);
                    }
                    if (_Reader["c_owner_email"] != DBNull.Value)
                    {
                        list.c_owner_email = Convert.ToString(_Reader["c_owner_email"]);
                    }
                    if (_Reader["c_website"] != DBNull.Value)
                    {
                        list.c_website = Convert.ToString(_Reader["c_website"]);
                    }
                    if (_Reader["c_country"] != DBNull.Value)
                    {
                        list.c_country = Convert.ToString(_Reader["c_country"]);
                    }

                   
                    if (_Reader["c_password"] != DBNull.Value)
                    {
                        list.c_password = Convert.ToString(_Reader["c_password"]);
                    }
                }
                return list;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }

        }


        public string AdminLogin(string c_contact, string pasword)
        {
            int count = 0;
            string Action = null;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Login";
            }
            Admin list = new Admin();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("CompanyRegistration", Conn);
                objCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = Action;
                objCommand.Parameters.Add("@Contact", SqlDbType.NVarChar).Value = c_contact;
                objCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pasword;
                objCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    count += 1;
                    list.c_id = Convert.ToInt32(_Reader["c_id"]);
                   
                }
                if (count>0)
                {
                    return list.c_id.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }

        }







        public void AddSuperAdmin(string Action,SuperAdmin admin)
        {
            int count = 0;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Insert";
            }
            SuperAdmin list = new SuperAdmin();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand cmd = new SqlCommand("SP_SuperAccess", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@s_name", SqlDbType.NVarChar).Value = admin.Name;
                cmd.Parameters.AddWithValue("@s_contact", SqlDbType.NVarChar).Value = admin.Contact;
                cmd.Parameters.AddWithValue("@s_username", SqlDbType.NVarChar).Value = admin.Username;
                cmd.Parameters.AddWithValue("@s_password", SqlDbType.NVarChar).Value = admin.Password;
                cmd.Parameters.AddWithValue("@s_createdOn", SqlDbType.DateTime).Value = admin.CreatedOn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }




        public int AddAdmin(string Action, Admin admin)
        {
            int count = 0;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Insert";
            }
            Admin list = new Admin();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand cmd = new SqlCommand("CompanyRegistration", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@c_name", SqlDbType.NVarChar).Value = admin.c_name;
                cmd.Parameters.AddWithValue("@c_branch", SqlDbType.NVarChar).Value = admin.c_branch;
                cmd.Parameters.AddWithValue("@c_gst_no", SqlDbType.NVarChar).Value = admin.c_gst_no;
                cmd.Parameters.AddWithValue("@c_address", SqlDbType.NVarChar).Value = admin.c_address;
                cmd.Parameters.AddWithValue("@c_country", SqlDbType.DateTime).Value = admin.c_country;
                cmd.Parameters.AddWithValue("@c_city", SqlDbType.DateTime).Value = admin.CreatedOn;
                cmd.Parameters.AddWithValue("@c_owner_name", SqlDbType.NVarChar).Value = admin.c_owner_name;
                cmd.Parameters.AddWithValue("@c_owner_email", SqlDbType.NVarChar).Value = admin.c_owner_email;
                cmd.Parameters.AddWithValue("@c_status", SqlDbType.NVarChar).Value = admin.c_state;

                 count=cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
            return count;
        }

        

        public SuperAdmin ValidLogin(string Action,string Username,string Password)
        {
            int count = 0;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Login";
            }
            SuperAdmin list = new SuperAdmin();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand cmd = new SqlCommand("SP_SuperAccess", Conn);
                cmd.Parameters.Add("@Action", SqlDbType.NVarChar).Value = Action;
                cmd.Parameters.Add("@s_username", SqlDbType.NVarChar).Value = Username;
                cmd.Parameters.Add("@s_password", SqlDbType.NVarChar).Value = Password;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader _Reader = cmd.ExecuteReader();

                while (_Reader.Read())
                {

                    list.S_id = Convert.ToInt32(_Reader["S_id"]);
                    if (_Reader["s_name"] != DBNull.Value)
                    {
                        list.Name = Convert.ToString(_Reader["s_name"]);
                    }
                    if (_Reader["s_contact"] != DBNull.Value)
                    {
                        list.Contact = Convert.ToString(_Reader["s_contact"]);
                    }
                    if (_Reader["s_username"] != DBNull.Value)
                    {
                        list.Username = Convert.ToString(_Reader["s_username"]);
                    }
                    if (_Reader["s_password"] != DBNull.Value)
                    {
                        list.Password = Convert.ToString(_Reader["s_password"]);
                    }
                    if (_Reader["s_createdOn"] != DBNull.Value)
                    {
                        list.CreatedOn = Convert.ToDateTime(_Reader["s_createdOn"]);
                    }
                }
                return list;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }

        }
        //n
        public void DeleteAdmin(string Action,int Id)
        {
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Delete";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_SuperAccess", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action",Action );
                    cmd.Parameters.AddWithValue("@Id",SqlDbType.Int).Value=Id;
                    cmd.ExecuteReader();
                }
                // Lblmsg.Text = "record deleted sucessfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region User Related

        // Select All Users
        public IEnumerable<Users> GetAllUsers(string Action,int? Cid,int? Bid)
        {
            int count = 0;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "ViewAll";
            }
            List<Users> admin = new List<Users>();
            IEnumerable<Users> adminlist = new List<Users>();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("SP_User", Conn);
                objCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = Action;
                objCommand.Parameters.Add("@c_id", SqlDbType.Int).Value = Cid;
                objCommand.Parameters.Add("@b_id", SqlDbType.Int).Value = Bid;
                objCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    count += 1;
                    Users list = new Users();
                    list.u_id = Convert.ToInt32(_Reader["u_id"]);
                    if (_Reader["Auto_id"] != DBNull.Value)
                    {
                        list.Auto_id = Convert.ToInt32(_Reader["Auto_id"]);
                    }
                    if (_Reader["u_name"] != DBNull.Value)
                    {
                        list.u_name = Convert.ToString(_Reader["u_name"]);
                    }
                    if (_Reader["u_contact"] != DBNull.Value)
                    {
                        list.u_contact = Convert.ToString(_Reader["u_contact"]);
                    }
                    if (_Reader["u_email"] != DBNull.Value)
                    {
                        list.u_email = Convert.ToString(_Reader["u_email"]);
                    }
                    if (_Reader["u_role"] != DBNull.Value)
                    {
                        list.u_role = Convert.ToString(_Reader["u_role"]);
                    }
                    if (_Reader["username"] != DBNull.Value)
                    {
                        list.username = Convert.ToString(_Reader["username"]);
                    }
                    if (_Reader["password"] != DBNull.Value)
                    {
                        list.password = Convert.ToString(_Reader["password"]);
                    }
                    if (_Reader["c_id"] != DBNull.Value)
                    {
                        list.c_id = Convert.ToInt32(_Reader["c_id"]);
                    }
                    if (_Reader["b_id"] != DBNull.Value)
                    {
                        list.b_id = Convert.ToInt32(_Reader["b_id"]);
                    }
                    if (_Reader["U_Stat"] != DBNull.Value)
                    {
                        list.U_Stat = Convert.ToString(_Reader["U_Stat"]);
                    }
                    if (_Reader["u_profile_img"] != DBNull.Value)
                    {
                        list.u_profile_img = Convert.ToString(_Reader["u_profile_img"]);
                    }
                    if (_Reader["u_status"] != DBNull.Value)
                    {
                        list.u_status = Convert.ToBoolean(_Reader["u_status"]);
                    }
                    if (_Reader["u_mtoken"] != DBNull.Value)
                    {
                        list.u_mtoken = Convert.ToString(_Reader["u_mtoken"]);
                    }
                    if (_Reader["u_state"] != DBNull.Value)
                    {
                        list.u_state = Convert.ToString(_Reader["u_state"]);
                    }
                    if (_Reader["u_comment"] != DBNull.Value)
                    {
                        list.u_comment = Convert.ToString(_Reader["u_comment"]);
                    }
                    if (_Reader["u_nextfollowupdate"] != DBNull.Value)
                    {
                        list.u_nextfollowupdate = Convert.ToDateTime(_Reader["u_nextfollowupdate"]);
                    }
                    if (_Reader["u_createdOn"] != DBNull.Value)
                    {
                        list.u_createdOn = Convert.ToDateTime(_Reader["u_createdOn"]);
                    }
                    if (_Reader["u_createdBy"] != DBNull.Value)
                    {
                        list.u_createdBy = Convert.ToString(_Reader["u_createdBy"]);
                    }
                    if (_Reader["u_updatedOn"] != DBNull.Value)
                    {
                        list.u_updatedOn = Convert.ToDateTime(_Reader["u_updatedOn"]);
                    }
                    admin.Add(list);
                }
                adminlist = admin.AsEnumerable().ToList();
                return adminlist;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }

        }

        public Users GetUserDetails(string Action, int? Id)
        {
            int count = 0;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "ViewUser";
            }
            Users list = new Users();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("SP_User", Conn);
                objCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = Action;
                objCommand.Parameters.Add("@u_id", SqlDbType.Int).Value = Id;
                objCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    count += 1;
                    list.u_id = Convert.ToInt32(_Reader["u_id"]);
                    if (_Reader["Auto_id"] != DBNull.Value)
                    {
                        list.Auto_id = Convert.ToInt32(_Reader["Auto_id"]);
                    }
                    if (_Reader["u_name"] != DBNull.Value)
                    {
                        list.u_name = Convert.ToString(_Reader["u_name"]);
                    }
                    if (_Reader["u_contact"] != DBNull.Value)
                    {
                        list.u_contact = Convert.ToString(_Reader["u_contact"]);
                    }
                    if (_Reader["u_email"] != DBNull.Value)
                    {
                        list.u_email = Convert.ToString(_Reader["u_email"]);
                    }
                    if (_Reader["u_role"] != DBNull.Value)
                    {
                        list.u_role = Convert.ToString(_Reader["u_role"]);
                    }
                    if (_Reader["username"] != DBNull.Value)
                    {
                        list.username = Convert.ToString(_Reader["username"]);
                    }
                    if (_Reader["password"] != DBNull.Value)
                    {
                        list.password = Convert.ToString(_Reader["password"]);
                    }
                    if (_Reader["c_id"] != DBNull.Value)
                    {
                        list.c_id = Convert.ToInt32(_Reader["c_id"]);
                    }
                    if (_Reader["b_id"] != DBNull.Value)
                    {
                        list.b_id = Convert.ToInt32(_Reader["b_id"]);
                    }
                    if (_Reader["U_Stat"] != DBNull.Value)
                    {
                        list.U_Stat = Convert.ToString(_Reader["U_Stat"]);
                    }
                    if (_Reader["u_profile_img"] != DBNull.Value)
                    {
                        list.u_profile_img = Convert.ToString(_Reader["u_profile_img"]);
                    }
                    if (_Reader["u_status"] != DBNull.Value)
                    {
                        list.u_status = Convert.ToBoolean(_Reader["u_status"]);
                    }
                    if (_Reader["u_mtoken"] != DBNull.Value)
                    {
                        list.u_mtoken = Convert.ToString(_Reader["u_mtoken"]);
                    }
                    if (_Reader["u_state"] != DBNull.Value)
                    {
                        list.u_state = Convert.ToString(_Reader["u_state"]);
                    }
                    if (_Reader["u_comment"] != DBNull.Value)
                    {
                        list.u_comment = Convert.ToString(_Reader["u_comment"]);
                    }
                    if (_Reader["u_nextfollowupdate"] != DBNull.Value)
                    {
                        list.u_nextfollowupdate = Convert.ToDateTime(_Reader["u_nextfollowupdate"]);
                    }
                    if (_Reader["u_createdOn"] != DBNull.Value)
                    {
                        list.u_createdOn = Convert.ToDateTime(_Reader["u_createdOn"]);
                    }
                    if (_Reader["u_createdBy"] != DBNull.Value)
                    {
                        list.u_createdBy = Convert.ToString(_Reader["u_createdBy"]);
                    }
                    if (_Reader["u_updatedOn"] != DBNull.Value)
                    {
                        list.u_updatedOn = Convert.ToDateTime(_Reader["u_updatedOn"]);
                    }
                    
                }

                return list;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }

        }

        //Add User
        public int AddUser(string Action, Users user)
        {
            int count = 0;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Insert";
            }
            Admin list = new Admin();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand cmd = new SqlCommand("SP_User", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Auto_Id", SqlDbType.Int).Value = user.Auto_id;
                cmd.Parameters.AddWithValue("@u_name", SqlDbType.NVarChar).Value = user.u_name;
                cmd.Parameters.AddWithValue("@u_contact", SqlDbType.NVarChar).Value = user.u_contact;
                cmd.Parameters.AddWithValue("@u_email", SqlDbType.NVarChar).Value = user.u_email;
                cmd.Parameters.AddWithValue("@u_role", SqlDbType.NVarChar).Value = user.u_role;
                cmd.Parameters.AddWithValue("@username", SqlDbType.NVarChar).Value = user.username;
                cmd.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = user.password;
                cmd.Parameters.AddWithValue("@c_id", SqlDbType.Int).Value = user.c_id;
                cmd.Parameters.AddWithValue("@b_id", SqlDbType.Int).Value = user.b_id;
                cmd.Parameters.AddWithValue("@u_profile_img", SqlDbType.NVarChar).Value = user.u_profile_img;
                cmd.Parameters.AddWithValue("@u_state", SqlDbType.NVarChar).Value = user.u_state;
                cmd.Parameters.AddWithValue("@u_mtoken", SqlDbType.NVarChar).Value = user.u_mtoken;
                cmd.Parameters.AddWithValue("@u_comment", SqlDbType.NVarChar).Value = user.u_comment;
                cmd.Parameters.AddWithValue("@u_nextfollowupdate", SqlDbType.DateTime).Value = user.u_nextfollowupdate;
                cmd.Parameters.AddWithValue("@u_createdOn", SqlDbType.DateTime).Value = user.u_createdOn;
                cmd.Parameters.AddWithValue("@u_createdBy", SqlDbType.NVarChar).Value = user.u_createdBy;
                cmd.Parameters.AddWithValue("@u_updatedOn", SqlDbType.DateTime).Value = user.u_updatedOn;
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
            return count;
        }


        //Add User
        public int UpdateUser(string Action, Users user,int? Id)
        {
            int count = 0;
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Update";
            }
            Users list = new Users();
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = conn;
            Conn.Open();

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand cmd = new SqlCommand("SP_User", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@Auto_Id", SqlDbType.Int).Value = user.Auto_id;
                cmd.Parameters.AddWithValue("@u_id", SqlDbType.Int).Value = Id;
                cmd.Parameters.AddWithValue("@u_name", SqlDbType.NVarChar).Value = user.u_name;
                cmd.Parameters.AddWithValue("@u_contact", SqlDbType.NVarChar).Value = user.u_contact;
                cmd.Parameters.AddWithValue("@u_email", SqlDbType.NVarChar).Value = user.u_email;
                cmd.Parameters.AddWithValue("@u_role", SqlDbType.NVarChar).Value = user.u_role;
                cmd.Parameters.AddWithValue("@username", SqlDbType.NVarChar).Value = user.username;
                cmd.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = user.password;
                cmd.Parameters.AddWithValue("@c_id", SqlDbType.Int).Value = user.c_id;
                cmd.Parameters.AddWithValue("@b_id", SqlDbType.Int).Value = user.b_id;
                cmd.Parameters.AddWithValue("@u_profile_img", SqlDbType.NVarChar).Value = user.u_profile_img;
                cmd.Parameters.AddWithValue("@u_state", SqlDbType.NVarChar).Value = user.u_state;
                cmd.Parameters.AddWithValue("@u_mtoken", SqlDbType.NVarChar).Value = user.u_mtoken;
                cmd.Parameters.AddWithValue("@u_comment", SqlDbType.NVarChar).Value = user.u_comment;
                cmd.Parameters.AddWithValue("@u_nextfollowupdate", SqlDbType.DateTime).Value = user.u_nextfollowupdate;
                cmd.Parameters.AddWithValue("@u_createdOn", SqlDbType.DateTime).Value = user.u_createdOn;
                cmd.Parameters.AddWithValue("@u_createdBy", SqlDbType.NVarChar).Value = user.u_createdBy;
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
            return count;
        }

        public void DeleteUser(string Action, int Id, int? Cid)
        {
            if (string.IsNullOrEmpty(Action))
            {
                Action = "Delete";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_User", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", Action);
                    cmd.Parameters.AddWithValue("@u_id", SqlDbType.Int).Value = Id;
                    cmd.Parameters.AddWithValue("@c_id", SqlDbType.Int).Value = Cid;
                    cmd.ExecuteReader();
                }
                // Lblmsg.Text = "record deleted sucessfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
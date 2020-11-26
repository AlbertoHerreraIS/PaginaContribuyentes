using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PaginaContribuyentes
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLoginClick()
        {
            try
            {
                string mail = txtLMail.Text.Trim();
                string passwd = txtLPass.Text;
                string result = "";

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conndb"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Login";
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = mail;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = passwd;
                    cmd.Connection = conn;
                    conn.Open();
                    DataTable DT = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(DT);
                    }
                    result = DT.Rows[0][0].ToString();
                    conn.Close();
                    if (result.Contains("Error"))
                    {
                        lblMessage.Style.Add("display", "true");
                        lblMessage.Text = result;
                    }
                    else
                    {
                        Session["myInformation"] = result;
                        Response.Redirect("./Default.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string mail = txtLMail.Text.Trim();
                string passwd = txtLPass.Text;
                string result = "";
                result = DoLogin(mail, passwd);
                
                    if (result.Contains("Error"))
                    {
                        lblMessage.Style.Add("display", "true");
                        lblMessage.Text = result;
                    }
                    else
                    {
                        Session["UserId"] = result;
                        Response.Redirect("./Default.aspx");
                    }
                
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        public string DoLogin(string mail, string passwd)
        {
            string result = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conndb"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Login";
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = mail;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = passwd;
                    cmd.Connection = conn;
                    conn.Open();
                    DataTable DT = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(DT);
                    }
                    result = DT.Rows[0][0].ToString();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = "Error : " + ex.Message;
            }

            return result;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string mail = txtMail.Text;
            string passwd = txtpass.Text;
            string RFC = txtRFC.Text;
            string result = CreateUser(nombre, mail, passwd, RFC);
            if (result.Contains("Error"))
            {
                lblMessage1.Style.Add("display", "true");
                lblMessage1.Style.Add("forecolor", "red");
                lblMessage1.Text = result;
            }
            else
            {
                lblsuccess.Text = result;
            }
        }

        public string CreateUser(string nombre, string mail, string passwd, string RFC)
        {
            string result = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conndb"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_CreateUser";
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = mail;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = passwd;
                    cmd.Parameters.Add("@RFC", SqlDbType.NVarChar).Value = RFC;
                    cmd.Connection = conn;
                    conn.Open();
                    DataTable DT = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(DT);
                    }
                    result = DT.Rows[0][0].ToString();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = "Error : " + ex.Message;
            }

            return result;
        }
    }
    
}
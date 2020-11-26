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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                GVBind();
            }

        }

        protected void GVBind()
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conndb"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ShowContribuyente";
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserId;
                cmd.Connection = conn;
                conn.Open();
                DataTable DT = new DataTable();
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(DT);
                }
                if (DT.Rows.Count > 0)
                {
                    GridView1.DataSource = DT;
                    GridView1.DataBind();
                }
                else
                {
                    DT.Rows.Add(DT.NewRow());
                    GridView1.DataSource = DT;
                    GridView1.DataBind();
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = DT.Columns.Count;
                    GridView1.Rows[0].Cells[0].Text = "No Data Found";
                    GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }       
       
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string result = "";
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    int UserId = Convert.ToInt32(Session["UserId"]);
                    string RazonSocial = (GridView1.FooterRow.FindControl("txtrsFooter") as TextBox).Text.Trim();
                    string Mail = (GridView1.FooterRow.FindControl("txtMailFooter") as TextBox).Text.Trim();
                    string RFC = (GridView1.FooterRow.FindControl("txtRFCFooter") as TextBox).Text.Trim();
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conndb"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_CreateContribuyente";
                        cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;
                        cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = Mail;
                        cmd.Parameters.Add("@RFC", SqlDbType.NVarChar).Value = RFC;
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                        cmd.Connection = conn;
                        conn.Open();
                        DataTable DT = new DataTable();
                        using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                        {
                            a.Fill(DT);
                        }
                        SqlDataReader dr = cmd.ExecuteReader();

                        result = DT.Rows[0][0].ToString();
                        conn.Close();
                        dr.Close();
                    }
                    if (result == "Contribuyente Registrado con exito")
                    {
                        lblSuccess.Text = result;
                        lblError.Text = "";
                    }
                    else
                    {
                        lblError.Text = result;
                        lblSuccess.Text = "";
                    }
                    GVBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;            
            GVBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GVBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string result = "";
            try
            {                                   
                    string RazonSocial = (GridView1.Rows[e.RowIndex].FindControl("txtrs") as TextBox).Text.Trim();
                    string Mail = (GridView1.Rows[e.RowIndex].FindControl("txtMail") as TextBox).Text.Trim();
                    string RFC = (GridView1.Rows[e.RowIndex].FindControl("txtRFC") as TextBox).Text.Trim();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conndb"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_EditContribuyente";
                        cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;
                        cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = Mail;
                        cmd.Parameters.Add("@RFC", SqlDbType.NVarChar).Value = RFC;
                        
                        cmd.Connection = conn;
                        conn.Open();
                        DataTable DT = new DataTable();
                        using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                        {
                            a.Fill(DT);
                        }
                        SqlDataReader dr = cmd.ExecuteReader();
                        GridView1.EditIndex = -1;
                        result = DT.Rows[0][0].ToString();
                        conn.Close();
                        dr.Close();
                    }
                    if (result == "Contribuyente editado con exito")
                    {
                        lblSuccess.Text = result;
                        lblError.Text = "";
                    }
                    else
                    {
                        lblSuccess.Text = "";
                        lblError.Text = result;
                    }
                    GVBind();
                }
            
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string result = "";
            try
            {                
                string RFC = (GridView1.Rows[e.RowIndex].FindControl("txtRFC") as TextBox).Text.Trim();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conndb"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_InactiveContribuyente";                    
                    cmd.Parameters.Add("@RFC", SqlDbType.NVarChar).Value = RFC;

                    cmd.Connection = conn;
                    conn.Open();
                    DataTable DT = new DataTable();
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(DT);
                    }
                    SqlDataReader dr = cmd.ExecuteReader();
                    GridView1.EditIndex = -1;
                    result = DT.Rows[0][0].ToString();
                    conn.Close();
                    dr.Close();
                }
                if (result == "Contribuyente dado de baja con exito")
                {
                    lblSuccess.Text = result;
                    lblError.Text = "";
                }
                else
                {
                    lblSuccess.Text = "";
                    lblError.Text = result;
                }
                GVBind();
            }

            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (GridView1.EditIndex != -1)
            {
                // Use the Cancel property to cancel the paging operation.
                e.Cancel = true;

                // Display an error message.
                int newPageNumber = e.NewPageIndex + 1;
                lblError.Text = "Termine de editar el registro antes de moverse a la página " +
                  newPageNumber.ToString() + ".";
            }
            else
            {
                GVBind();
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
                // Clear the error message.
                lblError.Text = "";
            }
        }
    }
}
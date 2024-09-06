using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    DataTable allCategories = new DataTable();
    InsertErrorLogs inEr = new InsertErrorLogs();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string Login_Session_Id = Convert.ToString(Session["Login_Session_Id"]);
            if (Login_Session_Id != "")
            {
                string sql = "SELECT COUNT(1) FROM SD_User_Master with(nolock) WHERE UserID='" + Convert.ToString(Session["UserID"]) + "' AND LoginSessionID='" + Login_Session_Id.Trim() + "'";
                int Exists = Convert.ToInt32(database.GetScalarValue(sql));
                if (Exists != 1)
                {
                    Session.Abandon();
                    Session.RemoveAll();
                    Response.Redirect("~/Default.aspx");
                }
            }

            if (Session["UserScope"] != null && Session["UserName"] != null && Session["UserRole"] != null)
            {
                LoadCategories();
                FillImage();
                FillOrgImage();
                //lblUserID.Text = Session["UserName"].ToString().ToUpper();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }



        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {

            if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
            {

            }
            else
            {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                inEr.InsertErrorLogsF(Session["UserName"].ToString()
    , " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
                Response.Redirect("~/Error/Error.html");
            }
        }
    }
    protected void FillOrgImage()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(@"Select top 1 b.* from SD_User_Master a inner join 
                                                            SD_OrgLogo b 
                                                            on a.Org_ID=b.Org_ID
                                                            where a.Org_ID=@Orgid", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Orgid", Session["Orgid"].ToString());
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {

                                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["FileData"]);
                                //txtAccountManagerEmail.Text = dt.Rows[0]["FileData"].ToString();

                                if (string.IsNullOrEmpty(imageUrl))
                                {
                                    imgOrg.ImageUrl = "~/Images/Hitachi-Logo-Dark.png";
                                }
                                else
                                {
                                    imgOrg.ImageUrl = imageUrl;
                                }

                            }
                            else
                            {
                                imgOrg.ImageUrl = "~/Images/Hitachi-Logo-Dark.png";
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void FillImage()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select  * from SD_User_Master  where  FileData is not null and LoginName=@Username", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Username", Session["LoginName"].ToString());
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {

                                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["FileData"]);
                                //txtAccountManagerEmail.Text = dt.Rows[0]["FileData"].ToString();

                                if (string.IsNullOrEmpty(imageUrl))
                                {
                                    img.ImageUrl = "~/dist/img/user2-160x160.jpg";
                                }
                                else
                                {
                                    img.ImageUrl = imageUrl;
                                }

                            }
                            else
                            {
                                img.ImageUrl = "~/dist/img/user1-128x128.jpg";
                            }
                        }
                    }
                }
            }
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
            {

            }
            else
            {
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                inEr.InsertErrorLogsF(Session["UserName"].ToString()
    , " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
                Response.Redirect("~/Error/Error.html");
            }
        }
    }
    private void LoadCategories()
    {
        if (Session["UserScope"].ToString() == "Master")
        {
            allCategories = GetAllCategories();
            rptCategories.DataSource = GetCategories();
            rptCategories.DataBind();
        }
        else
        {
            allCategories = GetAllCategoriesNonAdmin();
            rptCategories.DataSource = GetCategoriesNonAdmin();
            rptCategories.DataBind();
        }
    }
    private DataTable GetCategories()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand selectCommand = new SqlCommand("select  MenuID,MenuName,MenuLocation,ParentID,MenuIcon,IconName from SD_Navigation WHERE ParentID = 0  and MenuStatus='Active' order by ParentIDOrder asc", connection);
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                dt.Load(reader);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return dt;
    }
    private DataTable GetCategoriesNonAdmin()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand selectCommand = new SqlCommand(@" select * from(select distinct MR.[MenuID],MR.[MenuName],MR.[MenuLocation],MR.[ParentID],R.[UserName],R.[MenuStatus],ParentIDOrder,MenuIcon,IconName from [dbo].[SD_Navigation] as MR                  join                          SD_roles as R                      on MR.MenuID = R.MenuID and  MR.MenuName = R.MenuName   where R.UserRole='" + this.Session["UserRole"].ToString() + "' and R.MenuStatus='Active' and MR.ParentID='0')tt order by ParentIDOrder asc", connection);
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                dt.Load(reader);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return dt;
    }
    private DataTable GetAllCategories()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand selectCommand = new SqlCommand("select  MenuID,MenuName,MenuLocation,ParentID,MenuIcon,IconName from SD_Navigation where  MenuStatus='Active' order by ChildIDOrder asc", connection);
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                dt.Load(reader);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return dt;
    }
    private DataTable GetAllCategoriesNonAdmin()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand selectCommand = new SqlCommand(@"select * from(select distinct MR.[MenuID],MR.[MenuName],MR.[MenuLocation],MR.[ParentID],R.[UserName],R.[MenuStatus],ParentIDOrder,ChildIDOrder,MenuIcon,IconName from [dbo].[SD_Navigation] as MR                       join                        SD_roles as R                           on MR.MenuID = R.MenuID and  MR.MenuName = R.MenuName   where R.UserRole='" + this.Session["UserRole"].ToString() + "' and R.MenuStatus='Active')tt order by ChildIDOrder asc", connection);
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                dt.Load(reader);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return dt;
    }

    //protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        if (allCategories != null)
    //        {
    //            DataRowView drv = e.Item.DataItem as DataRowView;
    //            string ID = drv["MenuID"].ToString();
    //            string parentMenuLocation = drv["MenuLocation"].ToString();
    //            bool isParentActive = IsCurrentPage(parentMenuLocation);

    //            DataRow[] rows = allCategories.Select("ParentID=" + ID, "MenuName");
    //            if (rows.Length > 0)
    //            {
    //                StringBuilder sb = new StringBuilder();
    //                sb.Append("<ul class='nav nav-treeview'>");
    //                bool hasActiveChild = false;
    //                foreach (var item in rows)
    //                {
    //                    string menuLocation = item["MenuLocation"].ToString();
    //                    string menuName = item["MenuName"].ToString();
    //                    bool isCurrentPage = IsCurrentPage(menuLocation);
    //                    string cssClass = isCurrentPage ? "nav-link active" : "nav-link";
    //                    if (isCurrentPage) hasActiveChild = true;
    //                    sb.Append("<li class='nav-item'><a class='" + cssClass + "' href='" + menuLocation + "'><i class='nav-icon far fa-circle'></i><p>" + menuName + "</p></a></li>");
    //                }
    //                sb.Append("</ul>");

    //                Literal ltrlSubMenu = e.Item.FindControl("ltrlSubMenu") as Literal;
    //                if (ltrlSubMenu != null)
    //                {
    //                    ltrlSubMenu.Text = sb.ToString();
    //                }

    //                // Set parent menu item classes
    //                if (isParentActive || hasActiveChild)
    //                {
    //                    var parentLi = e.Item.FindControl("parentLi") as HtmlGenericControl;
    //                    if (parentLi != null)
    //                    {
    //                        parentLi.Attributes["class"] += " menu-is-opening menu-open";
    //                    }

    //                    var parentMenu = e.Item.FindControl("parentmenu") as HtmlAnchor;
    //                    if (parentMenu != null)
    //                    {
    //                        parentMenu.Attributes["class"] += " active";
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (allCategories != null)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                string ID = drv["MenuID"].ToString();
                string parentMenuLocation = drv["MenuLocation"].ToString();
                string menuIcon = drv["MenuIcon"].ToString(); // Get icon class from the database
                //lbliconname.Text = drv["MenuIcon"].ToString(); // Get icon class from the database
                Label lblName = e.Item.FindControl("lblName") as Label;
                if (lblName != null)
                {
                    lblName.Text = drv["IconName"].ToString();
                }
                bool isParentActive = IsCurrentPage(parentMenuLocation);

                DataRow[] rows = allCategories.Select("ParentID=" + ID, "MenuName");
                if (rows.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<ul>");

                    bool hasActiveChild = false;
                    foreach (var item in rows)
                    {
                        string menuLocation = item["MenuLocation"].ToString();
                        string menuName = item["MenuName"].ToString();
                        string subMenuIcon = item["MenuIcon"].ToString(); // Get child menu icon class
                        bool isCurrentPage = IsCurrentPage(menuLocation);
                        string cssClass = isCurrentPage ? "active" : "";
                        if (isCurrentPage) hasActiveChild = true;

                        sb.Append("<li><a href='" + menuLocation + "' class='" + cssClass + "'><i class='" + subMenuIcon + "'></i>" + menuName + "</a></li>");
                    }

                    sb.Append("</ul>");

                    Literal ltrlSubMenu = e.Item.FindControl("ltrlSubMenu") as Literal;
                    if (ltrlSubMenu != null)
                    {
                        ltrlSubMenu.Text = sb.ToString();
                    }

                    // Set parent menu item classes
                    if (isParentActive || hasActiveChild)
                    {
                        var parentLi = e.Item.FindControl("parentLi") as HtmlGenericControl;
                        if (parentLi != null)
                        {
                            parentLi.Attributes["class"] += " menu-open";
                        }

                        var parentMenu = e.Item.FindControl("parentmenu") as HtmlAnchor;
                        if (parentMenu != null)
                        {
                            parentMenu.Attributes["class"] += " active";
                        }
                    }
                }
            }
        }
    }

  


    private bool IsCurrentPage(string menuLocation)
    {
        string currentPage = Page.Request.Url.AbsolutePath;
        return currentPage.EndsWith(menuLocation, StringComparison.OrdinalIgnoreCase);
    }
}

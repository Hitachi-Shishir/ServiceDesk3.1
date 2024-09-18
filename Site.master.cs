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
    private DataTable allCategories = new DataTable();
    private InsertErrorLogs inEr = new InsertErrorLogs();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            ValidateLoginSession();

            if (Session["UserScope"] != null && Session["UserName"] != null && Session["UserRole"] != null)
            {
                LoadCategories();
                FillImage();
                FillOrgImage();
                lblUserID.Text = Session["UserName"].ToString().ToUpper();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        catch (ThreadAbortException) { /* Ignore thread abort exceptions */ }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    private void ValidateLoginSession()
    {
        string loginSessionId = Convert.ToString(Session["Login_Session_Id"]);
        if (!string.IsNullOrEmpty(loginSessionId))
        {
            string sql = $"SELECT COUNT(1) FROM SD_User_Master WITH(NOLOCK) WHERE UserID='{Convert.ToString(Session["UserID"])}' AND LoginSessionID='{loginSessionId.Trim()}'";
            int exists = Convert.ToInt32(database.GetScalarValue(sql));
            if (exists != 1)
            {
                Session.Abandon();
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx", true);
            }
        }
    }

    private void LoadCategories()
    {
        allCategories = Session["UserScope"].ToString() == "Master" ? GetAllCategories() : GetAllCategoriesNonAdmin();
        rptCategories.DataSource = Session["UserScope"].ToString() == "Master" ? GetCategories() : GetCategoriesNonAdmin();
        rptCategories.DataBind();
    }

    protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (allCategories != null)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                if (drv == null) return;

                string id = drv["MenuID"]?.ToString() ?? string.Empty;
                string parentMenuLocation = drv["MenuLocation"]?.ToString() ?? string.Empty;
                string parentMenuName = drv["MenuName"]?.ToString() ?? string.Empty;
                string menuIcon = drv["MenuIcon"]?.ToString() ?? string.Empty;

                Label lblName = e.Item.FindControl("lblName") as Label;
                if (lblName != null)
                {
                    lblName.Text = drv["IconName"]?.ToString() ?? string.Empty;
                }

                bool isParentActive = IsCurrentPage(parentMenuLocation);
                if (isParentActive)
                {
                    lblpnlPage.Text = parentMenuName;
                }

                DataRow[] rows = allCategories.Select($"ParentID = {id}", "MenuName");
                if (rows.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<ul>");

                    bool hasActiveChild = false;
                    foreach (DataRow item in rows)
                    {
                        string menuLocation = item["MenuLocation"]?.ToString() ?? string.Empty;
                        string menuName = item["MenuName"]?.ToString() ?? string.Empty;
                        bool isCurrentPage = IsCurrentPage(menuLocation);
                        string cssClass = isCurrentPage ? "active" : "";
                        if (isCurrentPage)
                        {
                            hasActiveChild = true;
                            lblpnlPage.Text = menuName;
                        }

                        sb.Append($"<li><a href='{menuLocation}' class='{cssClass}'><i class='material-icons-outlined'>arrow_right</i>{menuName}</a></li>");
                    }

                    sb.Append("</ul>");

                    Literal ltrlSubMenu = e.Item.FindControl("ltrlSubMenu") as Literal;
                    if (ltrlSubMenu != null)
                    {
                        ltrlSubMenu.Text = sb.ToString();
                    }

                    var parentMenu = e.Item.FindControl("parentmenu") as HtmlAnchor;
                    if (parentMenu != null)
                    {
                        if (!string.IsNullOrEmpty(parentMenuLocation) && parentMenuLocation != "#")
                        {
                            parentMenu.HRef = parentMenuLocation;
                            parentMenu.Attributes["class"] = (parentMenu.Attributes["class"] ?? "") + (isParentActive ? " active" : "");
                        }
                        else
                        {
                            parentMenu.Attributes["href"] = "javascript:void(0);";
                            parentMenu.Attributes["class"] = (parentMenu.Attributes["class"] ?? "") + (isParentActive ? " menu-open" : "");
                        }
                    }

                    var parentLi = e.Item.FindControl("parentLi") as HtmlGenericControl;
                    if (parentLi != null)
                    {
                        parentLi.Attributes["class"] = (parentLi.Attributes["class"] ?? "") + (isParentActive || hasActiveChild ? " menu-open" : "");
                    }
                }
            }
        }
    }

    private bool IsCurrentPage(string menuLocation)
    {
        if (string.IsNullOrEmpty(menuLocation)) return false;
        string currentPage = Page.Request.Url.AbsolutePath;
        return currentPage.EndsWith(menuLocation, StringComparison.OrdinalIgnoreCase) ||
               currentPage.Equals(menuLocation, StringComparison.OrdinalIgnoreCase);
    }

    private DataTable GetCategories()
    {
        string sql = "SELECT MenuID, MenuName, MenuLocation, ParentID, MenuIcon, IconName FROM SD_Navigation WHERE ParentID = 0 AND MenuStatus='Active' ORDER BY ParentIDOrder ASC";
        return ExecuteQuery(sql);
    }

    private DataTable GetCategoriesNonAdmin()
    {
        string sql = @"SELECT DISTINCT MR.MenuID, MR.MenuName, MR.MenuLocation, MR.ParentID, R.UserName, R.MenuStatus, ParentIDOrder, MenuIcon, IconName 
                       FROM SD_Navigation AS MR
                       JOIN SD_roles AS R ON MR.MenuID = R.MenuID AND MR.MenuName = R.MenuName
                       WHERE R.UserRole = @UserRole AND R.MenuStatus = 'Active' AND MR.ParentID = '0'
                       ORDER BY ParentIDOrder ASC";
        return ExecuteQuery(sql, new SqlParameter("@UserRole", Session["UserRole"].ToString()));
    }

    private DataTable GetAllCategories()
    {
        string sql = "SELECT MenuID, MenuName, MenuLocation, ParentID, MenuIcon, IconName FROM SD_Navigation WHERE MenuStatus='Active' ORDER BY ChildIDOrder ASC";
        return ExecuteQuery(sql);
    }

    private DataTable GetAllCategoriesNonAdmin()
    {
        string sql = @"SELECT DISTINCT MR.MenuID, MR.MenuName, MR.MenuLocation, MR.ParentID, R.UserName, R.MenuStatus, ParentIDOrder, ChildIDOrder, MenuIcon, IconName
                       FROM SD_Navigation AS MR
                       JOIN SD_roles AS R ON MR.MenuID = R.MenuID AND MR.MenuName = R.MenuName
                       WHERE R.UserRole = @UserRole AND R.MenuStatus = 'Active'
                       ORDER BY ChildIDOrder ASC";
        return ExecuteQuery(sql, new SqlParameter("@UserRole", Session["UserRole"].ToString()));
    }

    private DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
    {
        DataTable dt = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        sda.Fill(dt);
                    }
                    catch (SqlException)
                    {
                        // Log the error or handle it as needed
                        throw;
                    }
                }
            }
        }
        return dt;
    }

    protected void FillImage()
    {
        try
        {
            string sql = "SELECT FileData FROM SD_User_Master WHERE FileData IS NOT NULL AND LoginName = @Username";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Username", Session["LoginName"].ToString());
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0 && dt.Rows[0]["FileData"] != DBNull.Value)
                        {
                            string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["FileData"]);
                            img.ImageUrl = imageUrl;
                        }
                        else
                        {
                            img.ImageUrl = "~/dist/img/user1-128x128.jpg";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    protected void FillOrgImage()
    {
        try
        {
            string sql = @"SELECT TOP 1 b.FileData 
                           FROM SD_User_Master a 
                           INNER JOIN SD_OrgLogo b ON a.Org_ID = b.Org_ID
                           WHERE a.Org_ID = @Orgid";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Orgid", Session["Orgid"].ToString());
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0 && dt.Rows[0]["FileData"] != DBNull.Value)
                        {
                            string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["FileData"]);
                            imgOrg.ImageUrl = imageUrl;
                        }
                        else
                        {
                            imgOrg.ImageUrl = "~/Images/Hitachi-Logo-Dark.png";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log the error, but don't redirect
            //inEr.InsertErrorLogsF(Session["UserName"].ToString(), Request.Url.ToString(), "FillOrgImage", ex.ToString());
        }
    }

    private void HandleException(Exception ex)
    {
        if (!ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
        {
            var st = new StackTrace(ex, true);
            var frame = st.GetFrame(0);
            var line = frame.GetFileLineNumber();
            inEr.InsertErrorLogsF(Session["UserName"].ToString(),
                $"{Request.Url} Got Exception Line Number: {line} {ex}");
            Response.Redirect("~/Error/Error.html");
        }
    }
}
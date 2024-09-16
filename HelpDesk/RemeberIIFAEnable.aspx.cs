using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RemeberIIFAEnable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Convert.ToString(Session["UserName"]) == "")
        {
            Response.Redirect("~/default.aspx");
        }
        if (!IsPostBack)
        {
            getOrg();
        }
    }
    private void getOrg()
    {
        try
        {
            string sql = "select * from SD_OrgMaster";
            DataTable dt = database.GetDataTable(sql);
            ddlOrg.DataSource = dt;
            ddlOrg.DataTextField = "OrgName";
            ddlOrg.DataValueField = "Org_ID";
            ddlOrg.DataBind();
            ddlOrg.Items.Insert(0, new ListItem("----Select----", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    public void getData()
    {
        string sql = "select u.UserID,UserName,LoginName,Designation,o.OrgName, RememberISMfa, u.ISMfa,mf.MFAStatus," +
            " DATEDIFF(DAY, Cast(RememberISMfaTime as date), cast(getdate() as date)) - 30 RemainingDays, " +
            "mf.SecretKey from SD_User_Master u left join SD_OrgMaster o on u.Org_ID = o.Org_ID " +
            "left join SD_MFa mf on mf.UserID = u.UserID ";
        if (ddlOrg.SelectedValue != "0")
        {
            sql = sql + " where u.Org_ID='" + ddlOrg.SelectedValue + "'";
        }
        if (ddlUser.SelectedValue != "0")
        {
            sql = sql + " and u.UserID='" + ddlUser.SelectedValue + "'";
        }
        if (ddlFIlterType.SelectedValue == "1")
        {
            sql = sql + " And RememberISMfa = 1";
            DataTable dt = database.GetDataTable(sql);
            grd.DataSource = dt;
            grd.DataBind();
            GridFormat1(dt);
            RembMFA.Visible = true;
            MFA.Visible = false;
            //grv.Columns[5].Visible = true;
            //grv.Columns[6].Visible = true;
            //grv.Columns[7].Visible = true;
            //grv.Columns[8].Visible = false;
        }
        if (ddlFIlterType.SelectedValue == "2")
        {
            DataTable dt = database.GetDataTable(sql);
            grv.DataSource = dt;
            grv.DataBind();
            GridFormat(dt);
            RembMFA.Visible = false;
            MFA.Visible = true;
        }
    }
    protected void GridFormat(DataTable dt)
    {
        grv.UseAccessibleHeader = true;
        grv.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (grv.TopPagerRow != null)
        {
            grv.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (grv.BottomPagerRow != null)
        {
            grv.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            grv.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    protected void GridFormat1(DataTable dt)
    {
        grd.UseAccessibleHeader = true;
        grd.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (grd.TopPagerRow != null)
        {
            grd.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (grd.BottomPagerRow != null)
        {
            grd.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            grd.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgIsMfaStatus = (Image)e.Row.FindControl("imgIsMfaStatus");
            object isMfaEnabledObj = DataBinder.Eval(e.Row.DataItem, "MFAStatus");
            object secretKey = DataBinder.Eval(e.Row.DataItem, "SecretKey");

            // Convert MFAStatus to a boolean, handle null or 0 as disabled (false)
            bool isMfaEnabled = (isMfaEnabledObj != null && isMfaEnabledObj != DBNull.Value && Convert.ToBoolean(isMfaEnabledObj));

            // Check SecretKey for null or DBNull.Value
            if ((secretKey == null || secretKey == DBNull.Value) && isMfaEnabled)
            {
                imgIsMfaStatus.ImageUrl = "~/assets/icon/pngwing.com.png";
                imgIsMfaStatus.ToolTip = "2 FA is Enabled but not Registered!";
            }
            else if (isMfaEnabled)
            {
                imgIsMfaStatus.ImageUrl = "~/assets/icon/checkmark.png";
                imgIsMfaStatus.ToolTip = "2 FA is Enabled and Registered.";
            }
            else
            {
                imgIsMfaStatus.ImageUrl = "~/assets/icon/cross.png";
                imgIsMfaStatus.ToolTip = "2 FA is Disabled!";
            }
        }
    }

    public void getUser()
    {
        try
        {
            string sql = "select * from SD_User_Master where Org_ID='" + ddlOrg.SelectedValue + "'";
            DataTable dt = database.GetDataTable(sql);
            ddlUser.DataSource = dt;
            ddlUser.DataTextField = "UserName";
            ddlUser.DataValueField = "UserID";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("----Select----", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        getUser();
        getData();
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {
        getData();
    }
    protected void chkEnable_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chk.NamingContainer;
        HiddenField hdnid = (HiddenField)row.FindControl("hdnid");
        string id = hdnid.Value;
        if (id != "")
        {
            string sql = "UPDATE SD_User_Master set RememberISMfa=0, RememberISMfaTime=null where UserID='" + id + "'";
            database.ExecuteNonQuery(sql);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RemeberIIFAEnable.aspx");
    }
    protected void lnkBtn_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        HiddenField hdnid = (HiddenField)gvr.FindControl("hdnuid");
        HiddenField hdnismfa = (HiddenField)gvr.FindControl("hdnismfa");
        string UserID = hdnid.Value;
        string MFA = hdnismfa.Value;
        if (MFA.ToUpper() == "TRUE")
        {
            string sql = "update SD_Mfa set SecretKey=null, MFAStatus='0' where UserID='" + UserID + "'" +
                        "update SD_User_Master set ISMfa='0' where UserID='" + UserID + "'";
            database.ExecuteNonQuery(sql);
        }
        else
        {

            string sql = "update SD_Mfa set SecretKey=null, MFAStatus='1' where UserID='" + UserID + "'" +
                        "update SD_User_Master set ISMfa='0' where UserID='" + UserID + "'";
            database.ExecuteNonQuery(sql);
        }
        getData();
    }
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        HiddenField hdnid = (HiddenField)gvr.FindControl("hdnid");
        string uid = hdnid.Value;
        if (uid != "")
        {
            string sql = "UPDATE SD_User_Master set RememberISMfa=0, RememberISMfaTime=null where UserID='" + uid + "'";
            database.ExecuteNonQuery(sql);
        }
        getData();
    }
}
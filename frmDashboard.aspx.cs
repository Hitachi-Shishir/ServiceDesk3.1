using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmDashboard : System.Web.UI.Page
{
    Util obj = new Util();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"]==null)
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["UserRole"]).ToUpper() == "MASTER")
            {
                DataSet ds = GetDataDashboard("","",Convert.ToDateTime("1900-01-01"),
                    Convert.ToDateTime("1900-01-01"), "","");
            }
            else if (Convert.ToString(Session["UserRole"]).ToUpper() == "ADMIN")
            {
                DataSet ds = GetDataDashboard("", "", Convert.ToDateTime("1900-01-01"),
                    Convert.ToDateTime("1900-01-01"), "", Convert.ToString(Session["OrgID"]));
            }
            else
            {
                DataSet ds = GetDataDashboard("", "", Convert.ToDateTime("1900-01-01"),
                    Convert.ToDateTime("1900-01-01"), Convert.ToString(Session["OrgID"]), Convert.ToString(Session["OrgID"]));
            }
        }
    }
    public DataSet GetDataDashboard(string ReqType, string Category, DateTime frmDate, DateTime toDate,
        string UserID, string Orgid)
    {
        DataSet ds= new DataSet();
        ds = obj.getDashboardData(ReqType, Category, frmDate, toDate, UserID, Orgid);
        return ds;
    }

}
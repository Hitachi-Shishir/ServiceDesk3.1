using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmEditTicketbyAssigne : System.Web.UI.Page
{
    InsertErrorLogs inEr = new InsertErrorLogs();
    public enum MessageType { success, error, info, warning };
    protected void ShowMessage(MessageType type, string Message)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "Showalert('" + type + "','" + Message + "');", true);
    }
    protected override void OnInit(EventArgs e)
    {
        //try
        //{
        //Change your condition here

        if (Session["Popup"] != null)
        {
            if (Session["Popup"].ToString() == "Insert")
            {
                ShowMessage(MessageType.success, "Ticket Generated  Successfully!!");


            }
            if (Session["Popup"].ToString() == "Update")
            {
                ShowMessage(MessageType.success, "Ticket Updated Successfully!!");


            }

            Session.Remove("Popup");
            Session.Remove("CategoryID");

        }


        //}
        //catch (Exception ex)
        //{
        //	ExceptionLogging.SendErrorToText(ex);

        //}
    }
    public string TicketId;
    public string DeskRef;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null & Session["LoginName"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        try
        {
            rfvddlResoultion.Enabled = false;
            rfvtxtResolution.Enabled = false;


            if (!IsPostBack)
            {
                if (Session["OrgID"] != null && Session["UserScope"] != null && Session["UserName"] != null && Session["OrgID"] != null)
                {
                    if (Request.QueryString["redirected"] == "true")
                    {
                        Response.AppendHeader("Refresh", "1;url=frmEditTicketbyAssigne.aspx?TicketId=" + Request.QueryString["TicketId"] + "&redirected=false&Desk=" + Request.QueryString["Desk"] + "&NamelyId=" + Request.QueryString["NamelyId"] + "");
                    }
                    if (ddlRequestType.SelectedValue == "Incident")
                    {
                        rfvddlAssigne.Enabled = true;
                        rfvddlAssigne.Visible = true;
                    }
                    else
                    {
                        rfvddlAssigne.Enabled = false;
                        rfvddlAssigne.Visible = false;
                    }

                    Session["AssigneUpdate"] = "False";
                    FillServDesk();
                    txtSummary.Enabled = false;

                    txtDescription.Attributes.Add("disabled", "true");

                    //TicketId = System.Net.WebUtility.HtmlDecode(HttpContext.Current.Request.QueryString["TicketId"]);
                    TicketId = Request.QueryString["TicketId"].ToString();
                    DeskRef = Request.QueryString["Desk"].ToString();
                    FillResolutionDetails();
                    FillDepartment();
                    FillLocation();
                    ddlCategory1.ClearSelection();
                    ddlCategory2.ClearSelection();
                    ddlCategory3.ClearSelection();
                    ddlCategory4.ClearSelection();
                    ddlCategory5.ClearSelection();
                    ddlCategory6.ClearSelection();
                    ddlSeverity.ClearSelection();
                    ddlPriority.ClearSelection();
                    ddlRequestType.Items.FindByText(DeskRef).Selected = true;
                    ddlRequestType_SelectedIndexChanged(sender, e);
                    FillAssignee();
                    FillAssigneeForChange();
                    FillSummary();
                    UpdateTicketPanel();
                    lblTicket.Text = " -Number : " + TicketId;

                    AssigneClick = 0;
                    if (Session["UserScope"].ToString() == "Technician")
                    {
                        ddlAssigne.Enabled = false;
                        rfvddlAssigne.Enabled = true;
                        rfvddlAssigne.Visible = true;
                    }
                    else
                    {
                        ddlAssigne.Enabled = true;
                    }

                    AddDefaultFirstRecordForImpact();
                    AddDefaultFirstRecordForRollOut();
                    AddDefaultFirstRecordForTask();
                    if (DeskRef == "Change Request")
                    {
                        btnImpactDetails.Visible = true;
                        btnRolloutPlan.Visible = true;
                        btnDowntime.Visible = true;
                        btnTaskAssociation.Visible = true;
                        pnlShowRollOutDetails.Visible = false;
                        //pnlAddRollout.Visible = false;
                        //	pnlRollOutGrid.Visible = false;
                        pnlIncident.Visible = true;
                        pnlShowImpactDetails.Visible = false;
                        //pnlImpactGrid.Visible = false;
                        //pnlAddImpact.Visible = false;
                        pnlDownTime.Visible = false;
                        pnlTaksAssociation.Visible = false;
                    }
                    else
                    {
                        btnImpactDetails.Visible = false;
                        btnRolloutPlan.Visible = false;
                        btnDowntime.Visible = false;
                        btnTaskAssociation.Visible = false;
                        pnlShowRollOutDetails.Visible = false;
                        //pnlAddRollout.Visible = false;
                        //	pnlRollOutGrid.Visible = false;
                        pnlIncident.Visible = true;
                        pnlShowImpactDetails.Visible = false;
                        //pnlImpactGrid.Visible = false;
                        //pnlAddImpact.Visible = false;
                        pnlDownTime.Visible = false;
                        pnlTaksAssociation.Visible = false;


                    }
                }


                else
                {
                    Response.Redirect("/Default.aspx");
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
            if (ex.ToString().Contains("ThreadAbortException"))
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
    public static string DeskName;
    private void FillDepartment()
    {
        try
        {
            DataTable FillDepartment = new SDTemplateFileds().FillDepartment(Convert.ToInt64(Request.QueryString["NamelyId"].ToString()));

            ddlDepartment.DataSource = FillDepartment;
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentCode";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));


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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }
        }
    }
    private void FillLocation()
    {
        try
        {
            DataTable FillLocation = new SDTemplateFileds().FillLocation(Convert.ToInt64(Request.QueryString["NamelyId"].ToString()));

            ddlLocation.DataSource = FillLocation;
            ddlLocation.DataTextField = "LocName";
            ddlLocation.DataValueField = "LocCode";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));


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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }
        }
    }
    private void FillSummary()
    {
        try
        {
            GetFileAttached();


            long CategoryFk;
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select top 1 * from vSDTicket where TicketNumber=@TicketNumber and OrgId=@OrgId"))
                {
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@TicketNumber", ddlOpenticket.SelectedValue);
                    cmd.Parameters.AddWithValue("@TicketNumber", Request.QueryString["TicketId"].ToString());
                    cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                    //cmd.Parameters.AddWithValue("@TicketNumber", "IN007195");
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                DeskName = dt.Rows[0]["ServiceDesk"].ToString();
                                //	ddlRequestType.Items.FindByText(DeskName).Selected = true;

                                if (ddlRequestType.SelectedValue == "Incident")
                                {
                                    pnlIncident.Visible = true;

                                }
                                if (ddlRequestType.SelectedValue == "Incident")
                                {
                                    rfvddlAssigne.Enabled = true;
                                    rfvddlAssigne.Visible = true;
                                }
                                else
                                {
                                    rfvddlAssigne.Enabled = false;
                                    rfvddlAssigne.Visible = false;
                                }
                                //ddlRequestType.Items.FindByText("Incident").Selected = true;
                                //ddlRequestType_SelectedIndexChanged(sender, e);
                                txtSummary.Text = dt.Rows[0]["Summary"].ToString();
                                //txtticketNumber.Text = dt.Rows[0]["TicketNumber"].ToString();
                                txtSubmitterName.Text = dt.Rows[0]["SubmitterName"].ToString();
                                txtSubmitterEmail.Text = dt.Rows[0]["SubmitterEmail"].ToString();
                                txtPhoneNumber.Text = dt.Rows[0]["SubmitterPhone"].ToString();
                                FillCategory1();

                                if (ddlSeverity.Items.FindByValue(dt.Rows[0]["sdSeverityFK"].ToString()) != null)
                                {
                                    ddlSeverity.SelectedValue = dt.Rows[0]["sdSeverityFK"].ToString();
                                }
                                if (ddlPriority.Items.FindByValue(dt.Rows[0]["sdPriorityFK"].ToString()) != null)
                                {
                                    ddlPriority.SelectedValue = dt.Rows[0]["sdPriorityFK"].ToString();
                                }
                                if (ddlAssigne.Items.FindByValue(dt.Rows[0]["assigneeParticipantFK"].ToString()) != null)
                                {
                                    ddlAssigne.SelectedValue = dt.Rows[0]["assigneeParticipantFK"].ToString();
                                }
                                if (ddlStage.Items.FindByValue(dt.Rows[0]["sdStageFK"].ToString()) != null)
                                {
                                    ddlStage.SelectedValue = dt.Rows[0]["sdStageFK"].ToString();
                                }
                                FillStatus();
                                if (ddlStatus.Items.FindByValue(dt.Rows[0]["sdStatusFK"].ToString()) != null)
                                {
                                    ddlStatus.SelectedValue = dt.Rows[0]["sdStatusFK"].ToString();
                                }
                                if (ddlLocation.Items.FindByValue(dt.Rows[0]["location"].ToString()) != null)
                                {
                                    ddlLocation.SelectedValue = dt.Rows[0]["location"].ToString();
                                }
                                if (ddlDepartment.Items.FindByValue(dt.Rows[0]["Department"].ToString()) != null)
                                {
                                    ddlDepartment.SelectedValue = dt.Rows[0]["Department"].ToString();
                                }
                                CategoryFk = Convert.ToInt64(dt.Rows[0]["sdCategoryFK"].ToString());
                                DataTable Category1 = new SDTemplateFileds().GetTicketCategory(CategoryFk, 1);
                                DataTable Category2 = new SDTemplateFileds().GetTicketCategory(CategoryFk, 2);
                                DataTable Category3 = new SDTemplateFileds().GetTicketCategory(CategoryFk, 3);
                                DataTable Category4 = new SDTemplateFileds().GetTicketCategory(CategoryFk, 4);
                                DataTable Category5 = new SDTemplateFileds().GetTicketCategory(CategoryFk, 5);



                                if (Category1.Rows.Count > 0)
                                {
                                    string s;
                                    s = Category1.Rows[0]["ref"].ToString();
                                    //	
                                    if (ddlCategory1.Items.FindByValue(s) != null)
                                    {
                                        ddlCategory1.Items.FindByValue(s).Selected = true;
                                        hdnCategoryID.Value = ddlCategory1.SelectedValue;


                                    }

                                }
                                else
                                {
                                    ddlCategory2.ClearSelection();
                                    ddlCategory2.Enabled = false;
                                    divCategory2.Attributes.Add("style", "display: none;");
                                    ddlCategory3.ClearSelection();
                                    ddlCategory4.ClearSelection();
                                    ddlCategory5.ClearSelection();
                                    divCategory3.Attributes.Add("style", "display: none;");
                                    divCategory4.Attributes.Add("style", "display: none;");
                                    divCategory5.Attributes.Add("style", "display: none;");
                                }
                                if (Category2.Rows.Count > 0)
                                {
                                    FillCategory2();
                                    string s2;
                                    s2 = Category2.Rows[0]["ref"].ToString();
                                    if (ddlCategory2.Items.FindByValue(s2) != null)
                                    {
                                        ddlCategory2.Items.FindByValue(s2).Selected = true;
                                        hdnCategoryID.Value = ddlCategory2.SelectedValue;
                                    }

                                    divCategory2.Attributes.Add("style", "display: block;");
                                    divCategory3.Attributes.Add("style", "display: none;");
                                    divCategory4.Attributes.Add("style", "display: none;");
                                    divCategory5.Attributes.Add("style", "display: none;");
                                }
                                else

                                {


                                    ddlCategory2.ClearSelection();
                                    ddlCategory3.ClearSelection();
                                    ddlCategory4.ClearSelection();
                                    ddlCategory5.ClearSelection();
                                    divCategory2.Attributes.Add("style", "display: none;");
                                    divCategory3.Attributes.Add("style", "display: none;");
                                    divCategory4.Attributes.Add("style", "display: none;");
                                    divCategory5.Attributes.Add("style", "display: none;");
                                }

                                if (Category3.Rows.Count > 0)
                                {
                                    FillCategory3();
                                    string s3;
                                    s3 = Category3.Rows[0]["ref"].ToString();

                                    if (ddlCategory3.Items.FindByValue(s3) != null)
                                    {
                                        ddlCategory3.Items.FindByValue(s3).Selected = true;
                                        hdnCategoryID.Value = ddlCategory3.SelectedValue;
                                    }
                                    divCategory2.Attributes.Add("style", "display: block;");
                                    divCategory3.Attributes.Add("style", "display: block;");
                                    divCategory4.Attributes.Add("style", "display: none;");
                                    divCategory5.Attributes.Add("style", "display: none;");
                                }
                                else
                                {
                                    ddlCategory3.ClearSelection();

                                    ddlCategory5.ClearSelection();
                                    ddlCategory4.ClearSelection();
                                    divCategory3.Attributes.Add("style", "display: none;");
                                    divCategory4.Attributes.Add("style", "display: none;");
                                    divCategory5.Attributes.Add("style", "display: none;");
                                }
                                if (Category4.Rows.Count > 0)
                                {
                                    FillCategory4();
                                    string s4;
                                    s4 = Category4.Rows[0]["ref"].ToString();

                                    if (ddlCategory4.Items.FindByValue(s4) != null)
                                    {
                                        ddlCategory4.Items.FindByValue(s4).Selected = true;
                                        hdnCategoryID.Value = ddlCategory4.SelectedValue;
                                    }

                                    divCategory2.Attributes.Add("style", "display: block;");
                                    divCategory3.Attributes.Add("style", "display: block;");
                                    divCategory4.Attributes.Add("style", "display: block;");
                                    divCategory5.Attributes.Add("style", "display: none;");

                                }
                                else
                                {

                                    ddlCategory5.ClearSelection();

                                    divCategory5.Attributes.Add("style", "display: none;");
                                }

                                if (Category5.Rows.Count > 0)
                                {
                                    FillCategory5();
                                    string s5;
                                    s5 = Category5.Rows[0]["ref"].ToString();

                                    if (ddlCategory5.Items.FindByValue(s5) != null)
                                    {
                                        ddlCategory5.Items.FindByValue(s5).Selected = true;
                                        hdnCategoryID.Value = ddlCategory5.SelectedValue;
                                    }
                                    divCategory2.Attributes.Add("style", "display: block;");
                                    divCategory3.Attributes.Add("style", "display: block;");
                                    divCategory4.Attributes.Add("style", "display: block;");
                                    divCategory5.Attributes.Add("style", "display: block;");
                                }


                                txtDescription.Value = System.Web.HttpUtility.HtmlDecode(dt.Rows[0]["Description"].ToString()).ToString();
                                //ddlDepartment.SelectedValue= dt.Rows[0]["Description"].ToString();
                                //txtcreatedby.Text = dt.Rows[0]["SubmitterName"].ToString();

                                //////////////////////////////       Change Fields Will populate  here   //////////////////////////
                                ///

                                if (DeskName == "Change Request")
                                {
                                    FillImpactDetails();
                                    FillRollOutDetails();
                                    FilltaskDetails();
                                }
                                if (dt.Rows[0]["status"].ToString().ToLower().Contains("closed") || dt.Rows[0]["status"].ToString().ToLower().Contains("resolved"))
                                {
                                    pnlTicket.Enabled = false;
                                    if (ddlResoultion.Items.FindByValue(dt.Rows[0]["sdSolutionTypeFK"].ToString()) != null)
                                    {
                                        ddlResoultion.SelectedValue = dt.Rows[0]["sdSolutionTypeFK"].ToString();
                                    }
                                    txtResolution.Value = System.Web.HttpUtility.HtmlDecode(dt.Rows[0]["solutionNote"].ToString());
                                }
                                else
                                {
                                    pnlTicket.Enabled = true;
                                }
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
            if (ex.ToString().Contains("ThreadAbort"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }
            //			
        }

    }

    private void FillImpactDetails()
    {
        try
        {

            DataTable Impact = new FillSDFields().FillImpactDetails(Request.QueryString["TicketId"].ToString());

            gvImpactGrid.DataSource = Impact;
            gvImpactGrid.DataBind();

        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    private void FillRollOutDetails()
    {
        try
        {

            DataTable RollOut = new FillSDFields().FillRollOutDetails(Request.QueryString["TicketId"].ToString());
            gvRollOutDetails.DataSource = RollOut;
            gvRollOutDetails.DataBind();


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    private void FilltaskDetails()
    {
        try
        {

            DataTable TaskAssign = new FillSDFields().FillTaskAssocDetails(Request.QueryString["TicketId"].ToString());

            gvTaskDetails.DataSource = TaskAssign;
            gvTaskDetails.DataBind();

        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }

    private void FillServDesk()
    {

        try
        {

            DataTable RequestType = new SDTemplateFileds().FillRequestType(Convert.ToInt64(Session["OrgID"].ToString()));

            ddlRequestType.DataSource = RequestType;
            ddlRequestType.DataTextField = "ReqTypeRef";
            ddlRequestType.DataValueField = "ReqTypeRef";
            ddlRequestType.DataBind();
            ddlRequestType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    private void FillCategory1()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT CategoryCodeRef,
           Categoryref FROM [dbo].fnGetCategoryFullPathForDesk('" + ddlRequestType.SelectedValue + "', '" + Request.QueryString["NamelyId"] + "',1) where Level=1 order by Categoryref asc", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {

                        // cmd.Parameters.AddWithValue("@Option", "ProcessDetails");
                        adp.SelectCommand.CommandTimeout = 180;
                        using (DataTable dt = new DataTable())
                        {
                            adp.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                ddlCategory1.DataSource = dt;
                                ddlCategory1.DataTextField = "CategoryCodeRef";
                                ddlCategory1.DataValueField = "Categoryref";
                                ddlCategory1.DataBind();
                                ddlCategory1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));
                            }
                            else
                            {
                                divCategory2.Attributes.Add("style", "display: none;");
                                ddlCategory3.ClearSelection();
                                ddlCategory4.ClearSelection();
                                ddlCategory5.ClearSelection();
                                divCategory3.Attributes.Add("style", "display: none;");
                                divCategory4.Attributes.Add("style", "display: none;");
                                divCategory5.Attributes.Add("style", "display: none;");
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
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    private DataTable FillCategoryLevel(int categoryLevel)
    {
        try
        {
            //	hdnVarCategoryIII.Value = hdnVarCategoryI.Value;
            DataTable dtFillCategory = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM [dbo].[fn_GetCategoryChildrenByRef]('" + ddlCategory1.SelectedValue + "',1,'" + Request.QueryString["NamelyId"] + "') where level='" + categoryLevel + "'  order by Categoryref asc", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {

                        // cmd.Parameters.AddWithValue("@Option", "ProcessDetails");
                        adp.SelectCommand.CommandTimeout = 180;
                        adp.Fill(dtFillCategory);
                        //using (DataTable dt = new DataTable())
                        //{


                        //}
                    }
                }
            }
            return dtFillCategory;

        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
            return null;
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

            return null;
        }
    }
    protected void ddlCategory1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillCategory2();
            ShowCustomFields(ddlRequestType.SelectedItem.Text, Request.QueryString["NamelyId"].ToString());
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    protected void FillCategory2()
    {
        try
        {
            hdnCategoryID.Value = ddlCategory1.SelectedValue.ToString();
            DataTable FillCategoryLevel2 = new DataTable();
            FillCategoryLevel2 = FillCategoryLevel(2);
            if (FillCategoryLevel2.Rows.Count > 0)
            {
                ddlCategory2.DataSource = FillCategoryLevel2;
                ddlCategory2.DataTextField = "CategoryCodeRef";
                ddlCategory2.DataValueField = "Categoryref";
                ddlCategory2.DataBind();
                ddlCategory2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));

                divCategory2.Attributes.Add("style", "display: block;");
                divCategory3.Attributes.Add("style", "display: none;");
                divCategory4.Attributes.Add("style", "display: none;");
                divCategory5.Attributes.Add("style", "display: none;");



            }


            else
            {
                ddlCategory2.ClearSelection();
                ddlCategory2.Enabled = false;
                FillCategoryLevel2 = null;
                divCategory2.Attributes.Add("style", "display: none;");
                ddlCategory3.ClearSelection();
                ddlCategory4.ClearSelection();
                ddlCategory5.ClearSelection();
                divCategory3.Attributes.Add("style", "display: none;");
                divCategory4.Attributes.Add("style", "display: none;");
                divCategory5.Attributes.Add("style", "display: none;");
                //ddlCatII.DataSource = null;
                //  ddlCatII.DataBind();
                // ddlCatII.Items.Insert(0, new ListItem("----------Select Category Level 2----------", "0"));
            }
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    protected void FillCategory3()
    {
        try
        {
            hdnCategoryID.Value = ddlCategory2.SelectedValue.ToString();
            DataTable FillCategoryLevel3 = FillCategoryLevel(3);
            if (FillCategoryLevel3.Rows.Count > 0)
            {
                ddlCategory3.DataSource = FillCategoryLevel3;
                ddlCategory3.DataTextField = "CategoryCodeRef";
                ddlCategory3.DataValueField = "Categoryref";
                ddlCategory3.DataBind();
                ddlCategory3.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));

                divCategory3.Attributes.Add("style", "display: block;");
                divCategory4.Attributes.Add("style", "display: none;");
                divCategory5.Attributes.Add("style", "display: none;");


            }
            else
            {
                ddlCategory3.ClearSelection();
                //ddlCategory3.Enabled = false;
                ddlCategory3.DataSource = null;
                divCategory2.Attributes.Add("style", "display: none;");

                divCategory3.Attributes.Add("style", "display: none;");
                divCategory4.Attributes.Add("style", "display: none;");
                divCategory5.Attributes.Add("style", "display: none;");
                ddlCategory3.DataBind();
                ddlCategory4.ClearSelection();
                ddlCategory4.Enabled = false;
                ddlCategory5.ClearSelection();
                ddlCategory5.Enabled = false;
            }
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    protected void FillCategory4()
    {
        try
        {
            hdnCategoryID.Value = ddlCategory3.SelectedValue.ToString();
            DataTable FillCategoryLevel4 = FillCategoryLevel(4);
            if (FillCategoryLevel4.Rows.Count > 0)
            {
                ddlCategory4.DataSource = FillCategoryLevel4;
                ddlCategory4.DataTextField = "CategoryCodeRef";
                ddlCategory4.DataValueField = "Categoryref";
                ddlCategory4.DataBind();
                ddlCategory4.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));


                divCategory2.Attributes.Add("style", "display: block;");
                divCategory3.Attributes.Add("style", "display: block;");
                divCategory4.Attributes.Add("style", "display: block;");
                divCategory5.Attributes.Add("style", "display: none;");



            }
            else
            {
                ddlCategory4.DataSource = null;
                ddlCategory4.DataBind();

                ddlCategory4.ClearSelection();
                ddlCategory4.Enabled = false;

                ddlCategory5.ClearSelection();
                ddlCategory5.Enabled = false;
                divCategory2.Attributes.Add("style", "display: none;");

                divCategory3.Attributes.Add("style", "display: none;");
                divCategory4.Attributes.Add("style", "display: none;");
                divCategory5.Attributes.Add("style", "display: none;");
            }
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    protected void FillCategory5()
    {
        try
        {
            hdnCategoryID.Value = ddlCategory4.SelectedValue.ToString();
            DataTable FillCategoryLevel4 = FillCategoryLevel(5);
            if (FillCategoryLevel4.Rows.Count > 0)
            {
                ddlCategory5.DataSource = FillCategoryLevel4;
                ddlCategory5.DataTextField = "CategoryCodeRef";
                ddlCategory5.DataValueField = "Categoryref";
                ddlCategory5.DataBind();
                ddlCategory5.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));

                divCategory2.Attributes.Add("style", "display: block;");
                divCategory3.Attributes.Add("style", "display: block;");
                divCategory4.Attributes.Add("style", "display: block;");
                divCategory5.Attributes.Add("style", "display: block;");



            }
            else
            {
                ddlCategory5.DataSource = null;
                ddlCategory5.DataBind();

                ddlCategory5.ClearSelection();
                ddlCategory5.Enabled = false;
                ddlCategory6.ClearSelection();
                ddlCategory6.Enabled = false;

                divCategory2.Attributes.Add("style", "display: none;");

                divCategory3.Attributes.Add("style", "display: none;");
                divCategory4.Attributes.Add("style", "display: none;");
                divCategory5.Attributes.Add("style", "display: none;");
            }
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    protected void ddlCategory2_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCategory3();
        ShowCustomFields(ddlRequestType.SelectedItem.Text, Request.QueryString["NamelyId"].ToString());
    }
    protected void ddlCategory3_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCategory4();
        ShowCustomFields(ddlRequestType.SelectedItem.Text, Request.QueryString["NamelyId"].ToString());
    }
    protected void ddlCategory4_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillCategory5();
        ShowCustomFields(ddlRequestType.SelectedItem.Text, Request.QueryString["NamelyId"].ToString());
    }
    protected void ddlCategory5_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnCategoryID.Value = ddlCategory5.SelectedValue.ToString();
        ShowCustomFields(ddlRequestType.SelectedItem.Text, Request.QueryString["NamelyId"].ToString());
        DataTable FillCategoryLevel4 = FillCategoryLevel(6);
        if (FillCategoryLevel4.Rows.Count > 0)
        {
            ddlCategory6.DataSource = FillCategoryLevel4;
            ddlCategory6.DataTextField = "CategoryCodeRef";
            ddlCategory6.DataValueField = "Categoryref";
            ddlCategory6.DataBind();
            ddlCategory6.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));
        }
        else
        {
            ddlCategory6.DataSource = null;
            ddlCategory6.DataBind();

            ddlCategory6.ClearSelection();
            ddlCategory6.Enabled = false;

        }
    }
    protected void ddlRequestType_SelectedIndexChanged(object sender, EventArgs e)
    {

        pnlIncident.Visible = true;
        FillStage();
        FillSeverity();
        FillPriority();
        //FillStatus();
        ShowCustomFields(ddlRequestType.SelectedItem.Text, Request.QueryString["NamelyId"].ToString());
        //FillLocations();	

    }
    private void FillStage()
    {

        try
        {

            DataTable SD_Status = new SDTemplateFileds().FillStage(Session["SDRef"].ToString(), Request.QueryString["NamelyId"].ToString());

            ddlStage.DataSource = SD_Status;
            ddlStage.DataTextField = "StageCodeRef";
            ddlStage.DataValueField = "id";
            ddlStage.DataBind();
            ddlStage.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));


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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }
        }
    }
    protected void ShowCustomFields(string RequestType, string OrgId)
    {
        try
        {
            DataTable SD_SDCustomFields = new FillSDFields().FillSDODDNumberCustomFieldsForTech(RequestType, Session["SDRole"].ToString(), OrgId);
            DataTable SD_SDDDLCustomFields = new FillSDFields().FillSDODDNumberDropDownCustomFieldsForTech(RequestType, Session["SDRole"].ToString(), OrgId);

            if (SD_SDCustomFields.Rows.Count > 0)
            {
                oddNumberCstmFlds = SD_SDCustomFields;
                rptOddControl.DataSource = SD_SDCustomFields;
                rptOddControl.DataBind();
            }


            if (SD_SDDDLCustomFields.Rows.Count > 0)
            {
                oddNumberDdlCstmFlds = SD_SDDDLCustomFields;
                rptddlOddControl.DataSource = SD_SDDDLCustomFields;
                rptddlOddControl.DataBind();
            }
            DataTable SD_SDEvenCustomFields = new FillSDFields().FillSDEvenNumberCustomFieldsForTech(RequestType, Session["SDRole"].ToString(), OrgId);

            EvenNumberCstmFlds = SD_SDEvenCustomFields;
            rptEvenControl.DataSource = SD_SDEvenCustomFields;
            rptEvenControl.DataBind();

            DataTable SD_SDddlEvenCustomFields = new FillSDFields().FillSDEvenNumberDropDownCustomFieldsForTech(RequestType, Session["SDRole"].ToString(), OrgId);
            EvenNumberDdlCstmFlds = SD_SDddlEvenCustomFields;
            rptddlEvenControl.DataSource = SD_SDddlEvenCustomFields;
            rptddlEvenControl.DataBind();
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }

    protected void rptEvenControl_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {

            //	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //	{
            if (EvenNumberCstmFlds != null)
            {
                //foreach (RepeaterItem item in rptOddControl.Items)
                //{
                DataRowView drv = e.Item.DataItem as DataRowView;
                string ID = drv["FieldMode"].ToString();
                TextBox txtodd = e.Item.FindControl("txteven") as TextBox;
                Label lbl = e.Item.FindControl("lbleven") as Label;
                //	txtodd.TextMode = TextBoxMode.ID;
                switch (ID)
                {

                    case "DateTime":
                        txtodd.EnableViewState = false;
                        txtodd.CssClass = "form-control form-control-sm";
                        //txtodd.Attributes.Add("type", "DateTime");
                        txtodd.Attributes.Add("type", "datetime-local");
                        break;
                    case "SingleLine":
                        txtodd.EnableViewState = false;
                        txtodd.CssClass = "form-control form-control-sm";
                        txtodd.TextMode = TextBoxMode.SingleLine;

                        break;
                }

                DataTable dt = new SDTemplateFileds().FillCustomFieldValueDropdown(lbl.Text, Request.QueryString["TicketId"].ToString(), Request.QueryString["NamelyId"].ToString());
                if (dt.Rows.Count > 0)
                    txtodd.Text = dt.Rows[0]["fieldvalue"].ToString();
            }
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }

    }
    DataTable oddNumberCstmFlds;
    DataTable EvenNumberCstmFlds;
    DataTable oddNumberDdlCstmFlds;
    DataTable EvenNumberDdlCstmFlds;
    protected void rptOddControl_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        try
        {
            //	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //	{
            if (oddNumberCstmFlds != null)
            {
                //foreach (RepeaterItem item in rptOddControl.Items)
                //{
                DataRowView drv = e.Item.DataItem as DataRowView;
                string ID = drv["FieldMode"].ToString();
                TextBox txtodd = e.Item.FindControl("txt") as TextBox;
                Label lbl = e.Item.FindControl("lbl") as Label;
                //	txtodd.TextMode = TextBoxMode.ID;
                switch (ID)
                {

                    case "DateTime":
                        txtodd.EnableViewState = false;
                        txtodd.CssClass = "form-control form-control-sm";
                        //txtodd.Attributes.Add("type", "DateTime");
                        txtodd.Attributes.Add("type", "datetime-local");
                        break;
                    case "SingleLine":
                        txtodd.EnableViewState = false;
                        txtodd.CssClass = "form-control form-control-sm";
                        txtodd.TextMode = TextBoxMode.SingleLine;
                        break;

                }
                DataTable dt = new SDTemplateFileds().FillCustomFieldValueDropdown(lbl.Text, Request.QueryString["TicketId"].ToString(), Request.QueryString["NamelyId"].ToString());
                if (dt.Rows.Count > 0)
                    txtodd.Text = dt.Rows[0]["fieldvalue"].ToString();

            }
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }

    protected void rptddlOddControl_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (oddNumberDdlCstmFlds != null)
            {
                //foreach (RepeaterItem item in rptOddControl.Items)
                //{
                DataRowView drv = e.Item.DataItem as DataRowView;

                Label lbl = e.Item.FindControl("lblOddlist") as Label;
                DropDownList selectList = e.Item.FindControl("ddlOdd") as DropDownList;
                selectList.ClearSelection();
                if (selectList != null)
                {
                    DataTable dt = new SDTemplateFileds().FillCustomFieldDropdown(lbl.Text);
                    selectList.DataSource = dt; //your datasource
                    selectList.DataTextField = lbl.Text;
                    selectList.DataValueField = lbl.Text;
                    selectList.DataBind();
                    selectList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));

                    //selectList.DataTextField = "SomeColumn";
                    //selectList.DataValueField = "SomeID";
                }
                DataTable dt1 = new SDTemplateFileds().FillCustomFieldValueDropdown(lbl.Text, Request.QueryString["TicketId"].ToString(), Request.QueryString["NamelyId"].ToString());
                if (dt1.Rows.Count > 0)
                {



                    if (selectList.Items.FindByValue(dt1.Rows[0]["fieldvalue"].ToString()) != null)
                    {
                        selectList.Items.FindByValue(dt1.Rows[0]["fieldvalue"].ToString()).Selected = true;
                        //	Response.Redirect(Request.Url.AbsoluteUri);
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
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }

    protected void rptddlEvenControl_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            //foreach (RepeaterItem item in rptddlEvenControl.Items)
            //{
            if (EvenNumberDdlCstmFlds != null)
            {

                DataRowView drv = e.Item.DataItem as DataRowView;

                Label lbleven = e.Item.FindControl("lblEvenlist") as Label;
                DropDownList selectListEven = e.Item.FindControl("ddlEven") as DropDownList;
                selectListEven.ClearSelection();
                if (selectListEven != null)
                {
                    DataTable dt = new SDTemplateFileds().FillCustomFieldDropdown(lbleven.Text);
                    selectListEven.DataSource = dt; //your datasource
                    selectListEven.DataTextField = lbleven.Text;
                    selectListEven.DataValueField = lbleven.Text;
                    selectListEven.DataBind();
                    selectListEven.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));
                }
                DataTable dtEven = new SDTemplateFileds().FillCustomFieldValueDropdown(lbleven.Text, Request.QueryString["TicketId"].ToString(), Request.QueryString["NamelyId"].ToString());
                if (dtEven.Rows.Count > 0)
                {



                    if (selectListEven.Items.FindByValue(dtEven.Rows[0]["fieldvalue"].ToString()) != null)
                    {
                        selectListEven.Items.FindByValue(dtEven.Rows[0]["fieldvalue"].ToString()).Selected = true;

                    }

                }
            }
            //}
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    private void FillSeverity()
    {
        try
        {

            DataTable SD_Severity = new SDTemplateFileds().FillSeverity(ddlRequestType.SelectedValue, Request.QueryString["NamelyId"].ToString()); ;

            ddlSeverity.DataSource = SD_Severity;
            ddlSeverity.DataTextField = "Serveritycoderef";
            ddlSeverity.DataValueField = "id";
            ddlSeverity.DataBind();
            ddlSeverity.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    private void FillPriority()
    {

        try
        {

            DataTable SD_Priority = new SDTemplateFileds().FillPriority(ddlRequestType.SelectedValue, Request.QueryString["NamelyId"].ToString()); ;

            ddlPriority.DataSource = SD_Priority;
            ddlPriority.DataTextField = "PriorityCodeRef";
            ddlPriority.DataValueField = "id";
            ddlPriority.DataBind();
            ddlPriority.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    private void FillStatus()
    {

        try
        {

            DataTable SD_Priority = new SDTemplateFileds().FillStatus(ddlRequestType.SelectedValue, ddlStage.SelectedValue, Request.QueryString["NamelyId"].ToString()); ;

            ddlStatus.DataSource = SD_Priority;
            ddlStatus.DataTextField = "StatusCodeRef";
            ddlStatus.DataValueField = "id";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }

    private void FillAssignee()
    {
        try
        {
            DataTable FillAssigne = new SDTemplateFileds().FillAssigne(Convert.ToInt64(Request.QueryString["NamelyId"].ToString()));

            ddlAssigne.DataSource = FillAssigne;
            ddlAssigne.DataTextField = "TechLoginName";
            ddlAssigne.DataValueField = "TechID";
            ddlAssigne.DataBind();
            ddlAssigne.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    private void FillAssigneeForChange()
    {
        try
        {
            DataTable FillAssigne = new SDTemplateFileds().FillAssigne(Convert.ToInt64(Request.QueryString["NamelyId"].ToString()));

            lstTechAssoc.DataSource = FillAssigne;
            lstTechAssoc.DataTextField = "TechLoginName";
            lstTechAssoc.DataValueField = "TechID";
            lstTechAssoc.DataBind();
            lstTechAssoc.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));

        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }

    Random r = new Random();
    private void FillResolutionDetails()
    {

        try
        {

            DataTable SD_Resolution = new FillSDFields().FillResolutionCustomer(Request.QueryString["NamelyId"].ToString()); ;

            if (SD_Resolution.Rows.Count > 0)
            {
                //  this.lb.Text = dataTable.Rows.Count.ToString();
                this.ddlResoultion.DataSource = (object)SD_Resolution;

                ddlResoultion.DataTextField = "ResolutionCodeRef";
                ddlResoultion.DataValueField = "id";
                ddlResoultion.DataBind();
                ddlResoultion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select----", "0"));
            }
            else
            {
                this.ddlResoultion.DataSource = (object)null;
                this.ddlResoultion.DataBind();
            }


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void UpdateCustFields()
    {
        try
        {

            DataTable UpdateWIP = new SDCustomFields().CheckForPrevStatus(Request.QueryString["TicketId"].ToString(), Request.QueryString["NamelyId"].ToString());
            if (Request.QueryString["Desk"].ToString().ToLower().Contains("service") || Request.QueryString["Desk"].ToString().ToLower().Contains("service"))
            {

                foreach (RepeaterItem item in rptOddControl.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        TextBox C = (TextBox)item.FindControl("txt");
                        Label lbl = (Label)item.FindControl("lbl");
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                        {

                            using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                cmd.Parameters.AddWithValue("@FieldName", lbl.Text);
                                cmd.Parameters.AddWithValue("@FieldValue", C.Text);
                                cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                con.Open();
                                int res = cmd.ExecuteNonQuery();

                            }
                        }
                    }
                }
                foreach (RepeaterItem item in rptEvenControl.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        TextBox C = (TextBox)item.FindControl("txteven");
                        Label lbl = (Label)item.FindControl("lbleven");
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                        {

                            using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                cmd.Parameters.AddWithValue("@FieldName", lbl.Text);
                                cmd.Parameters.AddWithValue("@FieldValue", C.Text);



                                cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                con.Open();
                                int res = cmd.ExecuteNonQuery();

                            }
                        }
                    }
                }
                foreach (RepeaterItem item in rptddlOddControl.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        DropDownList C = (DropDownList)item.FindControl("ddlOdd");
                        Label lbl = (Label)item.FindControl("lblOddlist");
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                        {

                            using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                cmd.Parameters.AddWithValue("@FieldName", lbl.Text);
                                cmd.Parameters.AddWithValue("@FieldValue", C.SelectedValue);



                                cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                con.Open();
                                int res = cmd.ExecuteNonQuery();

                            }
                        }
                    }
                }
                foreach (RepeaterItem item in rptddlEvenControl.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        DropDownList C = (DropDownList)item.FindControl("ddlEven");
                        Label lbl = (Label)item.FindControl("lblEvenlist");
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                        {

                            using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                cmd.Parameters.AddWithValue("@FieldName", lbl.Text);
                                cmd.Parameters.AddWithValue("@FieldValue", C.SelectedValue);



                                cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                con.Open();
                                int res = cmd.ExecuteNonQuery();

                            }
                        }
                    }
                }
            }

            if (UpdateWIP.Rows.Count > 0)
            {

                foreach (DataRow row in UpdateWIP.Rows)
                {
                    string prevstatus = row["StatusCodeRef"].ToString();
                    //to get open End or WIP Start

                    foreach (RepeaterItem item in rptOddControl.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            Label lbl = (Label)item.FindControl("lbl");
                            if (prevstatus.ToLower().Contains("open") && ddlStage.SelectedItem.ToString().ToLower() != "open")
                            {
                                // also capture OPEN END 
                                if (lbl.Text.ToString().ToLower() == "openend")
                                {
                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbl.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));
                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }
                            }
                            if (prevstatus.ToLower().ToString() != "wip" && ddlStage.SelectedItem.ToString().ToLower() == "wip")
                            {
                                if (lbl.Text.ToString().ToLower() == "wipstart")
                                {


                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbl.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));



                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }
                            }
                            if (prevstatus.ToLower().Contains("wip") && ddlStage.SelectedItem.ToString().ToLower() != "wip")
                            {

                                if (lbl.Text.ToLower().Contains("wipend"))
                                {


                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbl.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));




                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }
                            }
                            if ((prevstatus.ToLower().ToString() != "hold") && ddlStage.SelectedItem.ToString().ToLower() == "hold")
                            {


                                if (lbl.Text.ToLower().Contains("holdstart"))
                                {


                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbl.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));
                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }
                            }
                            if ((prevstatus.ToLower().ToString() == "hold") && ddlStage.SelectedItem.ToString().ToLower() != "hold")
                            {

                                if (lbl.Text.ToLower().Contains("holdend"))
                                {


                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbl.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));




                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }
                            }
                        }

                    }
                    foreach (RepeaterItem item in rptEvenControl.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {

                            Label lbleven = (Label)item.FindControl("lbleven");
                            if (prevstatus.ToLower().Contains("open") && ddlStage.SelectedItem.ToString().ToLower() != "open")
                            {
                                if (lbleven.Text.ToString().ToLower() == "openend")
                                {
                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbleven.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));



                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }

                            }
                            if (prevstatus.ToLower().ToString() != "wip" && ddlStage.SelectedItem.ToString().ToLower() == "wip")
                            {
                                if (lbleven.Text.ToString().ToLower() == "wipstart")
                                {


                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbleven.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));



                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }
                            }
                            if (prevstatus.ToLower().Contains("wip") && ddlStage.SelectedItem.ToString().ToLower() != "wip")
                            {
                                if (lbleven.Text.ToLower().Contains("wipend"))
                                {


                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbleven.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));


                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }
                            }
                            if ((prevstatus.ToLower().ToString() != "hold") && ddlStage.SelectedItem.ToString().ToLower() == "hold")
                            {
                                if (lbleven.Text.ToLower().Contains("holdstart"))
                                {


                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbleven.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));


                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }
                            }
                            if ((prevstatus.ToLower().ToString() == "hold") && ddlStage.SelectedItem.ToString().ToLower() != "hold")
                            {

                                if (lbleven.Text.ToLower().Contains("holdend"))
                                {


                                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                                    {

                                        using (SqlCommand cmd = new SqlCommand("SD_spAddSDCustomTicketField", con))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.AddWithValue("@TicketNo", Request.QueryString["TicketId"].ToString());
                                            cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                                            cmd.Parameters.AddWithValue("@FieldName", lbleven.Text);
                                            cmd.Parameters.AddWithValue("@FieldValue", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"));


                                            cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
                                            con.Open();
                                            int res = cmd.ExecuteNonQuery();

                                        }
                                    }
                                }
                            }
                        }
                    }

                    ///// when first time ticket was in WIP and second time for update

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
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    public static string GetConnectstring()
    {
        return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    }
    public static object GetScalarValue(string sql, SqlConnection cnn)
    {
        SqlCommand cmd = new SqlCommand(sql, cnn);
        cmd.CommandTimeout = 3600;
        object obj = cmd.ExecuteScalar();
        return obj;
    }
    public static object GetScalarValue(string sql)
    {
        object o;
        using (SqlConnection cnn = new SqlConnection(GetConnectstring()))
        {
            cnn.Open();
            o = GetScalarValue(sql, cnn);
            cnn.Close();
        }
        return o;
    }
    protected void UpdateTicketDetails()
    {
        try
        {
            AddTicketNotes();
            UpdateCustFields();
            GetFileAttached();

            if (ddlCategory6.SelectedIndex < 0)
            {

            }
            else
            {
                Session["CategoryID"] = ddlCategory6.SelectedValue.ToString();
            }
            string sql2 = "select top 1 OrgName from SD_OrgMaster where Org_ID='" + Session["OrgID"].ToString() + "'";
            string OrgName = Convert.ToString(GetScalarValue(sql2));
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spSDIncident", con))
                {
                    cmd.CommandTimeout = 3600;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TicketNumber", Request.QueryString["TicketId"].ToString());
                    cmd.Parameters.AddWithValue("@sdPriorityFK", ddlPriority.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdSeverityFK", ddlSeverity.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdStageFK", ddlStage.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdStatusFK", ddlStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdCategoryRef", hdnCategoryID.Value);
                    cmd.Parameters.AddWithValue("@submitterEmailAddr", txtSubmitterEmail.Text);
                    cmd.Parameters.AddWithValue("@submitterPhone", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@TicketDesc", System.Web.HttpUtility.HtmlEncode(txtDescription.Value));
                    cmd.Parameters.AddWithValue("@assigneeType", "");
                    //	cmd.Parameters.AddWithValue("@assigneePoolFK","");
                    cmd.Parameters.AddWithValue("@assigneeParticipantFK", ddlAssigne.SelectedValue);
                    if (ddlStage.SelectedItem.Text == "Closed")
                    {
                        cmd.Parameters.AddWithValue("@closedDateTime", DateTime.Now);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@closedDateTime", null);
                    }
                    if (FileUploadTickDoc.HasFile == true)
                    {
                        string fileName = Path.GetFileName(FileUploadTickDoc.PostedFile.FileName);
                        FileUploadTickDoc.PostedFile.SaveAs(Server.MapPath("/TicketAttachment/") + fileName);
                        cmd.Parameters.AddWithValue("@Filename", FileUploadTickDoc.FileName);
                        cmd.Parameters.AddWithValue("@TicketAttachMent", "/TicketAttachment/" + FileUploadTickDoc.FileName);
                    }
                    cmd.Parameters.AddWithValue("@organizationFK", Request.QueryString["NamelyId"].ToString());
                    cmd.Parameters.AddWithValue("@UserName", Session["UserName"].ToString());
                    cmd.Parameters.AddWithValue("@sdSolutionTypeFK", ddlResoultion.SelectedValue);
                    cmd.Parameters.AddWithValue("@solutionNote", System.Web.HttpUtility.HtmlEncode(txtResolution.Value));
                    cmd.Parameters.AddWithValue("@TickNotes", System.Web.HttpUtility.HtmlDecode(txtNotes.Value));
                    cmd.Parameters.AddWithValue("@categoryFullText", hdnCategoryID.Value.ToString().Replace("||", " - "));
                    cmd.Parameters.AddWithValue("@location", ddlLocation.SelectedValue);
                    cmd.Parameters.AddWithValue("@Department", ddlDepartment.SelectedValue);
                    cmd.Parameters.AddWithValue("@Option", "UpdateTicket");
                    cmd.Parameters.AddWithValue("@OrgName", OrgName);
                    cmd.Parameters.Add("@Error", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    string ErrorChk = cmd.Parameters["@Error"].Value.ToString();
                    if (res > 0 && string.IsNullOrEmpty(ErrorChk))
                    {
                        if (Session["AssigneUpdate"].ToString() == "True")
                        {
                            ADDMailinDB(Request.QueryString["TicketID"].ToString());
                        }
                        Session["Popup"] = "Update";
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
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRequestType.SelectedValue.ToString() == "Incident")
            {
                CheckForPrevStage();
            }

            else if (ddlRequestType.SelectedValue.ToString() == "Service Request")
            {
                CheckForCondtions();
            }


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }

    static string AssigneEmail;
    protected void Sendmail(string body)
    {
        try
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            //Fetching Settings from WEB.CONFIG file.  
            string emailSender = ConfigurationManager.AppSettings["UserName"].ToString();
            string emailSenderPassword = ConfigurationManager.AppSettings["Password"].ToString();
            string emailSenderHost = ConfigurationManager.AppSettings["Host"].ToString();
            int emailSenderPort = Convert.ToInt16(ConfigurationManager.AppSettings["Port"]);
            Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            var server = new SmtpClient("localhost");

            server.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;

            //Fetching Email Body Text from EmailTemplate File.  
            string FilePath = Server.MapPath(@"/SDTemplates/UserTicketCreation.htm");
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            //Repalce [newusername] = signup user name   
            //MailText = MailText.Replace(body);


            string subject = "Incident Request--" + txtSubmitterName.Text.Trim() + "-" + ddlRequestType.SelectedItem.ToString() + "";

            //Base class for sending email  
            MailMessage _mailmsg = new MailMessage();

            //Make TRUE because our body text is html  
            _mailmsg.IsBodyHtml = true;

            //Set From Email ID  
            _mailmsg.From = new MailAddress(emailSender);

            //Set To Email ID  
            _mailmsg.To.Add(ToEmail.ToString());

            //Set Subject  
            _mailmsg.Subject = subject;

            //Set Body Text of Email   
            _mailmsg.Body = body;


            //Now set your SMTP   
            SmtpClient _smtp = new SmtpClient();

            //Set HOST server SMTP detail  
            _smtp.Host = emailSenderHost;

            //Set PORT number of SMTP  
            _smtp.Port = emailSenderPort;

            //Set SSL --> True / False  
            _smtp.EnableSsl = emailIsSSL;

            //Set Sender UserEmailID, Password  
            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;

            //Send Method will send your MailMessage create above.  
            _smtp.Send(_mailmsg);


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }

    }
    protected string GetAssigneEmail(long id)
    {
        try
        {
            DataTable UpdateWIP = new SDCustomFields().GetAssigneEmail(Convert.ToInt64(ddlAssigne.SelectedValue));
            if (UpdateWIP.Rows.Count > 0)
            {
                foreach (DataRow row in UpdateWIP.Rows)
                {
                    AssigneEmail = row["EmailID"].ToString();
                }
            }
            return AssigneEmail;
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
            return null;
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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

            return null;
        }
    }
    private void ADDMailinDB(string ticketNumber)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_Sendmail", con))
                {
                    cmd.Parameters.AddWithValue("@TicketNumber", ticketNumber);
                    cmd.Parameters.AddWithValue("@OrgId", Request.QueryString["NamelyId"].ToString());
                    cmd.Parameters.AddWithValue("@Option", "AssigneUpdate");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }
        }
    }
    public static string Filepath;
    private void GetFileAttached()
    {
        try
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spTicketFileupload", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticketref", Request.QueryString["TicketId"].ToString());
                    cmd.Parameters.AddWithValue("@OrgRef", Request.QueryString["NamelyId"].ToString());
                    cmd.Parameters.AddWithValue("@Option", "see");
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                lnkDownload.Visible = true;
                                lnkDownload.Text = dt.Rows[0]["Filename"].ToString();
                                Filepath = dt.Rows[0]["Filepath"].ToString();
                            }
                        }
                    }
                    con.Close();
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
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }

    protected void CheckForCondtions()
    {
        try
        {
            if (ddlStage.SelectedItem.ToString() == "Resolved" || ddlStage.SelectedItem.ToString() == "Closed")
            {
                if ((txtResolution.Value.ToString() == " " || txtResolution.Value.ToString() == null) || ddlResoultion.SelectedValue == "0")
                {
                    rfvddlResoultion.Enabled = true;
                    rfvddlResoultion.Visible = true;
                    //	rfvchkForSelfService.Enabled = true;
                    rfvtxtResolution.Enabled = true;
                    rfvtxtResolution.Visible = true;
                    rfvddlAssigne.Enabled = true;
                    //rfvddlAssigne.Visible = true;
                    //rfvddlResoultion.InitialValue = "0";
                    lblMsg.Text = "Please select resolution and enter resolution description";
                }
                else
                {

                    if (ddlAssigne.SelectedValue == "0")
                    {
                        rfvddlAssigne.Visible = true;
                        rfvddlResoultion.InitialValue = "0";
                        lblMsg.Text = "Please assign Technician First!!";
                    }
                    else
                    {
                        UpdateTicketDetails();
                    }

                }
            }
            else
            {
                UpdateTicketDetails();
            }
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    private void CheckForPrevStage()
    {
        try
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spCheckTicketStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticketref", Request.QueryString["TicketId"].ToString());
                    cmd.Parameters.AddWithValue("@organizationFK", Request.QueryString["NamelyId"].ToString());
                    cmd.Parameters.AddWithValue("@sdStageFK", ddlStage.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdStatusFK", ddlStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@Option", "Checkstatus");
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 100);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (cmd.Parameters["@ERROR"].Value.ToString().Contains("change"))
                    {
                        if (ddlStage.SelectedItem.ToString() == "Resolved" || ddlStage.SelectedItem.ToString() == "Closed")
                        {
                            if ((txtResolution.Value.ToString() == " " || txtResolution.Value.ToString() == null) || ddlResoultion.SelectedValue == "0" || string.IsNullOrEmpty(txtResolution.Value.ToString()))
                            {
                                rfvddlResoultion.Enabled = true;
                                rfvddlResoultion.Visible = true;
                                rfvtxtResolution.Enabled = true;
                                rfvtxtResolution.Visible = true;
                                rfvddlResoultion.InitialValue = "0";
                                lblMsg.Text = "Please select resolution and enter resolution description";
                            }
                            else
                            {
                                UpdateTicketDetails();
                            }
                        }
                        else
                        {
                            rfvddlResoultion.Enabled = false;
                            rfvddlResoultion.Visible = false;
                            rfvtxtResolution.Enabled = false;
                            rfvtxtResolution.Visible = false;
                            UpdateTicketDetails();
                        }
                    }
                    else
                    {
                        lblMsg.Text = (string)cmd.Parameters["@ERROR"].Value;
                    }
                    con.Close();
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
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    protected void AddTicketNotes()
    {
        try
        {
            DataTable SD_Resolution = new FillSDFields().FillTicketNotes(Request.QueryString["TicketId"].ToString(), Request.QueryString["NamelyId"].ToString()); ;
            if (SD_Resolution.Rows.Count > 0)
            {
                //  this.lb.Text = dataTable.Rows.Count.ToString();
                this.gvTicketNotes.DataSource = (object)SD_Resolution;
                this.gvTicketNotes.DataBind();
            }
            else
            {
                this.gvTicketNotes.DataSource = (object)null;
                this.gvTicketNotes.DataBind();
            }


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }

    }
    protected void UpdateTicketPanel()
    {
        try
        {
            pnlTicket.Visible = true;

            pnlUpdateTicket.Visible = true;
            btnUpdateTickView.CssClass = "btn btn-sm  btn-secondary ";
            pnlViewNotes.Visible = false;
            btnViewNotes.CssClass = "btn btn-sm   btn-outline-secondary ";


        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    protected void btnUpdateTickView_Click(object sender, EventArgs e)
    {
        Response.AppendHeader("Refresh", "1;url=frmEditTicketbyAssigne.aspx?TicketId=" + Request.QueryString["TicketId"] + "&redirected=false&Desk=" + Request.QueryString["Desk"] + "&NamelyId=" + Request.QueryString["NamelyId"] + "");
        UpdateTicketPanel();
    }
    protected void btnViewNotes_Click(object sender, EventArgs e)
    {
        try
        {
            pnlUpdateTicket.Visible = false;

            pnlViewNotes.Visible = true;
            btnViewNotes.CssClass = "btn btn-sm   btn-secondary ";
            btnUpdateTickView.Enabled = true;

            pnlTicket.Visible = false;
            pnlShowRollOutDetails.Visible = false;
            //pnlAddRollout.Visible = false;
            //	pnlRollOutGrid.Visible = false;
            pnlIncident.Visible = false;
            pnlShowImpactDetails.Visible = false;
            //pnlImpactGrid.Visible = false;
            //pnlAddImpact.Visible = false;
            pnlDownTime.Visible = false;
            pnlTaksAssociation.Visible = false;
            AddTicketNotes();

            btnUpdateTickView.CssClass = "btn btn-sm btnDisabled btn-outline-secondary ";
            btnImpactDetails.CssClass = "btn btn-sm btnDisabled btn-outline-secondary ";
            btnRolloutPlan.CssClass = "btn btn-sm btnDisabled btn-outline-secondary ";
            btnDowntime.CssClass = "btn btn-sm btnDisabled btn-outline-secondary ";
            btnTaskAssociation.CssClass = "btn btn-sm btnDisabled btn-outline-secondary ";

        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";

            }

        }
    }
    protected void ImgBtnExport_Click(object sender, EventArgs e)
    {

    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {

        try
        {
            if (Filepath != "")
            {
                string path = Server.MapPath(Filepath);
                //System.IO.FileInfo file = new System.IO.FileInfo(path);
                //if (file.Exists)
                //{
                //	Response.Clear();
                //	Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                //	Response.AddHeader("Content-Length", file.Length.ToString());
                //	Response.ContentType = "application/octet-stream";
                //	Response.WriteFile(file.FullName);
                //	Response.End();
                //}
                //else
                //{
                //	Response.Write("This file does not exist.");
                //}
                string filePath = Filepath;
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.End();
            }
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            var st = new StackTrace(ex, true);
            // Get the top stack frame
            var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();
            inEr.InsertErrorLogsF(Session["UserName"].ToString()
, " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
            lblErrorMsg.Text = "Something Went Wrong Please try again.";

        }
    }
    public static int AssigneClick;
    public static string ToEmail;
    protected void ddlAssigne_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["AssigneUpdate"] = "True";
            ToEmail = GetAssigneEmail(Convert.ToInt64(ddlAssigne.SelectedValue));
            ShowCustomFields(ddlRequestType.SelectedItem.Text, Request.QueryString["NamelyId"].ToString());
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("ThreadAbortException"))
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
                lblErrorMsg.Text = "Something Went Wrong Please try again.";
            }

        }
    }

    protected void ddlStage_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowCustomFields(ddlRequestType.SelectedItem.Text, Request.QueryString["NamelyId"].ToString());
        FillStatus();
    }

    /// <summary>
    /// ////////  this section is all about change management
    /// </summary>


    //////////////////////////////////////////////     This will add default impact details  ////////////////////////////////////////////////////////
    private void AddDefaultFirstRecordForImpact()
    {
        //creating dataTable 
        DataTable dt = new DataTable();
        DataRow dr;
        dt.TableName = "Impact";
        dt.Columns.Add(new DataColumn("ImpactDetails", typeof(string)));

        dr = dt.NewRow();
        dt.Rows.Add(dr);
        //saving databale into viewstate 
        ViewState["Impact"] = dt;
        //bind Gridview
        gridAddImpact.DataSource = dt;
        gridAddImpact.DataBind();
    }
    private void AddNewRecordRowToGridForImpact()
    {
        // check view state is not null
        if (ViewState["Impact"] != null)
        {
            //get datatable from view state 
            DataTable dtCurrentTable = (DataTable)ViewState["Impact"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {

                    //add each row into data table
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ImpactDetails"] = txtImpactDesc.Text;



                }
                //Remove initial blank row
                if (dtCurrentTable.Rows[0][0].ToString() == "")
                {
                    dtCurrentTable.Rows[0].Delete();
                    dtCurrentTable.AcceptChanges();

                }

                //add created Rows into dataTable
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Save Data table into view state after creating each row
                ViewState["Impact"] = dtCurrentTable;
                //Bind Gridview with latest Row
                gridAddImpact.DataSource = dtCurrentTable;
                gridAddImpact.DataBind();
            }
        }
        txtImpactDesc.Text = string.Empty;


        txtImpactDesc.Focus();

    }
    private void AddDefaultFirstRecordForTask()
    {
        //creating dataTable 
        DataTable dt = new DataTable();
        DataRow dr;
        dt.TableName = "Task";
        dt.Columns.Add(new DataColumn("TaskDescription", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));
        dt.Columns.Add(new DataColumn("EngineerAssociation", typeof(string)));
        dr = dt.NewRow();
        dt.Rows.Add(dr);
        //saving databale into viewstate 
        ViewState["Task"] = dt;
        //bind Gridview
        gvAddTask.DataSource = dt;
        gvAddTask.DataBind();
    }
    protected void btnUpdateTickView1_Click(object sender, EventArgs e)
    {
        pnlIncident.Visible = true;
        pnlShowImpactDetails.Visible = false;
        pnlDownTime.Visible = false;
        pnlShowRollOutDetails.Visible = false;
        pnlTaksAssociation.Visible = false;

        btnUpdateTickView.CssClass = "btn btn-sm  btn-secondary ";
        btnImpactDetails.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnRolloutPlan.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnDowntime.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnTaskAssociation.CssClass = "btn btn-sm  btn-outline-secondary ";
    }

    protected void btnImpactDetails_Click(object sender, EventArgs e)
    {
        pnlTicket.Visible = true;
        pnlUpdateTicket.Visible = false;
        pnlShowImpactDetails.Visible = true;
        //pnlAddImpact.Visible = false;
        //pnlImpactGrid.Visible = true;
        pnlIncident.Visible = false;

        pnlDownTime.Visible = false;
        pnlShowRollOutDetails.Visible = false;
        pnlTaksAssociation.Visible = false;
        pnlViewNotes.Visible = false;

        btnUpdateTickView.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnImpactDetails.CssClass = "btn btn-sm  btn-secondary ";
        btnRolloutPlan.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnDowntime.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnTaskAssociation.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnViewNotes.CssClass = "btn btn-sm  btn-outline-secondary ";
    }

    protected void btnRolloutPlan_Click(object sender, EventArgs e)
    {
        pnlTicket.Visible = true;
        pnlUpdateTicket.Visible = false;
        pnlShowRollOutDetails.Visible = true;
        //	pnlAddRollout.Visible = false;
        //	pnlRollOutGrid.Visible = true;
        pnlIncident.Visible = false;
        pnlShowImpactDetails.Visible = false;
        pnlDownTime.Visible = false;
        pnlTaksAssociation.Visible = false;
        pnlViewNotes.Visible = false;

        btnUpdateTickView.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnImpactDetails.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnRolloutPlan.CssClass = "btn btn-sm  btn-secondary ";
        btnDowntime.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnTaskAssociation.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnViewNotes.CssClass = "btn btn-sm  btn-outline-secondary ";

    }

    protected void btnAddImpactDetails_Click(object sender, EventArgs e)
    {
        AddNewRecordRowToGridForImpact();
    }


    protected void btnAddRollOutGrid_Click(object sender, EventArgs e)
    {
        AddNewRecordRowToGridForRollOut();
    }
    private void AddDefaultFirstRecordForRollOut()
    {
        //creating dataTable 
        DataTable dt = new DataTable();
        DataRow dr;
        dt.TableName = "RollOut";
        dt.Columns.Add(new DataColumn("RollOutDetails", typeof(string)));

        dr = dt.NewRow();
        dt.Rows.Add(dr);
        //saving databale into viewstate 
        ViewState["RollOut"] = dt;
        //bind Gridview
        gridAddRollOut.DataSource = dt;
        gridAddRollOut.DataBind();
    }
    private void AddNewRecordRowToGridForRollOut()
    {
        // check view state is not null
        if (ViewState["RollOut"] != null)
        {
            //get datatable from view state 
            DataTable dtCurrentTable = (DataTable)ViewState["RollOut"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {

                    //add each row into data table
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RollOutDetails"] = txtRollOut.Text;



                }
                //Remove initial blank row
                if (dtCurrentTable.Rows[0][0].ToString() == "")
                {
                    dtCurrentTable.Rows[0].Delete();
                    dtCurrentTable.AcceptChanges();

                }

                //add created Rows into dataTable
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Save Data table into view state after creating each row
                ViewState["RollOut"] = dtCurrentTable;
                //Bind Gridview with latest Row
                gridAddRollOut.DataSource = dtCurrentTable;
                gridAddRollOut.DataBind();
            }
        }
        txtRollOut.Text = string.Empty;


        txtRollOut.Focus();

    }
    private void AddNewRecordRowToGridForTask()
    {
        // check view state is not null
        if (ViewState["Task"] != null)
        {
            //get datatable from view state 
            DataTable dtCurrentTable = (DataTable)ViewState["Task"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    string message = "";
                    foreach (ListItem item in lstTechAssoc.Items)
                    {
                        if (item.Selected)
                        {
                            message += item.Text + ",";
                        }
                    }
                    message = message.TrimEnd(',');
                    //add each row into data table
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["TaskDescription"] = txtTaskSummary.Text;
                    drCurrentRow["Status"] = ddlTaskStatus.SelectedValue;
                    drCurrentRow["EngineerAssociation"] = message;

                }
                //Remove initial blank row
                if (dtCurrentTable.Rows[0][0].ToString() == "")
                {
                    dtCurrentTable.Rows[0].Delete();
                    dtCurrentTable.AcceptChanges();

                }

                //add created Rows into dataTable
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Save Data table into view state after creating each row
                ViewState["Task"] = dtCurrentTable;
                //Bind Gridview with latest Row
                gvAddTask.DataSource = dtCurrentTable;
                gvAddTask.DataBind();
            }
        }
        txtTaskSummary.Text = string.Empty;
        txtTaskSummary.Focus();
        ddlTaskStatus.ClearSelection();
        ddlTaskStatus.Focus();
        lstTechAssoc.ClearSelection();
        lstTechAssoc.Focus();

    }
    protected void btnDowntime_Click(object sender, EventArgs e)
    {
        pnlIncident.Visible = false;
        pnlShowImpactDetails.Visible = false;

        pnlShowRollOutDetails.Visible = false;
        pnlTaksAssociation.Visible = false;
        pnlDownTime.Visible = true;
        pnlViewNotes.Visible = false;

        pnlTicket.Visible = true;
        pnlUpdateTicket.Visible = false;
        btnUpdateTickView.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnImpactDetails.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnRolloutPlan.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnDowntime.CssClass = "btn btn-sm  btn-secondary ";
        btnTaskAssociation.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnViewNotes.CssClass = "btn btn-sm  btn-outline-secondary ";


    }
    protected void btnTaskAssociationShowPanel_Click(object sender, EventArgs e)
    {
        pnlTicket.Visible = true;
        pnlUpdateTicket.Visible = false;
        pnlShowRollOutDetails.Visible = false;
        //pnlAddRollout.Visible = false;
        //	pnlRollOutGrid.Visible = false;
        pnlIncident.Visible = false;
        pnlShowImpactDetails.Visible = false;
        //pnlImpactGrid.Visible = false;
        //pnlAddImpact.Visible = false;
        pnlDownTime.Visible = false;
        pnlTaksAssociation.Visible = true;

        pnlViewNotes.Visible = false;

        btnUpdateTickView.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnImpactDetails.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnRolloutPlan.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnDowntime.CssClass = "btn btn-sm  btn-outline-secondary ";
        btnTaskAssociation.CssClass = "btn btn-sm  btn-secondary ";
        btnViewNotes.CssClass = "btn btn-sm  btn-outline-secondary ";

    }
    protected void btnAddTaskAssociationData_Click(object sender, EventArgs e)
    {
        AddNewRecordRowToGridForTask();
    }

    protected void btnViwpYres_Click(object sender, EventArgs e)
    {
        string output = RunPython();
        txtPyoutput.Text = output;

    }
    protected string RunPython()
    {
        string output = "";
        try
        {
            Process cmdProcess = new Process();
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.Start();

            using (StreamWriter sw = cmdProcess.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    // Execute your specific CMD commands here
                    sw.WriteLine("cd /d C:\\YourScriptDirectory");
                    sw.WriteLine("echo Running CMD commands");

                    // Activate virtual environment
                    sw.WriteLine("C:\\Users\\M6734\\Documents\\Abhishek_GenAI\\venv");

                    // Run Python script with ticket number
                    sw.WriteLine("python Summarization_GENAI.py '" + Convert.ToString(Request.QueryString["TicketId"]) + "'");

                    sw.WriteLine("exit");
                }
            }
            output = cmdProcess.StandardOutput.ReadToEnd();
            string error = cmdProcess.StandardError.ReadToEnd();
            cmdProcess.WaitForExit();
            if (!string.IsNullOrEmpty(error))
            {
                //	MessageBox.Show("Error occurred:\n\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //	MessageBox.Show("Commands and script executed successfully. Output:\n\n{output}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show("An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return output;
    }
}
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class DeskConfiguration : System.Web.UI.Page
{
    InsertErrorLogs inEr = new InsertErrorLogs();
    Random r = new Random();
    public static Int64 ID;
    protected override void OnPreInit(EventArgs e)
    {
        if (Session["UserName"] == null || Session["UserScope"]==null)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserScope"] != null)
            {
                if (!IsPostBack)
                {
                    #region Add Orgainisation 
                    FillOrgDetails();
                    pnlShowOrg.Visible = true;
                    btnOrg(null, null);
                    CurrentStep = 1;
                    DataBind();
                    #endregion Add Orgainisation 
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
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
            var frame = st.GetFrame(0);
            var line = frame.GetFileLineNumber();
            inEr.InsertErrorLogsF(Session["UserName"].ToString()
        , " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
            Response.Redirect("~/Error/Error.html");
        }

    }
    #region Common Start
    public void cleardata()
    {
        txtOrgName.Text = "";
        txtOrgDesc.Text = "";
        txtCntnctPrnsName.Text = "";
        txtCntctPrnsMob.Text = "";
        txtCntctPrsnEmail.Text = "";
        txtCntctPrsnNameII.Text = "";
        txtCntctPrsnMobII.Text = "";
        txtCntctPrnsEmailII.Text = "";
        ddlOrg.ClearSelection();
        ddlOrg2.ClearSelection();
        ddlOrg3.ClearSelection();
        txtRequestType.Text = "";
        txtReqDescription.Text = "";
        ddlRequestType.ClearSelection();
        txtStageName.Text = "";
        txtStageDesc.Text = "";
        ddlRequestTypeStatus.ClearSelection();
        ddlStage.ClearSelection();
        txtStatusName.Text = "";
        txtStatusDesc.Text = "";
        txtColorForStatus.Text = "";
    }
    protected int CurrentStep
    {
        get
        {
            if (ViewState["CurrentStep"] == null)
            {
                ViewState["CurrentStep"] = 1;  // Default to step 1
            }
            return (int)ViewState["CurrentStep"];
        }
        set
        {
            ViewState["CurrentStep"] = value;
        }
    }
    protected void StepButton_Click1(object sender, EventArgs e)
    {
        CurrentStep = 1;
        DataBind();
    }
    protected void StepButton_Click2(object sender, EventArgs e)
    {
        CurrentStep = 2;
        DataBind();
    }
    protected void StepButton_Click3(object sender, EventArgs e)
    {
        CurrentStep = 3;
        // Your logic here
        DataBind();
    }
    protected void StepButton_Click4(object sender, EventArgs e)
    {
        CurrentStep = 4;
        // Your logic here
        DataBind();
    }
    protected void StepButton_Click5(object sender, EventArgs e)
    {
        CurrentStep = 5;
        // Your logic here
        DataBind();
    }
    protected void StepButton_Click6(object sender, EventArgs e)
    {
        CurrentStep = 6;
        // Your logic here
        DataBind();
    }
    #endregion Common End

    #region Start Add Orgainsation
    private void FillOrgDetails()
    {
        try
        {
            DataTable SD_Org = new FillSDFields().FillOrganization();
            if (SD_Org.Rows.Count > 0)
            {
                this.gvOrg.DataSource = (object)SD_Org;
                this.gvOrg.DataBind();
            }
            else
            {
                this.gvOrg.DataSource = (object)null;
                this.gvOrg.DataBind();
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
    protected void ImgBtnExport_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvOrg.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvOrg.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Priority.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
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
    public static long OrgID;
    protected void gvOrg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEx")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                long OrgID = Convert.ToInt64(gvOrg.DataKeys[rowIndex].Values["Org_ID"].ToString());
                string Deskref = gvOrg.Rows[rowIndex].Cells[1].Text;
                string PriorityName = gvOrg.Rows[rowIndex].Cells[2].Text;
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spAddOrganization", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Org_ID", OrgID);

                            cmd.Parameters.AddWithValue("@Option", "DeleteOrg");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                pnlShowRqstType.Visible = false;
                                lblsuccess.ForeColor = System.Drawing.Color.Green;
                                lblsuccess.Text = PriorityName + " Deleted successfully";
                                Session["Popup"] = "Delete";
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully !")}');", true);
                            }

                            con.Close();
                            FillOrgDetails();

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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
   $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
                    }
                }

            }
            if (e.CommandName == "SelectState")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                OrgID = Convert.ToInt64(gvOrg.DataKeys[rowIndex].Values["Org_ID"].ToString());
                txtOrgName.Text = gvOrg.Rows[rowIndex].Cells[1].Text;
                txtOrgDesc.Text = gvOrg.Rows[rowIndex].Cells[2].Text;
                txtCntnctPrnsName.Text = gvOrg.Rows[rowIndex].Cells[3].Text;
                txtCntctPrnsMob.Text = gvOrg.Rows[rowIndex].Cells[4].Text;
                txtCntctPrsnEmail.Text = gvOrg.Rows[rowIndex].Cells[5].Text;
                txtCntctPrsnNameII.Text = gvOrg.Rows[rowIndex].Cells[6].Text;
                txtCntctPrsnMobII.Text = gvOrg.Rows[rowIndex].Cells[7].Text;
                txtCntctPrnsEmailII.Text = gvOrg.Rows[rowIndex].Cells[8].Text;
                btnInsertOrg.Visible = false;
                btnUpdateOrg.Visible = true;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
   $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
            }
        }
    }
    protected void SaveData()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddOrganization", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrgName", txtOrgName.Text.Trim());
                    cmd.Parameters.AddWithValue("@OrgDesc", txtOrgDesc.Text.Trim());
                    cmd.Parameters.AddWithValue("@Org_ID", r.Next());
                    cmd.Parameters.AddWithValue("@CntctPrsnName", txtCntnctPrnsName.Text.Trim());
                    cmd.Parameters.AddWithValue("@CntctPrsnMob", txtCntctPrnsMob.Text.Trim());
                    cmd.Parameters.AddWithValue("@CntctPrsnEmail", txtCntctPrsnEmail.Text);
                    cmd.Parameters.AddWithValue("@CntctPrsnNameII", txtCntctPrsnNameII.Text);
                    cmd.Parameters.AddWithValue("@CntctPrsnMobII", txtCntctPrsnMobII.Text);
                    cmd.Parameters.AddWithValue("@CntctPrsnEmailII", txtCntctPrnsEmailII.Text);
                    cmd.Parameters.AddWithValue("@Option", "AddOrg");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved SuccessFully !")}');", true);
                        FillOrgDetails();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
   $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
            }
        }
    }
    protected void btnInsertPriority_Click(object sender, EventArgs e)
    {
        SaveData();
    }
    protected void gvOrg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (Session["UserScope"].ToString() == "Master")
            {
                e.Row.Cells[4].Visible = true;
                e.Row.Cells[5].Visible = true;
            }

            if (Session["UserScope"].ToString() == "Technician")
            {
                e.Row.Cells[4].Visible = true;
                e.Row.Cells[5].Visible = false;

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
            Response.Redirect("~/Error/Error.html");
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void btnOrg(object sender, EventArgs e)
    {
        pnlShowOrg.Visible = true;
    }
    protected void btnInsertOrg_Click(object sender, EventArgs e)
    {
        SaveData();
    }
    protected void btnUpdateOrg_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spAddOrganization", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrgName", txtOrgName.Text.Trim());
                    cmd.Parameters.AddWithValue("@OrgDesc", txtOrgDesc.Text.Trim());
                    cmd.Parameters.AddWithValue("@Org_ID", OrgID);
                    cmd.Parameters.AddWithValue("@CntctPrsnName", txtCntnctPrnsName.Text.Trim());
                    cmd.Parameters.AddWithValue("@CntctPrsnMob", txtCntctPrnsMob.Text.Trim());
                    cmd.Parameters.AddWithValue("@CntctPrsnEmail", txtCntctPrsnEmail.Text);
                    cmd.Parameters.AddWithValue("@CntctPrsnNameII", txtCntctPrsnNameII.Text);
                    cmd.Parameters.AddWithValue("@CntctPrsnMobII", txtCntctPrsnMobII.Text);
                    cmd.Parameters.AddWithValue("@CntctPrsnEmailII", txtCntctPrnsEmailII.Text);
                    cmd.Parameters.AddWithValue("@Option", "UpdateOrg");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Update";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully !")}');", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
   $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void lnkNextAddReq_Click(object sender, EventArgs e)
    {
        pnlReqType.Visible = true;
        pnlShowOrg.Visible = false;
        FillRequestTypeDetails();
        FillOrganization1();
        CurrentStep = 2;
        DataBind();
        cleardata();
        //ScriptManager.RegisterStartupScript(this, GetType(), "stepNext", "stepper1.next();", true);

    }
    #endregion End Add Orgainsation

    #region Add Request Type Start
    private void FillOrganization1()
    {
        try
        {

            DataTable SD_Org = new FillSDFields().FillOrganization();
            ddlOrg.DataSource = SD_Org;
            ddlOrg.DataTextField = "OrgName";
            ddlOrg.DataValueField = "Org_ID";
            ddlOrg.DataBind();
            ddlOrg.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Organization--", "0"));
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
    private void FillRequestTypeDetails()
    {
        try
        {
            DataTable SD_ReqType = new FillSDFields().FillRequestType();
            if (SD_ReqType.Rows.Count > 0)
            {
                this.gvReqType.DataSource = (object)SD_ReqType;
                this.gvReqType.DataBind();
            }
            else
            {
                this.gvReqType.DataSource = (object)null;
                this.gvReqType.DataBind();
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
    protected void SaveDataReqType()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spRequestType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@ReqTypeRef ", txtRequestType.Text);
                    cmd.Parameters.AddWithValue("@ReqTypeDef", txtReqDescription.Text);
                    cmd.Parameters.AddWithValue("@OrgRef", ddlOrg.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "AddRequestType");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Insert";
                        Response.Redirect(Request.Url.AbsoluteUri);
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
    protected void btnSaveReqType_Click(object sender, EventArgs e)
    {
        SaveDataReqType();
    }
    protected void gvReqType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (Session["UserScope"].ToString() == "Master")
            {
                e.Row.Cells[3].Visible = true;
                e.Row.Cells[4].Visible = true;
            }

            if (Session["UserScope"].ToString() == "Technician")
            {

                e.Row.Cells[4].Visible = false;

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
    protected void gvReqType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEx")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                ID = Convert.ToInt32(gvReqType.DataKeys[rowIndex].Values["ID"]);
                string ReqTypeRef = gvReqType.Rows[rowIndex].Cells[1].Text;
                string ReqTypeDef = gvReqType.Rows[rowIndex].Cells[2].Text;

                //try
                //{
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SD_spRequestType", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@ReqTypeRef", ReqTypeRef);
                        cmd.Parameters.AddWithValue("@ReqTypeDef", ReqTypeDef);
                        cmd.Parameters.AddWithValue("@OrgRef", ddlOrg.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Option", "DelRequestType");
                        cmd.CommandTimeout = 180;
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {

                            Session["Popup"] = "Delete";
                            Response.Redirect(Request.Url.AbsoluteUri);
                        }


                        con.Close();
                        FillRequestTypeDetails();

                    }
                }
            }
            if (e.CommandName == "SelectState")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvReqType.Rows[rowIndex];
                //Get the value of column from the DataKeys using the RowIndex.
                ID = Convert.ToInt32(gvReqType.DataKeys[rowIndex].Values["ID"]);
                txtRequestType.Text = gvReqType.Rows[rowIndex].Cells[1].Text;
                txtReqDescription.Text = gvReqType.Rows[rowIndex].Cells[2].Text;
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrg.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrg.SelectedValue = OrgID.Text;
                }

                btnSave.Visible = false;
                btnUpdateReqType.Visible = true;
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
            Response.Redirect("~/Error/Error.html");
        }
    }
    protected void btnUpdateReqType_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spRequestType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@ReqTypeRef", txtRequestType.Text);
                    cmd.Parameters.AddWithValue("@ReqTypeDef", txtReqDescription.Text);
                    cmd.Parameters.AddWithValue("@OrgRef", ddlOrg.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "UpdateRequestType");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Update";
                        Response.Redirect(Request.Url.AbsoluteUri);
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
    protected void ImgBtnExportReq_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvReqType.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvReqType.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=RequestType.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
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
    protected void btnCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void lnkPrevOrg_Click(object sender, EventArgs e)
    {
        stepper1trigger2.Enabled = true;
        pnlReqType.Visible = false;
        pnlShowOrg.Visible = true;
        FillOrgDetails();
        pnlShowOrg.Visible = true;
        btnOrg(null, null);
        CurrentStep = 1;
        DataBind();
        cleardata();
    }
    protected void lnkNextStage_Click(object sender, EventArgs e)
    {
        pnlReqType.Visible = false;
        pnlAddStage.Visible = true;
        FillOrganization();
        if (Session["UserScope"].ToString().ToLower() == "admin" || Session["UserScope"].ToString().ToLower() == "technician")
        {
            FillStageDetailsCustomer(Session["OrgId"].ToString());
            ddlOrg.Enabled = false;
            ddlOrg.SelectedValue = Session["OrgId"].ToString();
        }
        else
        {
            ddlOrg.Enabled = true;
            FillStageDetails();

        }
        CurrentStep = 3;
        DataBind();
        cleardata();
    }
    #endregion Add Request Type End

    #region Add Stage Start
    private void FillStageDetailsCustomer(string OrgId)
    {
        try
        {
            DataTable SD_Stage = new FillSDFields().FillStageCustomer(OrgId);
            if (SD_Stage.Rows.Count > 0)
            {
                this.gvStage.DataSource = (object)SD_Stage;
                this.gvStage.DataBind();
            }
            else
            {
                this.gvStage.DataSource = (object)null;
                this.gvStage.DataBind();
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
    private void FillOrganization()
    {
        try
        {
            DataTable SD_Org = new FillSDFields().FillOrganization();
            ddlOrg2.DataSource = SD_Org;
            ddlOrg2.DataTextField = "OrgName";
            ddlOrg2.DataValueField = "Org_ID";
            ddlOrg2.DataBind();
            ddlOrg2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));
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
    private void FillStageDetails()
    {
        try
        {
            DataTable SD_Stage = new FillSDFields().FillStage();
            if (SD_Stage.Rows.Count > 0)
            {
                //  this.lb.Text = dataTable.Rows.Count.ToString();
                this.gvStage.DataSource = (object)SD_Stage;
                this.gvStage.DataBind();
            }
            else
            {
                this.gvStage.DataSource = (object)null;
                this.gvStage.DataBind();
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
    protected void ddlRequestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SDRef"] = ddlRequestType.SelectedValue.ToString();
    }
    private void FillRequestType(long OrgId)
    {
        try
        {
            DataTable RequestType = new SDTemplateFileds().FillRequestType(OrgId);
            ddlRequestType.DataSource = RequestType;
            ddlRequestType.DataTextField = "ReqTypeRef";
            ddlRequestType.DataValueField = "ReqTypeRef";
            ddlRequestType.DataBind();
            ddlRequestType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select RequestType----------", "0"));

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
    protected void SaveDataSatge()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spAddStage", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestType.SelectedValue);
                    cmd.Parameters.AddWithValue("@StageRef", ddlRequestType.SelectedValue + "||" + txtStageName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StageCodeRef", txtStageName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StageDesc", txtStageDesc.Text);
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg2.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "AddStage");
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
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
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();
                inEr.InsertErrorLogsF(Session["UserName"].ToString()
    , " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
                Response.Redirect("~/Error/Error.html");

            }
        }
    }
    protected void btnInsertStage_Click(object sender, EventArgs e)
    {
        SaveDataSatge();
    }
    protected void gvStage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEx")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                ID = Convert.ToInt64(gvStage.DataKeys[rowIndex].Values["ID"]);
                string Deskref = gvStage.Rows[rowIndex].Cells[1].Text;
                string SeverityName = gvStage.Rows[rowIndex].Cells[2].Text;
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spAddStage", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@DeskRef", Deskref);
                            cmd.Parameters.AddWithValue("@Option", "DeleteStage");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                pnlShowRqstType.Visible = false;
                                lblsuccess.ForeColor = System.Drawing.Color.Green;
                                lblsuccess.Text = SeverityName + " Deleted successfully";
                                Session["Popup"] = "Delete";
                                Response.Redirect(Request.Url.AbsoluteUri);
                            }
                            con.Close();
                            FillStageDetails();

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
            if (e.CommandName == "SelectStage")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                ID = Convert.ToInt64(gvStage.DataKeys[rowIndex].Values["ID"]);
                GridViewRow row = gvStage.Rows[rowIndex];
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrg2.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrg2.SelectedValue = OrgID.Text;
                    FillRequestType(Convert.ToInt64(OrgID.Text));
                }
                ddlRequestType.SelectedValue = gvStage.Rows[rowIndex].Cells[1].Text;
                txtStageName.Text = gvStage.Rows[rowIndex].Cells[2].Text;
                txtStageDesc.Text = gvStage.Rows[rowIndex].Cells[3].Text;


                btnInsertStage.Visible = false;
                btnUpdateStage.Visible = true;
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
    protected void ImgBtnExport2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvStage.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvStage.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=SD_Stage.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
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
    protected void gvStage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowIndex >= 0)
            {
            }
            if (Session["UserScope"].ToString() == "Master")
            {
                e.Row.Cells[5].Visible = true;
                e.Row.Cells[6].Visible = true;
            }

            if (Session["UserScope"].ToString() == "Technician" || Session["UserScope"].ToString() == "Admin")
            {
                e.Row.Cells[5].Visible = true;
                e.Row.Cells[6].Visible = false;

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
            Response.Redirect("~/Error/Error.html");
        }
    }
    protected void btnUpdateStage_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddStage", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestType.SelectedValue);
                    cmd.Parameters.AddWithValue("@StageRef", ddlRequestType.SelectedValue + "||" + txtStageName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StageCodeRef", txtStageName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StageDesc", txtStageDesc.Text);
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg2.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "UpdateStage");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Update";
                        Response.Redirect(Request.Url.AbsoluteUri);
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
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void ddlOrg2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillRequestType(Convert.ToInt64(ddlOrg2.SelectedValue));
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
    protected void lnkbtnPrevAddReq_Click(object sender, EventArgs e)
    {
        FillRequestTypeDetails();
        FillOrganization();
        pnlReqType.Visible = true;
        pnlAddStage.Visible = false;
        CurrentStep = 2;
        DataBind();
        cleardata();
    }
    protected void lnkbtnNextStatus_Click(object sender, EventArgs e)
    {
        CurrentStep = 4;
        DataBind();
        cleardata();
        FillStatusDetails();
        FillOrganization();
        pnlStatus.Visible = true;
        pnlAddStage.Visible = false;
    }
    #endregion Stage End

    #region Add Status Start 
    private void FillOrganizationStatus()
    {

        try
        {

            DataTable SD_Org = new FillSDFields().FillOrganization(); 
            ddlOrg3.DataSource = SD_Org;
            ddlOrg3.DataTextField = "OrgName";
            ddlOrg3.DataValueField = "Org_ID";
            ddlOrg3.DataBind();
            ddlOrg3.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));
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
    private void FillStatusDetails()
    {
        try
        {
            DataTable SD_Status = new FillSDFields().FillStatus(); 
            if (SD_Status.Rows.Count > 0)
            {
                //  this.lb.Text = dataTable.Rows.Count.ToString();
                this.gvStatus.DataSource = (object)SD_Status;
                this.gvStatus.DataBind();
            }
            else
            {
                this.gvStatus.DataSource = (object)null;
                this.gvStatus.DataBind();
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
    protected void ddlRequestTypeStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SDRef"] = ddlRequestTypeStatus.SelectedValue.ToString();
        FillStage();
    }
    private void FillStage()
    {
        try
        {
            DataTable SD_Priority = new SDTemplateFileds().FillStage(ddlRequestType.SelectedValue, ddlOrg.SelectedValue); ;
            ddlStage.DataSource = SD_Priority;
            ddlStage.DataTextField = "StageCodeRef";
            ddlStage.DataValueField = "id";
            ddlStage.DataBind();
            ddlStage.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Stage----------", "0"));
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
    private void FillRequestTypeStatus(long OrgId)
    {
        try
        {
            DataTable RequestType = new SDTemplateFileds().FillRequestType(OrgId);
            ddlRequestTypeStatus.DataSource = RequestType;
            ddlRequestTypeStatus.DataTextField = "ReqTypeRef";
            ddlRequestTypeStatus.DataValueField = "ReqTypeRef";
            ddlRequestTypeStatus.DataBind();
            ddlRequestTypeStatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select RequestType----------", "0"));
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
    protected void SaveDataStatus()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spAddStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestTypeStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@StatusRef", ddlRequestTypeStatus.SelectedValue + "||" + txtStatusName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StatusCodeRef", txtStatusName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StatusDesc", txtStatusDesc.Text);
                    cmd.Parameters.AddWithValue("@StatusColorCode", txtColorForStatus.Text);
                    cmd.Parameters.AddWithValue("@sd_stageFK", ddlStage.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg3.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "AddStatus");
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
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
    protected void btnInsertStatus_Click(object sender, EventArgs e)
    {
        SaveDataStatus();
    }
    protected void gvStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEx")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                ID = Convert.ToInt32(gvStatus.DataKeys[rowIndex].Values["ID"]);
                string Deskref = gvStatus.Rows[rowIndex].Cells[1].Text;
                string SeverityName = gvStatus.Rows[rowIndex].Cells[2].Text;
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spAddStatus", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@DeskRef", Deskref);
                            cmd.Parameters.AddWithValue("@Option", "DeleteStatus");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                pnlShowRqstType.Visible = false;
                                lblsuccess.ForeColor = System.Drawing.Color.Green;
                                lblsuccess.Text = SeverityName + " Deleted successfully";
                                Session["Popup"] = "Delete";
                                Response.Redirect(Request.Url.AbsoluteUri);
                            }
                            con.Close();
                            FillStatusDetails();
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
            if (e.CommandName == "SelectStatus")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                ID = Convert.ToInt32(gvStatus.DataKeys[rowIndex].Values["ID"]);
                GridViewRow row = gvStatus.Rows[rowIndex];
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrg3.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrg3.SelectedValue = OrgID.Text;
                    FillRequestType(Convert.ToInt64(OrgID.Text));
                }

                ddlRequestTypeStatus.SelectedValue = gvStatus.Rows[rowIndex].Cells[1].Text;
                FillStage();
                Label Stage = (row.FindControl("lblStageFk") as Label);
                if (ddlStage.Items.FindByValue(Stage.Text.ToString().Trim()) != null)
                {
                    ddlStage.SelectedValue = Stage.Text;
                }
                txtStatusName.Text = gvStatus.Rows[rowIndex].Cells[3].Text;
                txtStatusDesc.Text = gvStatus.Rows[rowIndex].Cells[4].Text;
                txtColorForStatus.Text = gvStatus.Rows[rowIndex].Cells[5].Text;

                btnInsertStatus.Visible = false;
                btnUpdateStatus.Visible = true;
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
    protected void ImgBtnExport3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvStatus.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvStatus.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=SD_Status.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
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
    protected void gvStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //e.Row.Cells[4].BackColor = clr;

        try
        {

            if (e.Row.RowIndex >= 0)
            {
                //	System.Drawing.Color clr = ColorTranslator.FromHtml(e.Row.Cells[4].ToString());
                //System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(e.Row.Cells[4].ToString());
                //e.Row.Cells[4].BackColor = System.Drawing.Color.FromArgb(int.Parse(e.Row.Cells[4].ToString().Replace("#","").Trim()));
                //e.Row.Cells[3].Attributes["style"] = "background-color:"+ color;
            }


            if (Session["UserScope"].ToString() == "Master")
            {
                e.Row.Cells[6].Visible = true;
                e.Row.Cells[7].Visible = true;
            }

            if (Session["UserScope"].ToString() == "Technician" || Session["UserScope"].ToString() == "Admin")
            {
                e.Row.Cells[6].Visible = true;
                e.Row.Cells[7].Visible = false;

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
            Response.Redirect("~/Error/Error.html");
        }
    }
    protected void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestTypeStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@StatusRef", ddlRequestTypeStatus.SelectedValue + "||" + txtStatusName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StatusCodeRef", txtStatusName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StatusDesc", txtStatusDesc.Text);
                    cmd.Parameters.AddWithValue("@StatusColorCode", txtColorForStatus.Text);
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg3.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@sd_stageFK", ddlStage.SelectedValue.ToString());
                    //   cmd.Parameters.AddWithValue("@InsertBy", Session["UserName"]);
                    //   cmd.Parameters.AddWithValue("@IsActive", '1');
                    cmd.Parameters.AddWithValue("@Option", "UpdateStatus");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Update";
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }
                    //  ErrorMessage(this, "Welcome", "Greeting");
                    // ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Showalert('success','Data has been updated');", true);
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
    protected void btnCancel3_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void ddlOrg3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillRequestTypeStatus(Convert.ToInt64(ddlOrg3.SelectedValue));
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
    protected void lnkPrevStage_Click(object sender, EventArgs e)
    {
        pnlAddStage.Visible = true;
        pnlStatus.Visible = false;
        CurrentStep = 3;
        cleardata();
        FillOrganization();
        if (Session["UserScope"].ToString().ToLower() == "admin" || Session["UserScope"].ToString().ToLower() == "technician")
        {
            FillStageDetailsCustomer(Session["OrgId"].ToString());
            ddlOrg.Enabled = false;
            ddlOrg.SelectedValue = Session["OrgId"].ToString();
        }
        else
        {
            ddlOrg.Enabled = true;
            FillStageDetails();

        }
        DataBind();
    }
    protected void lnkNextSeverity_Click(object sender, EventArgs e)
    {
        cleardata();
        CurrentStep = 5;
        FillOrganizationSeverity();
        if (Session["UserScope"].ToString().ToLower() == "admin")
        {
            FillSeverityDetailsWithCustomer();
            ddlOrg.Enabled = false;
            ddlOrg.SelectedValue = Session["OrgId"].ToString();
        }
        else
        {
            ddlOrg.Enabled = true;
            FillSeverityDetails();
        }
        DataBind();
        pnlAddSeverity.Visible = true;
        pnlStatus.Visible = false;
    }
    #endregion Add Status End 

    #region Add Severity Start
    private void FillSeverityDetailsWithCustomer()
    {
        try
        {
            DataTable SD_Severity = new FillSDFields().FillSeverityWithCustomer(Session["OrgId"].ToString()); ;
            if (SD_Severity.Rows.Count > 0)
            {
                //  this.lb.Text = dataTable.Rows.Count.ToString();
                this.gvSeverity.DataSource = (object)SD_Severity;
                this.gvSeverity.DataBind();
            }
            else
            {
                this.gvSeverity.DataSource = (object)null;
                this.gvSeverity.DataBind();
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
    private void FillOrganizationSeverity()
    {
        try
        {
            DataTable SD_Org = new FillSDFields().FillOrganization(); ;
            ddlOrg4.DataSource = SD_Org;
            ddlOrg4.DataTextField = "OrgName";
            ddlOrg4.DataValueField = "Org_ID";
            ddlOrg4.DataBind();
            ddlOrg4.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));
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
    private void FillSeverityDetails()
    {
        try
        {
            DataTable SD_Severity = new FillSDFields().FillSeverity();
            if (SD_Severity.Rows.Count > 0)
            {
                this.gvSeverity.DataSource = (object)SD_Severity;
                this.gvSeverity.DataBind();
            }
            else
            {
                this.gvSeverity.DataSource = (object)null;
                this.gvSeverity.DataBind();
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
    protected void ddlRequestTypeSeverity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SDRef"] = ddlRequestTypeSeverity.SelectedValue.ToString();


    }
    private void FillRequestTypeSeverity(long OrgID)
    {
        try
        {
            DataTable RequestType = new SDTemplateFileds().FillRequestType(OrgID);
            ddlRequestTypeSeverity.DataSource = RequestType;
            ddlRequestTypeSeverity.DataTextField = "ReqTypeRef";
            ddlRequestTypeSeverity.DataValueField = "ReqTypeRef";
            ddlRequestTypeSeverity.DataBind();
            ddlRequestTypeSeverity.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select RequestType----------", "0"));
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
    protected void SaveDataSeverity()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spAddSeverity", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@DeskRef", Session["SDRef"].ToString());
                    cmd.Parameters.AddWithValue("@Serverityref", Session["SDRef"].ToString().Trim() + "||" + txtSeverityName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Serveritycoderef", txtSeverityName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SeverityDesc", txtSeverityDescription.Text);
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg4.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ResponseTime", Convert.ToInt32(txtResponseTime.Text));
                    cmd.Parameters.AddWithValue("@ResolutionTime", Convert.ToInt32(txtResolutionTime.Text));
                    cmd.Parameters.AddWithValue("@Option", "AddSeverity");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Insert";
                        Response.Redirect(Request.Url.AbsoluteUri);
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
    protected void btnInsertSeverity_Click(object sender, System.EventArgs e)
    {
        SaveDataSeverity();
    }
    protected void gvSeverity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEx")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                ID = Convert.ToInt32(gvSeverity.DataKeys[rowIndex].Values["ID"]);
                string Deskref = gvSeverity.Rows[rowIndex].Cells[1].Text;
                string SeverityName = gvSeverity.Rows[rowIndex].Cells[2].Text;
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spAddSeverity", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@DeskRef", Deskref);
                            cmd.Parameters.AddWithValue("@Option", "DeleteSeverity");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                pnlShowRqstType.Visible = false;
                                lblsuccess.ForeColor = System.Drawing.Color.Green;
                                lblsuccess.Text = SeverityName + " Deleted successfully";
                                Session["Popup"] = "Delete";
                                Response.Redirect(Request.Url.AbsoluteUri);
                            }
                            con.Close();
                            FillSeverityDetails();

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
            if (e.CommandName == "SelectSeverity")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvSeverity.Rows[rowIndex];
                //Get the value of column from the DataKeys using the RowIndex.
                ID = Convert.ToInt32(gvSeverity.DataKeys[rowIndex].Values["ID"]);

                txtSeverityName.Text = gvSeverity.Rows[rowIndex].Cells[2].Text;
                txtSeverityDescription.Text = gvSeverity.Rows[rowIndex].Cells[3].Text;
                txtResponseTime.Text = gvSeverity.Rows[rowIndex].Cells[4].Text;
                txtResolutionTime.Text = gvSeverity.Rows[rowIndex].Cells[5].Text;
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrg4.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrg4.SelectedValue = OrgID.Text;
                    FillRequestType(Convert.ToInt32(OrgID.Text));
                }
                ddlRequestTypeSeverity.SelectedValue = gvSeverity.Rows[rowIndex].Cells[1].Text;
                btnInsertSeverity.Visible = false;
                btnUpdateSeverity.Visible = true;
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
    protected void ImgBtnExport4_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvSeverity.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvSeverity.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=SD_Severity.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
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
    protected void gvSeverity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (Session["UserScope"].ToString() == "Master")
            {
                e.Row.Cells[7].Visible = true;
                e.Row.Cells[8].Visible = true;
            }

            if (Session["UserScope"].ToString() == "Technician" || Session["UserScope"].ToString() == "Admin")
            {
                e.Row.Cells[7].Visible = true;
                e.Row.Cells[8].Visible = false;

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
    protected void btnUpdateSeverity_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spAddSeverity", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestTypeSeverity.SelectedValue);
                    cmd.Parameters.AddWithValue("@Serverityref", ddlRequestTypeSeverity.SelectedValue + "||" + txtSeverityName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Serveritycoderef", txtSeverityName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SeverityDesc", txtSeverityDescription.Text);
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg4.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ResponseTime", Convert.ToInt32(txtResponseTime.Text));
                    cmd.Parameters.AddWithValue("@ResolutionTime", Convert.ToInt32(txtResolutionTime.Text));
                    cmd.Parameters.AddWithValue("@Option", "UpdateSeverity");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Update";
                        Response.Redirect(Request.Url.AbsoluteUri);
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
    protected void btnCancel5_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void ddlOrg4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillRequestTypeSeverity(Convert.ToInt64(ddlOrg4.SelectedValue));
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
    protected void lnkPrevStatus_Click(object sender, EventArgs e)
    {
        CurrentStep = 4;
        DataBind();
        cleardata();
        FillStatusDetails();
        FillOrganization();
        pnlStatus.Visible = true;
        pnlAddSeverity.Visible = false;
    }
    protected void lnkNextPriority_Click(object sender, EventArgs e)
    {
        cleardata();
    }
    #endregion Add Severity End
}
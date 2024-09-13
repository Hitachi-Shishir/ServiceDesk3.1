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
        if (Session["UserName"] == null || Session["UserScope"] == null)
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
    protected void StepButton_Click7(object sender, EventArgs e)
    {
        CurrentStep = 7;
        // Your logic here
        DataBind();
    } 
    protected void StepButton_Click8(object sender, EventArgs e)
    {
        CurrentStep = 8;
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
    protected void btnInsertOrg_Click(object sender, EventArgs e)
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
        CurrentStep = 6;
        cleardata();
        if (Session["UserScope"].ToString().ToLower() == "admin")
        {
            FillPriorityDetailsCustomer();
            ddlOrg.Enabled = false;
            ddlOrg.SelectedValue = Session["OrgId"].ToString();
        }
        else
        {
            ddlOrg.Enabled = true;
            FillPriorityDetails();
        }
        pnlAddPriority.Visible = true;
        pnlAddSeverity.Visible = false;
        FillOrganizationPriority();
        DataBind();
    }
    #endregion Add Severity End

    #region Add Priority Start
    private void FillPriorityDetailsCustomer()
    {
        try
        {
            DataTable SD_Priority = new FillSDFields().FillPriorityWithCustomer(Session["OrgId"].ToString()); ;

            if (SD_Priority.Rows.Count > 0)
            {
                this.gvPriority.DataSource = (object)SD_Priority;
                this.gvPriority.DataBind();
            }
            else
            {
                this.gvPriority.DataSource = (object)null;
                this.gvPriority.DataBind();
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
    private void FillOrganizationPriority()
    {
        try
        {
            DataTable SD_Org = new FillSDFields().FillOrganization();
            ddlOrg5.DataSource = SD_Org;
            ddlOrg5.DataTextField = "OrgName";
            ddlOrg5.DataValueField = "Org_ID";
            ddlOrg5.DataBind();
            ddlOrg5.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));
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
    private void FillPriorityDetails()
    {
        try
        {
            DataTable SD_Priority = new FillSDFields().FillPriority();
            if (SD_Priority.Rows.Count > 0)
            {
                this.gvPriority.DataSource = (object)SD_Priority;
                this.gvPriority.DataBind();
            }
            else
            {
                this.gvPriority.DataSource = (object)null;
                this.gvPriority.DataBind();
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
    protected void ddlRequestTypePriority_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SDRef"] = ddlRequestTypePriority.SelectedValue.ToString();
    }
    private void FillRequestTypePriority(long OrgID)
    {
        try
        {
            DataTable RequestType = new SDTemplateFileds().FillRequestType(OrgID);
            ddlRequestTypePriority.DataSource = RequestType;
            ddlRequestTypePriority.DataTextField = "ReqTypeRef";
            ddlRequestTypePriority.DataValueField = "ReqTypeRef";
            ddlRequestTypePriority.DataBind();
            ddlRequestTypePriority.Items.Insert(0, new ListItem("----------Select RequestType----------", "0"));
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
    protected void ImgBtnExport7_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvPriority.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvPriority.Rows)
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
    protected void gvPriority_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEx")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                string PriorityRef = gvPriority.DataKeys[rowIndex].Values["PriorityRef"].ToString();
                string Deskref = gvPriority.Rows[rowIndex].Cells[1].Text;
                string PriorityName = gvPriority.Rows[rowIndex].Cells[2].Text;
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spAddPriority", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@PriorityRef", PriorityRef);
                            cmd.Parameters.AddWithValue("@DeskRef", Deskref);
                            cmd.Parameters.AddWithValue("@Option", "DeletePriority");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                Session["Popup"] = "Delete";
                                Response.Redirect(Request.Url.AbsoluteUri);
                            }
                            con.Close();
                            FillPriorityDetails();
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
            if (e.CommandName == "SelectState")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPriority.Rows[rowIndex];
                string PriorityRef = gvPriority.DataKeys[rowIndex].Values["PriorityRef"].ToString();
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrg5.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrg5.SelectedValue = OrgID.Text;
                    FillRequestTypePriority(Convert.ToInt64(OrgID.Text));
                }
                ddlRequestTypePriority.SelectedValue = gvPriority.Rows[rowIndex].Cells[1].Text;
                txtpriority.Text = gvPriority.Rows[rowIndex].Cells[2].Text;
                txtPriorityDescription.Text = gvPriority.Rows[rowIndex].Cells[3].Text;
                btnInsertPriority.Visible = false;
                btnUpdatePriority.Visible = true;
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
    protected void SaveDataPrioirty()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spAddPriority", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@DeskRef", Session["SDRef"].ToString());
                    cmd.Parameters.AddWithValue("@PriorityRef", Session["SDRef"].ToString().Trim() + "||" + txtpriority.Text.Trim());
                    cmd.Parameters.AddWithValue("@PriorityCodeRef", txtpriority.Text.Trim());
                    cmd.Parameters.AddWithValue("@PriorityDesc", txtPriorityDescription.Text);
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "AddPriority");
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
    protected void btnInsertPriority_Click(object sender, EventArgs e)
    {
        SaveDataPrioirty();
    }
    protected void gvPriority_RowDataBound(object sender, GridViewRowEventArgs e)
    {
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
    protected void btnUpdatePriority_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddPriority", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestTypePriority.SelectedValue);
                    cmd.Parameters.AddWithValue("@PriorityRef", ddlRequestTypePriority.SelectedValue.ToString().Trim() + "||" + txtpriority.Text.Trim());
                    cmd.Parameters.AddWithValue("@PriorityCodeRef", txtpriority.Text.Trim());
                    cmd.Parameters.AddWithValue("@PriorityDesc", txtPriorityDescription.Text);
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg5.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "UpdatePriority");
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
    protected void btnCancel6_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void ddlOrg5_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillRequestTypePriority(Convert.ToInt64(ddlOrg5.SelectedValue));
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
    protected void lnkPreviousSeverity_Click(object sender, EventArgs e)
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
    protected void lnkNextCategory_Click(object sender, EventArgs e)
    {
        CurrentStep = 7;
        cleardata();
        pnlCategory.Visible = true;
        pnlAddPriority.Visible = false;
        FillOrganizationCategory();
        if (Session["UserScope"].ToString().ToLower() == "admin")
        {
            ddlOrg6.Enabled = false;
            ddlOrg6.SelectedValue = Session["OrgId"].ToString();
            FillRequestTypeCategory(Convert.ToInt64(Session["OrgId"].ToString()));
        }
        else
        {
            ddlOrg6.Enabled = true;
        }
        DataBind();
    }
    #endregion Add Priority End

    #region Add Category Start
    private void FillOrganizationCategory()
    {
        try
        {
            DataTable SD_Org = new FillSDFields().FillOrganization();
            ddlOrg6.DataSource = SD_Org;
            ddlOrg6.DataTextField = "OrgName";
            ddlOrg6.DataValueField = "Org_ID";
            ddlOrg6.DataBind();
            ddlOrg6.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));
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
    private void FillRequestTypeCategory(long Orgid)
    {
        try
        {
            DataTable RequestType = new SDTemplateFileds().FillRequestType(Orgid);
            ddlRequestTypeCategory.DataSource = RequestType;
            ddlRequestTypeCategory.DataTextField = "ReqTypeRef";
            ddlRequestTypeCategory.DataValueField = "ReqTypeRef";
            ddlRequestTypeCategory.DataBind();
            ddlRequestTypeCategory.Items.Insert(0, new ListItem("----------Select RequestType----------", "0"));
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
    protected void ddlRequestTypeCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SDRef"] = ddlRequestTypeCategory.SelectedValue.ToString();
        FillParentCategory();

    }
    protected void SaveParentCategory()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@DeskRef", Session["SDRef"].ToString());
                    cmd.Parameters.AddWithValue("@Categoryref", Session["SDRef"].ToString().Trim() + "||" + txtParentCategory.Text.Trim());
                    cmd.Parameters.AddWithValue("@CategoryCodeRef", txtParentCategory.Text.Trim());
                    cmd.Parameters.AddWithValue("@rowDesc", "");
                    cmd.Parameters.AddWithValue("@CategoryLevel", Convert.ToInt32(1));
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg6.SelectedValue);
                    cmd.Parameters.AddWithValue("@Option", "AddCategory");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        ddlParentCategory.Enabled = true;
                        ddlParentCategory.Visible = true;
                        FillParentCategory();
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
                inEr.InsertErrorLogsF(Session["UserName"].ToString()
                    , "Add Category: Error While Adding This Category" + Session["SDRef"].ToString().Trim() + "||" + txtParentCategory.Text.Trim() + Request.Url.ToString() + "Got Exception" + ex.ToString());

                //    // msg.ReportError1(ex.Message);
                //    // lblsuccess.Text = msg.ms; ;
            }

        }
    }
    int res;
    protected int SaveChildCategory(string CategoryRef, string CategoryCodeRef, int CategoryLevel)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spAddCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RefID", CategoryRef);
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@DeskRef", Session["SDRef"].ToString());
                    cmd.Parameters.AddWithValue("@Categoryref", CategoryRef + "||" + CategoryCodeRef.Trim());
                    cmd.Parameters.AddWithValue("@CategoryCodeRef", CategoryCodeRef.Trim());
                    cmd.Parameters.AddWithValue("@rowDesc", "");
                    cmd.Parameters.AddWithValue("@CategoryLevel", Convert.ToInt32(CategoryLevel));
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg6.SelectedValue);
                    cmd.Parameters.AddWithValue("@Option", "AddChildCategory");
                    con.Open();
                    res = cmd.ExecuteNonQuery();
                }
            }
            return res;
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
            return 0;
        }
        catch (Exception ex)
        {

            if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
            {

            }
            else
            {

                inEr.InsertErrorLogsF(Session["UserName"].ToString()
                    , "Add Category: Error While Adding This Category" + Session["SDRef"].ToString().Trim() + "||" + txtParentCategory.Text.Trim() + Request.Url.ToString() + "Got Exception" + ex.ToString());

                //    // msg.ReportError1(ex.Message);
                //    // lblsuccess.Text = msg.ms; ;
            }
            return 0;
        }
        //  Response.Redirect(Request.Url.AbsoluteUri);

    }
    private void FillParentCategory()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT CategoryCodeRef,
           Categoryref FROM [dbo].fnGetCategoryFullPathForDesk('" + ddlRequestTypeCategory.SelectedValue + "','" + ddlOrg6.SelectedValue + "', 1) where Level=1   order by Categoryref asc", con))
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
                                ddlParentCategory.DataSource = dt;
                                ddlParentCategory.DataTextField = "CategoryCodeRef";
                                ddlParentCategory.DataValueField = "Categoryref";
                                ddlParentCategory.DataBind();
                                ddlParentCategory.Items.Insert(0, new ListItem("----------Select Category----------", "0"));
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
                inEr.InsertErrorLogsF(Session["UserName"].ToString()
            , "Add Category: Error While Populating ParentCategory " + Request.Url.ToString() + "Got Exception" + ex.ToString());
                // lblMsg.Text = ex.Message.ToString();
            }
        }
    }
    private DataTable FillCategoryLevel(string category, int categoryLevel)
    {
        try
        {
            hdnVarCategoryIII.Value = hdnVarCategoryI.Value;
            DataTable dtFillCategory = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"	select Categoryref,categorycoderef from 
					(select a.Categoryref as sdCategoryFK,b.Categoryref,b.categorycoderef from dbo.fnGetCategoryFullPathForPartition(1,'" + ddlOrg6.SelectedValue + "') a  left join  dbo.fnGetCategoryFullPathForPartition(1,'" + ddlOrg.SelectedValue + "') b on a.id=b.sdCategoryFK) c where c.sdCategoryFK='" + category + "' and c.Categoryref!='' order by categorycoderef asc", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.SelectCommand.CommandTimeout = 180;
                        adp.Fill(dtFillCategory);
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
            return null;
        }
    }
    protected void ddlParentCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            imgbtnCancelCatII.Enabled = true;
            txtCatII.Visible = false;
            ddlCatII.Enabled = true;
            ddlCatII.Visible = true;
            ddlCatII.ClearSelection();
            hdnVarCategoryI.Value = null;
            hdnVarCategoryII.Value = null;
            hdnVarCategoryIII.Value = null;
            hdnVarCategoryIV.Value = null;
            hdnVarCategoryV.Value = null;
            ddlCateLevelIII.ClearSelection();
            ddlCateLevelIII.Enabled = false;
            ddlCateLevelIII.Visible = true;
            txtCatLevelIII.Visible = false;
            imgbtnCancelCatIII.Enabled = false;
            imgbtnCancelCatIV.Enabled = false;
            imgbtnCancelCatV.Enabled = false;
            ddlCateLevelIV.ClearSelection();
            ddlCateLevelIV.Enabled = false;
            ddlCateLevelIV.Visible = true;
            txtCateLevelIV.Visible = false;
            ddlCatV.ClearSelection();
            ddlCatV.Enabled = false;
            ddlCatV.Visible = true;
            txtCatV.Visible = false;
            hdnVarCategoryI.Value = ddlParentCategory.SelectedValue.ToString();
            FillCategoryLevel2();
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
    protected void imgbtnAddParentCategory_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtParentCategory.Text = "";
            ddlParentCategory.Enabled = false;
            ddlParentCategory.Visible = false;
            //Enable textbox  for entry
            txtParentCategory.Visible = true;
            rfvtxtParentCategory.Enabled = true;
            imgbtnSaveParentCategory.Enabled = true;

            imgbtnCancelParent.Enabled = true;
            ddlCatII.Enabled = false;
            txtCatII.Visible = false;
            ddlCateLevelIII.Enabled = false;
            txtCatLevelIII.Visible = false;
            ddlCateLevelIV.Enabled = false;
            txtCateLevelIV.Visible = false;
            ddlCatV.Enabled = false;
            txtCatV.Visible = false;
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
    protected void imgbtnSaveParentCategory_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            rfvtxtParentCategory.Enabled = true;
            txtParentCategory.Visible = true;
            SaveParentCategory();
            FillParentCategory();
            txtParentCategory.Visible = false;
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
    /// <summary>
    /// Add and Save Category Level 2
    /// </summary>
    protected void imgbtnCatII_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtCatII.Text = "";
            //// to enable  textbox and disable  dropdown
            ///// Make sure Category level 1 dropdown is enable and value is selected
            ddlParentCategory.Enabled = true;
            ddlParentCategory.Visible = true;
            txtParentCategory.Visible = false;
            imgbtnSaveParentCategory.Enabled = false;
            ddlCatII.Enabled = false;
            ddlCatII.Visible = false;

            txtCatII.Visible = true;
            txtCatII.Enabled = true;
            imgbtnSaveCatII.Enabled = true;

            ddlCateLevelIII.Enabled = false;
            txtCatLevelIII.Visible = false;
            ddlCateLevelIV.Enabled = false;
            txtCateLevelIV.Visible = false;
            ddlCatV.Enabled = false;
            txtCatV.Visible = false;
            hdnVarCategoryI.Value = ddlParentCategory.SelectedValue;
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
    protected void imgbtnSaveCatII_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            ////////// To Save  Category Level 2 and fill Category Level 2////////
            //Disable Textbox and enable dropdown 
            // Make sure Category level 1 value is selected 
            rfvtxtCatII.Enabled = true;
            res = SaveChildCategory(ddlParentCategory.SelectedValue.ToString(), txtCatII.Text, 2);
            ddlCatII.Enabled = true;
            ddlCatII.Visible = true;
            txtCatII.Enabled = false;
            txtCatII.Visible = false;
            if (res > 0)
            {
                ddlCatII.Enabled = true;
                ddlCatII.Visible = true;
                FillParentCategory();
                ddlParentCategory.SelectedValue = hdnVarCategoryI.Value.ToString();
                FillCategoryLevel2();


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
    protected void ddlCatII_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //// Enable Category level dropdown 3 textbox and 
            ///Make sure all its parent category got selected
            imgbtnCancelCatIII.Enabled = true;
            ddlCateLevelIII.Enabled = true;
            ddlCateLevelIII.Visible = true;
            txtCatLevelIII.Visible = false;
            hdnVarCategoryII.Value = ddlCatII.SelectedValue.ToString();
            // FillCategoryLevel(ddlCategory1.SelectedValue, 3);
            FillCategoryLevel3();

            imgbtnCancelCatIV.Enabled = false;
            imgbtnCancelCatV.Enabled = false;

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
    /// <summary>
    /// Add and Save Category Level 3
    /// </summary>
    protected void FillCategoryLevel2()
    {
        try
        {
            //hdnVarCategoryII.Value = ddlParentCategory.SelectedValue.ToString();
            DataTable FillCategoryLevel2 = new DataTable();
            FillCategoryLevel2 = FillCategoryLevel(ddlParentCategory.SelectedValue, 2);
            if (FillCategoryLevel2.Rows.Count > 0)
            {
                ddlCatII.DataSource = FillCategoryLevel2;
                ddlCatII.DataTextField = "CategoryCodeRef";
                ddlCatII.DataValueField = "Categoryref";
                ddlCatII.DataBind();
                ddlCatII.Items.Insert(0, new ListItem("----------Select Category Level 2----------", "0"));
            }
            else
            {
                ddlCatII.ClearSelection();
                ddlCatII.Enabled = false;
                FillCategoryLevel2 = null;
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
    protected void FillCategoryLevel3()
    {
        try
        {
            DataTable FillCategoryLevel3 = FillCategoryLevel(ddlCatII.SelectedValue, 3);
            if (FillCategoryLevel3.Rows.Count > 0)
            {
                ddlCateLevelIII.DataSource = FillCategoryLevel3;
                ddlCateLevelIII.DataTextField = "CategoryCodeRef";
                ddlCateLevelIII.DataValueField = "Categoryref";
                ddlCateLevelIII.DataBind();
                ddlCateLevelIII.Items.Insert(0, new ListItem("----------Select Category Level 3----------", "0"));
            }
            else
            {
                ddlCateLevelIII.ClearSelection();
                ddlCateLevelIII.Enabled = false;
                ddlCateLevelIII.DataSource = null;
                ddlCateLevelIII.DataBind();
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
    protected void FillCategorylevel4()
    {
        try
        {
            DataTable FillCategoryLevel4 = FillCategoryLevel(ddlCateLevelIII.SelectedValue, 4);
            if (FillCategoryLevel4.Rows.Count > 0)
            {
                ddlCateLevelIV.DataSource = FillCategoryLevel4;
                ddlCateLevelIV.DataTextField = "CategoryCodeRef";
                ddlCateLevelIV.DataValueField = "Categoryref";
                ddlCateLevelIV.DataBind();
                ddlCateLevelIV.Items.Insert(0, new ListItem("----------Select Category Level 4----------", "0"));
            }
            else
            {
                ddlCateLevelIV.DataSource = null;
                ddlCateLevelIV.DataBind();

                ddlCateLevelIV.ClearSelection();
                ddlCateLevelIV.Enabled = false;
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
    protected void FillCategorylevel5()
    {
        try
        {
            DataTable FillCategoryLevel5 = FillCategoryLevel(ddlCateLevelIV.SelectedValue, 5);
            if (FillCategoryLevel5.Rows.Count > 0)
            {
                ddlCatV.DataSource = FillCategoryLevel5;
                ddlCatV.DataTextField = "CategoryCodeRef";
                ddlCatV.DataValueField = "Categoryref";
                ddlCatV.DataBind();
                ddlCatV.Items.Insert(0, new ListItem("----------Select Category Level 5----------", "0"));
            }
            else
            {
                ddlCatV.DataSource = null;
                ddlCatV.DataBind();
                ddlCatV.ClearSelection();
                ddlCatV.Enabled = false;
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
    protected void imgAddCatIII_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtCatLevelIII.Text = "";
            ddlCatII.Enabled = true;
            ddlCatII.Visible = true;
            ddlCateLevelIII.Enabled = false;
            ddlCateLevelIII.Visible = false;
            imgbtnSaveCatII.Enabled = false;
            txtCatII.Visible = false;
            txtCatII.Enabled = false;
            txtCatLevelIII.Visible = true;
            txtCatLevelIII.Enabled = true;
            imgSaveCatIII.Enabled = true;
            ddlCateLevelIV.Enabled = false;
            txtCateLevelIV.Visible = false;
            ddlCatV.Enabled = false;
            txtCatV.Visible = false;
            hdnVarCategoryII.Value = ddlCatII.SelectedValue;
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
    /// <summary>
    /// ////Save Category level 3
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgSaveCatIII_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            rfvtxtCatLevelIII.Enabled = true;
            FillParentCategory();
            ddlParentCategory.SelectedValue = hdnVarCategoryI.Value;
            FillCategoryLevel2();
            ddlCatII.SelectedValue = hdnVarCategoryII.Value;
            res = SaveChildCategory(ddlCatII.SelectedValue.ToString(), txtCatLevelIII.Text, 3);
            ddlCateLevelIII.Enabled = true;
            ddlCateLevelIII.Visible = true;
            txtCatLevelIII.Enabled = false;
            txtCatLevelIII.Visible = false;
            if (res > 0)
            {
                FillCategoryLevel3();
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
    protected void ddlCateLevelIII_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            imgbtnCancelCatIII.Enabled = true;

            ddlCateLevelIV.Enabled = true;
            ddlCateLevelIV.Visible = true;
            txtCateLevelIV.Visible = false;
            hdnVarCategoryIII.Value = ddlCateLevelIII.SelectedValue.ToString();
            // FillCategoryLevel(ddlCategory1.SelectedValue, 3);
            FillCategorylevel4();
            // FillCategorylevel4();

            imgbtnCancelCatV.Enabled = false;
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
    // Add and Save Category Level 4
    protected void imgbtnCatelevelIV_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtCateLevelIV.Text = "";
            ddlCateLevelIII.Enabled = true;
            ddlCateLevelIII.Visible = true;
            txtCatLevelIII.Visible = false;
            txtCatLevelIII.Enabled = false;
            imgSaveCatIII.Enabled = false;
            ddlCateLevelIV.Enabled = false;
            ddlCateLevelIV.Visible = false;
            txtCateLevelIV.Visible = true;
            txtCateLevelIV.Enabled = true;
            imgbtnSaveCateLvlIV.Enabled = true;
            imgbtnCancelCatIV.Enabled = true;


            ddlCatV.Enabled = false;
            txtCatV.Visible = false;
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
    protected void imgbtnSaveCateLvlIV_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            rfvtxtCateLevelIV.Enabled = true;
            //FillParentCategory();
            //ddlParentCategory.SelectedValue = hdnVarCategoryI.Value;
            //FillCategoryLevel2();
            //ddlCatII.SelectedValue = hdnVarCategoryII.Value;
            //FillCategoryLevel3();
            //ddlCateLevelIII.SelectedValue = hdnVarCategoryIII.Value;
            res = SaveChildCategory(ddlCateLevelIII.SelectedValue.ToString(), txtCateLevelIV.Text, 4);
            ddlCateLevelIV.Enabled = true;
            ddlCateLevelIV.Visible = true;
            txtCateLevelIV.Visible = false;
            txtCateLevelIV.Enabled = false;
            if (res > 0)
            {
                FillCategorylevel4();
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
    protected void ddlCateLevelIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            imgbtnCancelCatIV.Enabled = true;


            ddlCatV.Enabled = true;
            ddlCatV.Visible = true;
            txtCatV.Visible = false;
            hdnVarCategoryIV.Value = ddlCateLevelIV.SelectedValue.ToString();
            // FillCategoryLevel(ddlCategory1.SelectedValue, 3);

            FillCategorylevel5();
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
    // Add and save Category Level 5
    protected void imgbtnAddCatV_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            txtCatV.Text = "";
            ddlCateLevelIV.Enabled = true;
            ddlCateLevelIV.Visible = true;
            txtCateLevelIV.Visible = false;
            txtCateLevelIV.Enabled = false;
            imgbtnSaveCateLvlIV.Enabled = false;
            ddlCatV.Enabled = false;
            ddlCatV.Visible = false;
            txtCatV.Visible = true;
            txtCatV.Enabled = true;
            imgbtnSaveCatV.Enabled = true;
            imgbtnCancelCatV.Enabled = true;
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
    protected void imgbtnSaveCatV_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            rfvtxtCatV.Enabled = true;
            //FillParentCategory();
            //ddlParentCategory.SelectedValue = hdnVarCategoryI.Value;
            //FillCategoryLevel2();
            //ddlCatII.SelectedValue = hdnVarCategoryII.Value;
            //FillCategoryLevel3();
            //ddlCateLevelIII.SelectedValue = hdnVarCategoryIII.Value;
            //FillCategorylevel4();
            //ddlCateLevelIV.SelectedValue = hdnVarCategoryIV.Value;
            res = SaveChildCategory(ddlCateLevelIV.SelectedValue.ToString(), txtCatV.Text, 5);
            ddlCatV.Visible = true;
            ddlCatV.Enabled = true;
            txtCatV.Visible = false;
            txtCatV.Visible = false;
            if (res > 0)
            {
                FillCategorylevel5();
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
    protected void btnClose7_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void imgbtnCancelParent_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ddlParentCategory.Enabled = true;
            ddlParentCategory.Visible = true;
            txtParentCategory.Visible = false;
            rfvtxtParentCategory.Enabled = false;
            imgbtnSaveParentCategory.Enabled = false;
            ddlCatII.Enabled = false;
            FillParentCategory();
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
    protected void imgbtnCancelCatII_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ddlCatII.Enabled = true;
            ddlCatII.Visible = true;
            imgbtnSaveCatII.Visible = true;

            txtCatII.Visible = false;
            txtCatII.Enabled = false;
            imgbtnSaveCatII.Enabled = false;
            ddlCateLevelIII.ClearSelection();
            ddlCateLevelIII.Enabled = false;
            txtCatLevelIII.Visible = false;
            ddlCateLevelIV.ClearSelection();
            ddlCateLevelIV.Enabled = false;
            txtCateLevelIV.Visible = false;
            ddlCatV.ClearSelection();
            ddlCatV.Enabled = false;
            txtCatV.Visible = false;
            FillParentCategory();
            ddlParentCategory.SelectedValue = hdnVarCategoryI.Value.ToString();
            FillCategoryLevel2();
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
    protected void imgbtnCancelCatIII_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ddlCateLevelIII.Enabled = true;
            ddlCateLevelIII.Visible = true;
            ddlCateLevelIII.ClearSelection();
            txtCatLevelIII.Visible = false;
            txtCatLevelIII.Enabled = false;
            imgSaveCatIII.Enabled = false;

            ddlCateLevelIV.ClearSelection();
            ddlCateLevelIV.Enabled = false;
            txtCateLevelIV.Visible = false;
            ddlCatV.ClearSelection();
            ddlCatV.Enabled = false;
            txtCatV.Visible = false;
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
    protected void imgbtnCancelCatIV_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ddlCateLevelIV.Enabled = true;
            ddlCateLevelIV.Visible = true;
            ddlCateLevelIV.ClearSelection();
            txtCateLevelIV.Visible = false;
            txtCateLevelIV.Enabled = false;
            imgbtnSaveCateLvlIV.Enabled = false;

            ddlCatV.ClearSelection();
            ddlCatV.Enabled = false;
            txtCatV.Visible = false;
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
    protected void imgbtnCancelCatV_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ddlCatV.Enabled = true;
            ddlCatV.Visible = true;
            txtCatV.Visible = false;
            txtCatV.Enabled = false;
            imgbtnSaveCatV.Enabled = false;
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
    public static string parentcategoryValue;
    public static string CategoryIIValue;
    public static string CategoryIIIValue;
    public static string CategoryIVValue;
    public static string CategoryVValue;
    protected void imgbtnEditParentCategory_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            ddlParentCategory.Enabled = true;
            if (ddlParentCategory.SelectedIndex != 0)
            {
                imgbtnCancelParent.Enabled = true;
                imgbtnSaveParentCategory.Enabled = false;
                imgbtnSaveParentCategory.Visible = false;
                imgbtnUpdateParentCategory.Visible = true;
                txtParentCategory.Enabled = true;
                txtParentCategory.Visible = true;
                txtParentCategory.Text = ddlParentCategory.SelectedItem.Text;
                parentcategoryValue = ddlParentCategory.SelectedValue.ToString();
                ddlParentCategory.Visible = false;

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
    protected void imgbtnEditCatII_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            ddlCatII.Enabled = true;
            if (ddlCatII.SelectedIndex != 0)
            {
                imgbtnCancelCatII.Enabled = true;
                imgbtnSaveCatII.Enabled = false;
                imgbtnSaveCatII.Visible = false;
                imtbtnUpdateCatII.Visible = true;
                txtCatII.Enabled = true;
                txtCatII.Visible = true;
                txtCatII.Text = ddlCatII.SelectedItem.Text;
                CategoryIIValue = ddlCatII.SelectedValue.ToString();
                ddlCatII.Visible = false;
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
    protected void imgbtnEditCatIII_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            ddlCateLevelIII.Enabled = true;
            if (ddlCateLevelIII.SelectedIndex != 0)
            {
                imgbtnCancelCatIII.Enabled = true;
                imgSaveCatIII.Enabled = false;
                imgSaveCatIII.Visible = false;
                imgbtnUpdateCatIII.Visible = true;
                txtCatLevelIII.Enabled = true;
                txtCatLevelIII.Visible = true;
                txtCatLevelIII.Text = ddlCateLevelIII.SelectedItem.Text;
                CategoryIIIValue = ddlCateLevelIII.SelectedValue.ToString();
                ddlCateLevelIII.Visible = false;

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
    protected void imgbtnEditCatLvIV_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            ddlCateLevelIV.Enabled = true;
            if (ddlCateLevelIV.SelectedIndex != 0)
            {
                imgbtnCancelCatIV.Enabled = true;
                imgbtnSaveCateLvlIV.Enabled = false;
                imgbtnSaveCateLvlIV.Visible = false;
                imgbtnUpdateCateLvIV.Visible = true;
                txtCateLevelIV.Enabled = true;
                txtCateLevelIV.Visible = true;
                txtCateLevelIV.Text = ddlCateLevelIV.SelectedItem.Text;
                CategoryIVValue = ddlCateLevelIV.SelectedValue.ToString();
                ddlCateLevelIV.Visible = false;

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
    protected void imgbtnEditCatV_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            ddlCatV.Enabled = true;
            if (ddlCatV.SelectedIndex != 0)
            {
                imgbtnCancelCatV.Enabled = true;
                imgbtnSaveCatV.Enabled = false;
                imgbtnSaveCatV.Visible = false;
                imgbtnUpdateCatV.Visible = true;
                txtCatV.Enabled = true;
                txtCatV.Visible = true;
                txtCatV.Text = ddlCatV.SelectedItem.Text;
                CategoryVValue = ddlCatV.SelectedValue.ToString();
                ddlCatV.Visible = false;

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
    protected void ddlOrg6_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRequestTypeCategory(Convert.ToInt64(ddlOrg.SelectedValue));
    }
    protected void imgbtnUpdateParentCategory_Click(object sender, ImageClickEventArgs e)
    {
        if (txtParentCategory.Text != null)
        {
            int result = UpdateCategory(parentcategoryValue, txtParentCategory.Text.Trim());
            if (result > 0)
            {
                imgbtnSaveParentCategory.Visible = true;
                imgbtnUpdateParentCategory.Visible = false;
                ddlParentCategory.Enabled = true;
                ddlParentCategory.Visible = true;
                txtParentCategory.Visible = false;
                txtParentCategory.Text = "";
                FillParentCategory();
                ddlCatII.ClearSelection();
                ddlCatII.Enabled = false;
                ddlCateLevelIII.ClearSelection();
                ddlCateLevelIII.Enabled = false;
                ddlCateLevelIV.ClearSelection();
                ddlCateLevelIV.Enabled = false;
                ddlCatV.Enabled = false;
                ddlCatV.ClearSelection();

            }
        }
    }
    protected int UpdateCategory(string PrevCategoryName, string UpdatedCategoryName)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
        {

            using (SqlCommand cmd = new SqlCommand("SD_spAddCategory", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeskRef", Session["SDRef"].ToString());
                cmd.Parameters.AddWithValue("@Categoryref", Session["SDRef"].ToString().Trim() + "||" + UpdatedCategoryName);
                cmd.Parameters.AddWithValue("@CategoryCodeRef", UpdatedCategoryName);
                cmd.Parameters.AddWithValue("@CategoryUpdateref", PrevCategoryName);
                cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg6.SelectedValue);
                cmd.Parameters.AddWithValue("@Option", "UpdateCategory");
                con.Open();
                int res = cmd.ExecuteNonQuery();
                return res;
            }
        }

    }
    protected int UpdateChildCategory(string PrevCategoryName, string UpdatedCategoryName, string ParentCategoryName)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SD_spAddCategory", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeskRef", Session["SDRef"].ToString());
                cmd.Parameters.AddWithValue("@Categoryref", ParentCategoryName + "||" + UpdatedCategoryName);
                cmd.Parameters.AddWithValue("@CategoryCodeRef", UpdatedCategoryName);
                cmd.Parameters.AddWithValue("@CategoryUpdateref", PrevCategoryName);
                cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg6.SelectedValue);
                cmd.Parameters.AddWithValue("@Option", "UpdateCategory");
                con.Open();
                int res = cmd.ExecuteNonQuery();
                return res;
            }
        }

    }
    protected void imtbtnUpdateCatII_Click(object sender, ImageClickEventArgs e)
    {
        if (txtCatII.Text != null)
        {
            int result = UpdateChildCategory(CategoryIIValue, txtCatII.Text.Trim(), ddlParentCategory.SelectedValue);
            if (result > 0)
            {
                ddlCatII.Enabled = true;
                ddlCatII.Visible = true;
                txtCatII.Visible = false;
                txtCatII.Text = "";
                imgbtnSaveCatII.Visible = true;
                imtbtnUpdateCatII.Visible = false;
                hdnVarCategoryI.Value = ddlParentCategory.SelectedValue;
                FillCategoryLevel2();

                ddlCateLevelIII.ClearSelection();
                ddlCateLevelIII.Enabled = false;
                ddlCateLevelIV.ClearSelection();
                ddlCateLevelIV.Enabled = false;
                ddlCatV.Enabled = false;
                ddlCatV.ClearSelection();

            }
        }
    }
    protected void imgbtnUpdateCatIII_Click(object sender, ImageClickEventArgs e)
    {
        if (txtCatLevelIII.Text != null)
        {
            int result = UpdateChildCategory(CategoryIIIValue, txtCatLevelIII.Text.Trim(), ddlCatII.SelectedValue);
            if (result > 0)
            {
                ddlCateLevelIII.Enabled = true;
                ddlCateLevelIII.Visible = true;
                txtCatLevelIII.Visible = false;
                txtCatLevelIII.Text = "";
                //	FillParentCategory();
                imgSaveCatIII.Visible = true;
                imgbtnUpdateCatIII.Visible = false;
                hdnVarCategoryII.Value = ddlCatII.SelectedValue;
                FillCategoryLevel3();


            }
        }
    }
    protected void imgbtnUpdateCateLvIV_Click(object sender, ImageClickEventArgs e)
    {
        if (txtCateLevelIV.Text != null)
        {
            int result = UpdateChildCategory(CategoryIVValue, txtCateLevelIV.Text.Trim(), ddlCateLevelIII.SelectedValue);
            if (result > 0)
            {
                ddlCateLevelIV.Enabled = true;
                ddlCateLevelIV.Visible = true;
                txtCateLevelIV.Visible = false;
                txtCateLevelIV.Text = "";
                //	FillParentCategory();
                imgbtnSaveCateLvlIV.Visible = true;
                imgbtnUpdateCateLvIV.Visible = false;
                hdnVarCategoryIII.Value = ddlCateLevelIII.SelectedValue;
                FillCategorylevel4();
                ddlCatV.Enabled = false;
                ddlCatV.ClearSelection();

            }
        }
    }
    protected void imgbtnUpdateCatV_Click(object sender, ImageClickEventArgs e)
    {
        if (txtCatV.Text != null)
        {
            int result = UpdateChildCategory(CategoryVValue, txtCatV.Text.Trim(), ddlCateLevelIV.SelectedValue);
            if (result > 0)
            {
                ddlCatV.Enabled = true;
                ddlCatV.Visible = true;
                txtCatV.Visible = false;
                txtCatV.Text = "";
                imgbtnSaveCatV.Visible = true;
                imgbtnUpdateCatV.Visible = false;
                hdnVarCategoryIV.Value = ddlCateLevelIV.SelectedValue;
                FillCategorylevel5();
            }
        }
    }
    protected void lnkPreviousPriority_Click(object sender, EventArgs e)
    {
        CurrentStep = 6;
        cleardata();
        if (Session["UserScope"].ToString().ToLower() == "admin")
        {
            FillPriorityDetailsCustomer();
            ddlOrg.Enabled = false;
            ddlOrg.SelectedValue = Session["OrgId"].ToString();
        }
        else
        {
            ddlOrg.Enabled = true;
            FillPriorityDetails();
        }
        pnlAddPriority.Visible = true;
        pnlAddSeverity.Visible = false;
        FillOrganizationPriority();
        DataBind();
    }
    protected void lnkNextResolution_Click(object sender, EventArgs e)
    {

    }
    #endregion Add Category End

    #region Email Config Start

    #endregion Email Config End
}
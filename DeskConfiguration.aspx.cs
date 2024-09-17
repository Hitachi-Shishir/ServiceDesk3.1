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
    public static long OrgID;
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
            //checkPanel();
            if (Session["UserScope"] != null)
            {
                if (!IsPostBack)
                {
                    #region Add Orgainisation 
                    getOrg();
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
        }
    }
    #region Common Start
    public void DataTableScript()
    {
        // Load jQuery first
        string jqueryScript = "<script src='assets/js/jquery-3.6.0.min.js'></script>";

        // Load DataTables JS files
        string dataTableScript = "<script src='assets/plugins/datatable/js/jquery.dataTables.min.js'></script>";
        string dataTableBootstrapScript = "<script src='assets/plugins/datatable/js/dataTables.bootstrap5.min.js'></script>";

        // Load DataTables CSS files for Bootstrap 5
        string dataTableCss = "<link href='assets/plugins/datatable/css/dataTables.bootstrap5.min.css' rel='stylesheet' />";

        // Register CSS
        ClientScript.RegisterStartupScript(this.GetType(), "dataTableCss", dataTableCss, false);

        // Register jQuery and DataTables scripts
        ClientScript.RegisterStartupScript(this.GetType(), "jqueryScript", jqueryScript, false);
        ClientScript.RegisterStartupScript(this.GetType(), "dataTableScript", dataTableScript, false);
        ClientScript.RegisterStartupScript(this.GetType(), "dataTableBootstrapScript", dataTableBootstrapScript, false);

        // DataTable initialization script
        string script = @"
    <script type='text/javascript'>
        $(document).ready(function () {
            $('.data-table1').DataTable({
                'paging': true,
                'ordering': true, // Enable sorting
                'info': true
            });
        });
    </script>";

        // Use ScriptManager for partial postbacks or full postbacks
        ScriptManager.RegisterStartupScript(this, GetType(), "initializeDataTable", script, true);
    }

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
    protected void StepButton_Click9(object sender, EventArgs e)
    {
        CurrentStep = 9;
        // Your logic here
        DataBind();
    }
    protected void StepButton_Click10(object sender, EventArgs e)
    {
        CurrentStep = 10;
        // Your logic here
        DataBind();
    }
    protected void StepButton_Click11(object sender, EventArgs e)
    {
        CurrentStep = 11;
        // Your logic here
        DataBind();
    }
    protected void StepButton_Click12(object sender, EventArgs e)
    {
        CurrentStep = 12;
        // Your logic here
        DataBind();
    }
    protected void StepButton_Click13(object sender, EventArgs e)
    {
        CurrentStep = 13;
        // Your logic here
        DataBind();
    }
    public void checkPanel()
    {
        if (ViewState["CurrentStep"] != null)
        {
            if (Convert.ToString(ViewState["CurrentStep"]) == "1")
            {
                Page_Load(null, null);
            }
            else if (Convert.ToString(ViewState["CurrentStep"]) == "2")
            {
                lnkNextAddReq_Click(null, null);
            }
            else if (Convert.ToString(ViewState["CurrentStep"]) == "3")
            {
                lnkNextStage_Click(null, null);
            }
        }
    }
    #endregion Common End

    #region Start Add Orgainsation
    private void getOrg()
    {
        btnOrg(null, null);
        CurrentStep = 1;
        ViewState["CurrentStep"] = CurrentStep;
        DataBind();
        FillOrgDetails();
    }
    private void FillOrgDetails()
    {
        try
        {
            DataTable SD_Org = new FillSDFields().FillOrganization();
            ViewState["SD_Org"] = SD_Org;
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
            if (SD_Org.Rows.Count > 0 && SD_Org != null)
            {
                //GridFormat1(SD_Org);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
        }
    }
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
                            con.Close();
                            if (res > 0)
                            {
                                //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully !")}');", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}');", true);
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
        FillOrgDetails();
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
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}');", true);
                        FillOrgDetails();
                        cleardata();
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
        }
    }
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    /* Verifies that the control is rendered */
    //}
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
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}');", true);
                        FillOrgDetails();
                        cleardata();
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
        if (Session["UserScope"] != null)
        {
            CurrentStep = 2;
            ViewState["CurrentStep"] = CurrentStep;
            DataBind();
            cleardata();
            pnlReqType.Visible = true;
            pnlShowOrg.Visible = false;
            FillRequestTypeDetails();
            FillOrganization1();
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    }
    protected void GridFormat1(DataTable dt)

    {
        gvOrg.UseAccessibleHeader = true;
        gvOrg.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (gvOrg.TopPagerRow != null)
        {
            gvOrg.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvOrg.BottomPagerRow != null)
        {
            gvOrg.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvOrg.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    private void RegisterDataTableScripts()
    {
        string script = @"
        <script src='https://pcv-demo.hitachi-systems-mc.com:2020/assets/plugins/datatable/js/jquery.dataTables.min.js'></script>
        <script src='https://pcv-demo.hitachi-systems-mc.com:2020/assets/plugins/datatable/js/dataTables.bootstrap5.min.js'></script>
        <script src='https://pcv-demo.hitachi-systems-mc.com:2020/assets/js/jquery-3.6.0.min.js'></script>
        <script>
            $(document).ready(function () {
                $('.data-table').each(function () {
                    if ($.fn.DataTable.isDataTable(this)) {
                        $(this).DataTable().clear().destroy();
                    }
                    $(this).DataTable({
                        lengthChange: false,
                        dom: 'Bfrtip',
                        buttons: [
                            'copy', 'excel', 'pdf', 'print'
                        ]
                    });
                });
            });
        </script>
        <link href='https://pcv-demo.hitachi-systems-mc.com:2020/assets/plugins/datatable/css/dataTables.bootstrap5.min.css' rel='stylesheet' />
    ";

        ClientScript.RegisterStartupScript(this.GetType(), "DataTableScript", script, false);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
            //GridFormat2(SD_ReqType);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}');", true);
                        FillRequestTypeDetails();
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        cleardata();
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                            //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}');", true);
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}');", true);
                        FillRequestTypeDetails();
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        cleardata();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
            }
        }
    }
    protected void btnCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect("/DeskConfiguration.aspx");
    }
    protected void lnkPrevOrg_Click(object sender, EventArgs e)
    {
        stepper1trigger2.Enabled = true;
        pnlReqType.Visible = false;
        ViewState["CurrentStep"] = CurrentStep;
        DataBind();
        getOrg();
        cleardata();
    }
    protected void lnkNextStage_Click(object sender, EventArgs e)
    {
        cleardata();
        CurrentStep = 3;
        ViewState["CurrentStep"] = CurrentStep;
        DataBind();
        pnlReqType.Visible = false;
        pnlAddStage.Visible = true;
        FillOrganization();
        if (Session["UserScope"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["UserScope"].ToString().ToLower() == "admin" || Session["UserScope"].ToString().ToLower() == "technician")
        {
            FillStageDetailsCustomer(Session["OrgID"].ToString());
            ddlOrg.Enabled = false;
            ddlOrg.SelectedValue = Session["OrgID"].ToString();
        }
        else
        {
            ddlOrg.Enabled = true;
            FillStageDetails();
        }
    }
    protected void GridFormat2(DataTable dt)
    {
        gvReqType.UseAccessibleHeader = true;
        gvReqType.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (gvReqType.TopPagerRow != null)
        {
            gvReqType.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvReqType.BottomPagerRow != null)
        {
            gvReqType.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvReqType.FooterRow.TableSection = TableRowSection.TableFooter;
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
            if (SD_Stage.Rows.Count > 0)
            {
                //GridFormat3(SD_Stage);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void GridFormat3(DataTable dt)
    {
        gvStage.UseAccessibleHeader = true;
        gvStage.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (gvStage.TopPagerRow != null)
        {
            gvStage.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvStage.BottomPagerRow != null)
        {
            gvStage.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvStage.FooterRow.TableSection = TableRowSection.TableFooter;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
            //GridFormat3(SD_Stage);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
            //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}');", true);
            cleardata();
            FillStageDetails();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                                //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}');", true);
                                cleardata();
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}');", true);
                        FillStageDetails();
                        cleardata();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void lnkbtnPrevAddReq_Click(object sender, EventArgs e)
    {
        CurrentStep = 2;
        ViewState["CurrentStep"] = CurrentStep;
        DataBind();
        cleardata(); pnlReqType.Visible = true;
        pnlAddStage.Visible = false;
        lnkNextAddReq_Click(null, null);
    }
    protected void lnkbtnNextStatus_Click(object sender, EventArgs e)
    {
        if (Session["UserScope"] != null)
        {
            CurrentStep = 4;
            ViewState["CurrentStep"] = CurrentStep;
            DataBind();
            cleardata();
            FillStatusDetails();
            FillOrganizationStatus();
            pnlStatus.Visible = true;
            pnlAddStage.Visible = false;
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    #endregion Stage End

    #region Add Status Start 
    protected void GridFormat4(DataTable dt)
    {
        gvStatus.UseAccessibleHeader = true;
        gvStatus.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (gvStatus.TopPagerRow != null)
        {
            gvStatus.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvStatus.BottomPagerRow != null)
        {
            gvStatus.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvStatus.FooterRow.TableSection = TableRowSection.TableFooter;
    }
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
            //GridFormat4(SD_Status);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ddlRequestTypeStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SDRef"] = ddlRequestTypeStatus.SelectedValue.ToString();
        FillStage();
        FillStatusDetails();
    }
    private void FillStage()
    {
        try
        {
            DataTable SD_Priority = new SDTemplateFileds().FillStage(ddlRequestTypeStatus.SelectedValue, ddlOrg3.SelectedValue); ;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
            cleardata();
            FillStatusDetails();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                                cleardata();
                                FillSeverityDetails();
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                    FillRequestTypeStatus(Convert.ToInt64(OrgID.Text));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                    cmd.Parameters.AddWithValue("@Option", "UpdateStatus");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        DataTableScript();
                        lnkbtnNextStatus_Click(null, null);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
        FillStatusDetails();
    }
    protected void lnkPrevStage_Click(object sender, EventArgs e)
    {
        pnlAddStage.Visible = true;
        pnlStatus.Visible = false;
        CurrentStep = 3;
        ViewState["CurrentStep"] = CurrentStep;
        cleardata();
        DataBind();
        lnkNextStage_Click(null, null);
    }
    protected void lnkNextSeverity_Click(object sender, EventArgs e)
    {
        cleardata();
        CurrentStep = 5;
        DataBind();
        ViewState["CurrentStep"] = CurrentStep;
        FillOrganizationSeverity();
        if (Session["UserScope"].ToString().ToLower() == "admin")
        {
            FillSeverityDetailsWithCustomer();
            ddlOrg4.Enabled = false;
            ddlOrg4.SelectedValue = Session["OrgId"].ToString();
        }
        else
        {
            ddlOrg4.Enabled = true;
            FillSeverityDetails();
        }
        pnlAddSeverity.Visible = true;
        pnlStatus.Visible = false;
    }
    #endregion Add Status End 

    #region Add Severity Start
    protected void GridFormat5(DataTable dt)
    {
        gvSeverity.UseAccessibleHeader = true;
        gvSeverity.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (gvSeverity.TopPagerRow != null)
        {
            gvSeverity.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvSeverity.BottomPagerRow != null)
        {
            gvSeverity.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvSeverity.FooterRow.TableSection = TableRowSection.TableFooter;
    }
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
            //GridFormat5(SD_Severity);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
            //GridFormat5(SD_Severity);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ddlRequestTypeSeverity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SDRef"] = ddlRequestTypeSeverity.SelectedValue.ToString();
        FillStatusDetails();

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}');", true);
                        cleardata();
                        FillSeverityDetails();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                                cleardata();
                                FillSeverityDetails();
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                    FillRequestTypeSeverity(Convert.ToInt32(OrgID.Text));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}');", true);
                        cleardata();
                        FillSeverityDetails();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void lnkPrevStatus_Click(object sender, EventArgs e)
    {
        CurrentStep = 4;
        ViewState["CurrentStep"] = CurrentStep;
        DataBind();
        cleardata();
        lnkbtnNextStatus_Click(null, null);
        pnlAddSeverity.Visible = false;
    }
    protected void lnkNextPriority_Click(object sender, EventArgs e)
    {
        CurrentStep = 6;
        DataBind();
        ViewState["CurrentStep"] = CurrentStep;
        cleardata();
        if (Session["UserScope"].ToString().ToLower() == "admin")
        {
            FillPriorityDetailsCustomer();
            ddlOrg5.Enabled = false;
            ddlOrg5.SelectedValue = Session["OrgID"].ToString();
        }
        else
        {
            ddlOrg5.Enabled = true;
            FillPriorityDetails();
        }
        pnlAddPriority.Visible = true;
        pnlAddSeverity.Visible = false;
        FillOrganizationPriority();

    }
    #endregion Add Severity End

    #region Add Priority Start
    protected void GridFormat6(DataTable dt)
    {
        gvPriority.UseAccessibleHeader = true;
        gvPriority.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (gvPriority.TopPagerRow != null)
        {
            gvPriority.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvPriority.BottomPagerRow != null)
        {
            gvPriority.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvPriority.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    private void FillPriorityDetailsCustomer()
    {
        try
        {
            DataTable SD_Priority = new FillSDFields().FillPriorityWithCustomer(Session["OrgID"].ToString());
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
            if (SD_Priority.Rows.Count > 0) { }
                //GridFormat6(SD_Priority);
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
            //GridFormat6(SD_Priority);
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                                //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}');", true);
                                lnkNextPriority_Click(null, null);
                                cleardata();
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrg5.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "AddPriority");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        lnkNextPriority_Click(null, null);
                        cleardata();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        lnkNextPriority_Click(null, null);
                        cleardata();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
        }
    }
    protected void lnkPreviousSeverity_Click(object sender, EventArgs e)
    {
        cleardata();
        CurrentStep = 5;
        DataBind();
        lnkNextSeverity_Click(null, null);
        pnlAddPriority.Visible = false;
    }
    protected void lnkNextCategory_Click(object sender, EventArgs e)
    {
        CurrentStep = 7;
        ViewState["CurrentStep"] = CurrentStep;
        cleardata();
        pnlCategory.Visible = true;
        pnlAddPriority.Visible = false;
        FillOrganizationCategory();
        if (Session["UserScope"].ToString().ToLower() == "admin")
        {
            ddlOrg6.Enabled = false;
            ddlOrg6.SelectedValue = Session["OrgID"].ToString();
            FillRequestTypeCategory(Convert.ToInt64(Session["OrgID"].ToString()));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
            }
        }
    }
    protected void ddlOrg6_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRequestTypeCategory(Convert.ToInt64(ddlOrg6.SelectedValue));
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
        DataBind();
        ViewState["CurrentStep"] = CurrentStep;
        cleardata();
        lnkNextPriority_Click(null, null);
        pnlAddPriority.Visible = true;
        pnlCategory.Visible = false;

    }
    protected void lnkNextEmailConfig_Click(object sender, EventArgs e)
    {
        pnlAddResolution.Visible = true;
        pnlCategory.Visible = false;
        CurrentStep = 8;
        DataBind();
        ViewState["CurrentStep"] = CurrentStep;
        if (Session["UserScope"] != null)
        {
            FillOrganizationResolution();
            if (Session["UserScope"].ToString().ToLower() == "admin")
            {
                FillResolutionDetailsCustomer();
                ddlOrgResolution.Enabled = false;
                ddlOrgResolution.SelectedValue = Session["OrgID"].ToString();
                ddlOrgResolution.Items.FindByValue(Session["OrgID"].ToString()).Selected = true;
                ddlOrgResolution_SelectedIndexChanged(sender, e);
            }
            else
            {
                ddlOrg.Enabled = true;

                FillResolutionDetails();
            }
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    }
    #endregion Add Category End

    #region Resolution Add
    protected void GridFormat8(DataTable dt)
    {
        gvResolution.UseAccessibleHeader = true;
        gvResolution.HeaderRow.TableSection = TableRowSection.TableHeader;
        if (gvResolution.TopPagerRow != null)
        {
            gvResolution.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvResolution.BottomPagerRow != null)
        {
            gvResolution.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvResolution.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    private void FillResolutionDetailsCustomer()
    {
        try
        {
            DataTable SD_Resolution = new FillSDFields().FillResolutionCustomer(Session["OrgID"].ToString());
            if (SD_Resolution.Rows.Count > 0)
            {
                this.gvResolution.DataSource = (object)SD_Resolution;
                this.gvResolution.DataBind();
            }
            else
            {
                this.gvResolution.DataSource = (object)null;
                this.gvResolution.DataBind();
            }
            //GridFormat8(SD_Resolution);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillOrganizationResolution()
    {

        try
        {

            DataTable SD_Org = new FillSDFields().FillOrganization(); ;

            ddlOrgResolution.DataSource = SD_Org;
            ddlOrgResolution.DataTextField = "OrgName";
            ddlOrgResolution.DataValueField = "Org_ID";
            ddlOrgResolution.DataBind();
            ddlOrgResolution.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));


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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillResolutionDetails()
    {
        try
        {

            DataTable SD_Resolution = new FillSDFields().FillResolution(); ;

            if (SD_Resolution.Rows.Count > 0)
            {
                //  this.lb.Text = dataTable.Rows.Count.ToString();
                this.gvResolution.DataSource = (object)SD_Resolution;
                this.gvResolution.DataBind();
            }
            else
            {
                this.gvResolution.DataSource = (object)null;
                this.gvResolution.DataBind();
            }
            //GridFormat8(SD_Resolution);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
            }
        }
    }
    protected void ddlRequestTypeResolution_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SDRef"] = ddlRequestTypeResolution.SelectedValue.ToString();
    }
    private void FillRequestTypeResolution(long OrgId)
    {
        try
        {
            DataTable RequestType = new SDTemplateFileds().FillRequestType(OrgId);
            ddlRequestTypeResolution.DataSource = RequestType;
            ddlRequestTypeResolution.DataTextField = "ReqTypeRef";
            ddlRequestTypeResolution.DataValueField = "ReqTypeRef";
            ddlRequestTypeResolution.DataBind();
            ddlRequestTypeResolution.Items.Insert(0, new ListItem("----------Select RequestType----------", "0"));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ImgBtnExport9_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvResolution.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvResolution.Rows)
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
                Response.AddHeader("content-disposition", "attachment;filename=ResolutionType.xlsx");
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void gvResolution_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEx")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                string ResolutionRef = gvResolution.DataKeys[rowIndex].Values["ResolutionRef"].ToString();
                string Deskref = gvResolution.Rows[rowIndex].Cells[1].Text;
                string ResolutionName = gvResolution.Rows[rowIndex].Cells[2].Text;
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spAddResolution", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ResolutionRef", ResolutionRef);
                            cmd.Parameters.AddWithValue("@DeskRef", Deskref);
                            cmd.Parameters.AddWithValue("@Option", "DeleteResolution");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}');", true);
                                lnkNextResolution_Click(null, null);
                            }
                            con.Close();
                            FillResolutionDetails();
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

                    }
                }

            }
            if (e.CommandName == "SelectState")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvResolution.Rows[rowIndex];
                //Get the value of column from the DataKeys using the RowIndex.
                string ResolutionRef = gvResolution.DataKeys[rowIndex].Values["ResolutionRef"].ToString();
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrgResolution.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrgResolution.SelectedValue = OrgID.Text;
                    FillRequestTypeResolution(Convert.ToInt64(OrgID.Text));
                }
                ddlRequestTypeResolution.SelectedValue = gvResolution.Rows[rowIndex].Cells[1].Text;
                txtResolution.Text = gvResolution.Rows[rowIndex].Cells[2].Text;
                txtResolutnDesc.Text = gvResolution.Rows[rowIndex].Cells[3].Text;

                btnInsertResolution.Visible = false;
                btnUpdateResolution.Visible = true;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void SaveDataResolution()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spAddResolution", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestTypeResolution.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@ResolutionRef", ddlRequestTypeResolution.SelectedItem.Text.Trim() + "||" + txtResolution.Text.Trim());
                    cmd.Parameters.AddWithValue("@ResolutionCodeRef", txtResolution.Text.Trim());
                    cmd.Parameters.AddWithValue("@ResolutionDesc", txtResolutnDesc.Text);
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrgResolution.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "AddResolution");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}');", true);
                        lnkNextResolution_Click(null,null);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnInsertResolution_Click(object sender, EventArgs e)
    {
        SaveDataResolution();
    }
    protected void gvResolution_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void btnUpdateResolution_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddResolution", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestTypeResolution.SelectedValue);
                    cmd.Parameters.AddWithValue("@ResolutionRef", ddlRequestTypeResolution.SelectedValue.ToString().Trim() + "||" + txtResolution.Text.Trim());
                    cmd.Parameters.AddWithValue("@ResolutionCodeRef", txtResolution.Text.Trim());
                    cmd.Parameters.AddWithValue("@ResolutionDesc", txtResolutnDesc.Text);
                    cmd.Parameters.AddWithValue("@OrgDeskRef", ddlOrgResolution.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "UpdateResolution");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}');", true);
                        lnkNextResolution_Click(null, null);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnCancel9_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void LoadOrgControl()
    {
        try
        {
            // pnlShowRqstType.Controls.Clear();
            System.Web.UI.Control featuredProduct = Page.LoadControl("/HelpDesk/UserControlOrg.ascx");
            featuredProduct.ID = "12321";
            pnlShowOrg.Controls.Add(featuredProduct);
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
        }
    }
    protected void ddlOrgResolution_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillRequestTypeResolution(Convert.ToInt64(ddlOrgResolution.SelectedValue));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void lnkPreviousEmailConfig_Click(object sender, EventArgs e)
    {
        pnlAddResolution.Visible = false;
        lnkNextCategory_Click(null, null);
    }
    protected void lnkNextSLA_Click(object sender, EventArgs e)
    {
        CurrentStep = 9;
        ViewState["CurrentStep"] = CurrentStep;
        DataBind();
        pnlAddSLA.Visible = true;
        pnlAddResolution.Visible = false;
        if (Session["UserScope"] != null)
        {
            FillSLADetails();
            FillOrganizationSLA();
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    }
    #endregion Resolution End

    #region Add SLA Start
    private void FillOrganizationSLA()
    {
        try
        {
            DataTable SD_Org = new FillSDFields().FillOrganization();
            ddlOrgSLA.DataSource = SD_Org;
            ddlOrgSLA.DataTextField = "OrgName";
            ddlOrgSLA.DataValueField = "Org_ID";
            ddlOrgSLA.DataBind();
            ddlOrgSLA.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
            }
        }
    }
    private void FillSLADetails()
    {

        try
        {

            DataTable SD_SLA = new FillSDFields().FillUserSLAdetails(); ;

            if (SD_SLA.Rows.Count > 0)
            {
                //  this.lb.Text = dataTable.Rows.Count.ToString();
                this.gvSLA.DataSource = (object)SD_SLA;
                this.gvSLA.DataBind();
            }
            else
            {
                this.gvSLA.DataSource = (object)null;
                this.gvSLA.DataBind();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ImgBtnExport10_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvSLA.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvSLA.Rows)
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
                Response.AddHeader("content-disposition", "attachment;filename=SLA.xlsx");
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    static long SLAID;
    protected void gvSLA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteSLA")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                SLAID = Convert.ToInt32(gvSLA.DataKeys[rowIndex].Values["ID"]);

                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spAddDeskSLA", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", SLAID);
                            cmd.Parameters.AddWithValue("@Option", "DeleteDeskSLA");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                                lnkNextResolution_Click(null, null);
                            }
                            con.Close();
                            FillSLADetails();

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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
                    }
                }
            }

            if (e.CommandName == "UpdateSLA")
            {
                btnInsertSLA.Visible = false;
                btnUpdateSLA.Visible = true;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvSLA.Rows[rowIndex];
                SLAID = Convert.ToInt32(gvSLA.DataKeys[rowIndex].Values["ID"]);
                txtSLAName.Text = gvSLA.Rows[rowIndex].Cells[1].Text;
                txtSLADescription.Text = gvSLA.Rows[rowIndex].Cells[2].Text;
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrgSLA.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrgSLA.SelectedValue = OrgID.Text;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void SaveDataSLA()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spAddDeskSLA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@SlaName", txtSLAName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SLADesc", txtSLADescription.Text);
                    cmd.Parameters.AddWithValue("@OrgID", ddlOrgSLA.SelectedValue);
                    cmd.Parameters.AddWithValue("@Option", "AddDeskSLA");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        lnkNextSLA_Click(null, null);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void gvSLA_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[3].Visible = true;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnInsertSLA_Click(object sender, EventArgs e)
    {
        SaveDataSLA();
    }
    protected void btnUpdateSLA_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddDeskSLA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", SLAID);
                    cmd.Parameters.AddWithValue("@SlaName", txtSLAName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SLADesc", txtSLADescription.Text);
                    cmd.Parameters.AddWithValue("@OrgID", ddlOrgSLA.SelectedValue);
                    cmd.Parameters.AddWithValue("@Option", "UpdateDeskSLA");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}');", true);
                        lnkNextResolution_Click(null, null);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnCancel10_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void lnkPreviousResolution_Click(object sender, EventArgs e)
    {
        pnlAddSLA.Visible = false;
        lnkNextEmailConfig_Click(null, null);
    }
    protected void lnkNextDeskConfig_Click(object sender, EventArgs e)
    {
        pnlAdddeskConfig.Visible = true;
        pnlAddSLA.Visible = false;
        CurrentStep = 10;
        DataBind();
        pnlAddEmailConfig.Visible = false;
        pnlAdddeskConfig.Visible = true;
        if (Session["UserScope"] != null)
        {
            FillSLA();
            FillCoverageSchedule();
            FillSDDetails();
            FillOrganizationDeskConfig();
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    }
    #endregion Add SLA End

    #region Add Desk Config Start
    private void FillSDDetails()
    {

        try
        {
            DataTable SD_Desk = new FillSDFields().FillSDDetails();
            if (SD_Desk.Rows.Count > 0)
            {
                //  this.lb.Text = dataTable.Rows.Count.ToString();
                this.gvDesk.DataSource = (object)SD_Desk;
                this.gvDesk.DataBind();
            }
            else
            {
                this.gvDesk.DataSource = (object)null;
                this.gvDesk.DataBind();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillRequestTypeDeskConfig(long OrgID)
    {

        try
        {

            DataTable RequestType = new SDTemplateFileds().FillRequestType(OrgID);

            ddlRequestTypeDeskConfig.DataSource = RequestType;
            ddlRequestTypeDeskConfig.DataTextField = "ReqTypeRef";
            ddlRequestTypeDeskConfig.DataValueField = "ReqTypeRef";
            ddlRequestTypeDeskConfig.DataBind();
            ddlRequestTypeDeskConfig.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select RequestType----------", "0"));


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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillSeverity()
    {

        try
        {

            DataTable SD_Severity = new SDTemplateFileds().FillSeverity(Session["SDRef"].ToString(), ddlOrgDeskConfig.SelectedValue.ToString()); ;

            ddlSeverity.DataSource = SD_Severity;
            ddlSeverity.DataTextField = "Serveritycoderef";
            ddlSeverity.DataValueField = "id";
            ddlSeverity.DataBind();
            ddlSeverity.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Severity----------", "0"));


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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillSLA()
    {

        try
        {

            DataTable SD_SLA = new FillSDFields().FillUserSLAdetails(); ;

            ddlSlA.DataSource = SD_SLA;
            ddlSlA.DataTextField = "SlaName";
            ddlSlA.DataValueField = "ID";
            ddlSlA.DataBind();
            ddlSlA.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select SLA----------", "0"));


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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillCoverageSchedule()
    {

        try
        {

            DataTable SD_Doverage = new FillSDFields().FillCoverageSchdetails(); ;

            ddlCoverageSch.DataSource = SD_Doverage;
            ddlCoverageSch.DataTextField = "ScdhuleName";
            ddlCoverageSch.DataValueField = "ID";
            ddlCoverageSch.DataBind();
            ddlCoverageSch.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Coverage----------", "0"));

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillOrganizationDeskConfig()
    {

        try
        {

            DataTable SD_Org = new FillSDFields().FillOrganization();
            ddlOrgDeskConfig.DataSource = SD_Org;
            ddlOrgDeskConfig.DataTextField = "OrgName";
            ddlOrgDeskConfig.DataValueField = "Org_ID";
            ddlOrgDeskConfig.DataBind();
            ddlOrgDeskConfig.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));


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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillSolution()
    {

        try
        {

            DataTable SD_Priority = new SDTemplateFileds().FillSolutiontype(Session["SDRef"].ToString()); ;

            ddlSolutionType.DataSource = SD_Priority;
            ddlSolutionType.DataTextField = "ResolutionCodeRef";
            ddlSolutionType.DataValueField = "id";
            ddlSolutionType.DataBind();
            ddlSolutionType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Solution----------", "0"));


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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillPriority()
    {

        try
        {

            DataTable SD_Priority = new SDTemplateFileds().FillPriority(Session["SDRef"].ToString(), ddlOrgDeskConfig.SelectedValue.ToString()); ;

            ddlPriority.DataSource = SD_Priority;
            ddlPriority.DataTextField = "PriorityCodeRef";
            ddlPriority.DataValueField = "id";
            ddlPriority.DataBind();
            ddlPriority.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Priority----------", "0"));

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillStatus()
    {

        try
        {

            DataTable SD_Status = new SDTemplateFileds().FillStatus(Session["SDRef"].ToString(), ddlStageDeskConfig.SelectedValue.ToString(), ddlOrgDeskConfig.SelectedValue.ToString());

            ddlStatus.DataSource = SD_Status;
            ddlStatus.DataTextField = "StatusCodeRef";
            ddlStatus.DataValueField = "id";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Status----------", "0"));


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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillStageDeskConfig()
    {

        try
        {

            DataTable SD_Status = new SDTemplateFileds().FillStage(Session["SDRef"].ToString(), ddlOrgDeskConfig.SelectedValue.ToString());
            ddlStageDeskConfig.DataSource = SD_Status;
            ddlStageDeskConfig.DataTextField = "StageCodeRef";
            ddlStageDeskConfig.DataValueField = "id";
            ddlStageDeskConfig.DataBind();
            ddlStageDeskConfig.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Stage----------", "0"));


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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
           Categoryref FROM [dbo].fnGetCategoryFullPathForDesk('" + ddlRequestTypeDeskConfig.SelectedValue + "','" + ddlOrgDeskConfig.SelectedValue + "', 1) where Level=1   order by Categoryref asc", con))
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
                                ddlCategory1.Items.Insert(0, new ListItem("----------Select Category----------", "0"));
                            }

                        }
                    }
                }
            }
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private DataTable FillCategoryLevelDeskConfig(string category, int categoryLevel)
    {
        try
        {
            DataTable dtFillCategory = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM [dbo].[fn_GetCategoryChildrenByRef]('" + ddlCategory1.SelectedValue + "', 1,'" + ddlOrg.SelectedValue + "') where level='" + categoryLevel + "'  order by Categoryref asc", con))
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
            return null;
        }
    }
    protected void ddlCategory1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hdnCategoryID.Value = ddlCategory1.SelectedValue.ToString();

            DataTable FillCategoryLevel2 = new DataTable();
            FillCategoryLevel2 = FillCategoryLevel(ddlCategory1.SelectedValue, 2);
            if (FillCategoryLevel2.Rows.Count > 0)
            {
                ddlCategory2.DataSource = FillCategoryLevel2;
                ddlCategory2.DataTextField = "CategoryCodeRef";
                ddlCategory2.DataValueField = "Categoryref";
                ddlCategory2.DataBind();
                ddlCategory2.Items.Insert(0, new ListItem("----------Select Category Level 2----------", "0"));

                lblCategory2.Visible = true;
                ddlCategory2.Visible = true;
                ddlCategory2.Enabled = true;
            }
            else
            {
                ddlCategory2.ClearSelection();
                lblCategory2.Visible = false;
                ddlCategory2.Visible = false;
                ddlCategory2.Enabled = false;
                ddlCategory3.Enabled = false;
                ddlCategory3.ClearSelection();
                ddlCategory4.Enabled = false;
                ddlCategory4.ClearSelection();
                ddlCategory5.Enabled = false;
                ddlCategory5.ClearSelection();
                FillCategoryLevel2 = null;
                //ddlCatII.DataSource = null;
                //  ddlCatII.DataBind();
                // ddlCatII.Items.Insert(0, new ListItem("----------Select Category Level 2----------", "0"));
            }
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ddlCategory2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hdnCategoryID.Value = ddlCategory2.SelectedValue.ToString();
            DataTable FillCategoryLevel3 = FillCategoryLevel(ddlCategory1.SelectedValue, 3);
            if (FillCategoryLevel3.Rows.Count > 0)
            {
                lblCategory3.Visible = true;
                ddlCategory3.Visible = true;
                ddlCategory3.Enabled = true;
                ddlCategory3.DataSource = FillCategoryLevel3;
                ddlCategory3.DataTextField = "CategoryCodeRef";
                ddlCategory3.DataValueField = "Categoryref";
                ddlCategory3.DataBind();
                ddlCategory3.Items.Insert(0, new ListItem("----------Select Category Level 3----------", "0"));

            }
            else
            {
                ddlCategory3.ClearSelection();
                //ddlCategory3.Enabled = false;
                lblCategory3.Visible = false;
                ddlCategory3.Visible = false;
                ddlCategory3.DataSource = null;
                ddlCategory3.DataBind();
                ddlCategory4.ClearSelection();
                ddlCategory4.Enabled = false;
                ddlCategory4.Visible = false;
                lblCategory4.Visible = false;
                ddlCategory5.ClearSelection();
                ddlCategory5.Enabled = false;
                ddlCategory5.Visible = false;
                lblCategory5.Visible = false;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ddlCategory3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hdnCategoryID.Value = ddlCategory3.SelectedValue.ToString();
            DataTable FillCategoryLevel4 = FillCategoryLevel(ddlCategory1.SelectedValue, 4);
            if (FillCategoryLevel4.Rows.Count > 0)
            {
                ddlCategory4.DataSource = FillCategoryLevel4;
                ddlCategory4.DataTextField = "CategoryCodeRef";
                ddlCategory4.DataValueField = "Categoryref";
                ddlCategory4.DataBind();
                ddlCategory4.Items.Insert(0, new ListItem("----------Select Category Level 4----------", "0"));
                ddlCategory4.Enabled = true;
                ddlCategory4.Visible = true;
                lblCategory4.Visible = true;
            }
            else
            {
                ddlCategory4.DataSource = null;
                ddlCategory4.DataBind();

                ddlCategory4.ClearSelection();
                ddlCategory4.Enabled = false;
                ddlCategory4.Visible = false;
                lblCategory4.Visible = false;
                ddlCategory5.ClearSelection();
                ddlCategory5.Enabled = false;
                ddlCategory5.Visible = false;
                lblCategory5.Visible = false;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ddlCategory4_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            hdnCategoryID.Value = ddlCategory4.SelectedValue.ToString();
            DataTable FillCategoryLevel4 = FillCategoryLevel(ddlCategory1.SelectedValue, 5);
            if (FillCategoryLevel4.Rows.Count > 0)
            {
                ddlCategory5.DataSource = FillCategoryLevel4;
                ddlCategory5.DataTextField = "CategoryCodeRef";
                ddlCategory5.DataValueField = "Categoryref";
                ddlCategory5.DataBind();
                ddlCategory5.Items.Insert(0, new ListItem("----------Select Category Level 4----------", "0"));
                ddlCategory5.Enabled = true;
            }
            else
            {
                ddlCategory5.DataSource = null;
                ddlCategory5.DataBind();

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ddlCategory2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Category Level 2----------", "0"));
            }
            else
            {
                ddlCategory2.ClearSelection();
                ddlCategory2.Enabled = false;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ddlCategory3.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Category Level 3----------", "0"));
            }
            else
            {
                ddlCategory3.ClearSelection();
                //ddlCategory3.Enabled = false;
                ddlCategory3.DataSource = null;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ddlCategory4.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Category Level 4----------", "0"));
            }
            else
            {
                ddlCategory4.DataSource = null;
                ddlCategory4.DataBind();

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

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
                ddlCategory5.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Category Level 5----------", "0"));
            }
            else
            {
                ddlCategory5.DataSource = null;
                ddlCategory5.DataBind();

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }

        }
    }
    private DataTable FillCategoryLevel(int categoryLevel)
    {
        try
        {
            DataTable dtFillCategory = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM [dbo].[fn_GetCategoryChildrenByRef]('" + ddlCategory1.SelectedValue + "', 1,'" + ddlOrgDeskConfig.SelectedValue + "') where level='" + categoryLevel + "'  order by Categoryref asc", con))
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }

            return null;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spServDeskDefn", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestTypeDeskConfig.SelectedValue);
                    cmd.Parameters.AddWithValue("@DeskDesc", txtSDDescription.Text);
                    cmd.Parameters.AddWithValue("@sdPrefix", txtSDPrefix.Text);
                    cmd.Parameters.AddWithValue("@sdStageFK", ddlStageDeskConfig.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdStatusFK", ddlStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdSeverityFK", ddlSeverity.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdPriorityFK", ddlPriority.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdSolutionTypeFK", ddlSolutionType.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdCategoryRef", hdnCategoryID.Value);
                    cmd.Parameters.AddWithValue("@OrgFk", ddlOrgDeskConfig.SelectedValue);
                    cmd.Parameters.AddWithValue("@SLA", ddlSlA.SelectedValue);
                    cmd.Parameters.AddWithValue("@CoverageSch", ddlCoverageSch.SelectedValue);
                    cmd.Parameters.AddWithValue("@autoArchiveTime", txtArchiveTime.Text);
                    cmd.Parameters.AddWithValue("@Option", "UpdateServDeskDefn");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        //Session["Popup"] = "Insert";
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}');", true);
                        lnkNextDeskConfig_Click(null, null);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spServDeskDefn", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@DeskRef", ddlRequestTypeDeskConfig.SelectedValue);
                    cmd.Parameters.AddWithValue("@DeskDesc", txtSDDescription.Text);
                    cmd.Parameters.AddWithValue("@sdPrefix", txtSDPrefix.Text);
                    cmd.Parameters.AddWithValue("@sdStageFK", ddlStageDeskConfig.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdStatusFK", ddlStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdPriorityFK", ddlPriority.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdSolutionTypeFK", ddlSolutionType.SelectedValue);
                    cmd.Parameters.AddWithValue("@sdCategoryRef", hdnCategoryID.Value);
                    cmd.Parameters.AddWithValue("@templateName", "Hitachi " + ddlRequestTypeDeskConfig.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@sdSeverityFK", ddlSeverity.SelectedValue);
                    //cmd.Parameters.AddWithValue("@sdRolePermissionFK", ddlSeverity.SelectedValue);
                    cmd.Parameters.AddWithValue("@autoArchiveTime", txtArchiveTime.Text);
                    cmd.Parameters.AddWithValue("@SLA", ddlSlA.SelectedValue);
                    cmd.Parameters.AddWithValue("@CoverageSch", ddlCoverageSch.SelectedValue);
                    cmd.Parameters.AddWithValue("@OrgFk", ddlOrgDeskConfig.SelectedValue);
                    cmd.Parameters.AddWithValue("@Option", "AddServDeskDefn");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}');", true);
                        lnkNextDeskConfig_Click(null, null);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ddlRequestTypeDeskConfig_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["SDRef"] = ddlRequestTypeDeskConfig.SelectedValue.ToString();
            FillSeverity();

            FillStageDeskConfig();
            FillPriority();
            FillCategory1();
            FillSolution();

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnClose11_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void gvDesk_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEx")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                ID = Convert.ToInt32(gvDesk.DataKeys[rowIndex].Values["ID"]);
                string Deskref = gvDesk.Rows[rowIndex].Cells[1].Text;
                string PriorityName = gvDesk.Rows[rowIndex].Cells[2].Text;
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spServDeskDefn", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", ID);

                            cmd.Parameters.AddWithValue("@Option", "DeleteServDeskDefn");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                //Session["Popup"] = "Delete";
                                //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}');", true);
                                lnkNextDeskConfig_Click(null, null);
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

                    }
                }

            }
            if (e.CommandName == "EditDesk")
            {
                long CategoryFk;
                btnInsert.Visible = false;
                btnUpdate.Visible = true;
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvDesk.Rows[rowIndex];
                //Get the value of column from the DataKeys using the RowIndex.
                ID = Convert.ToInt32(gvDesk.DataKeys[rowIndex].Values["ID"]);
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrgDeskConfig.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrgDeskConfig.SelectedValue = OrgID.Text;
                    FillRequestTypeDeskConfig(Convert.ToInt64(OrgID.Text));
                    ddlRequestTypeDeskConfig.SelectedValue = gvDesk.Rows[rowIndex].Cells[4].Text;
                    ddlRequestTypeDeskConfig.Items.FindByText(ddlRequestTypeDeskConfig.SelectedValue).Selected = true;
                    ddlRequestTypeDeskConfig_SelectedIndexChanged(sender, e);
                }

                txtSDPrefix.Text = gvDesk.Rows[rowIndex].Cells[5].Text;
                txtSDDescription.Text = gvDesk.Rows[rowIndex].Cells[6].Text;
                txtArchiveTime.Text = gvDesk.Rows[rowIndex].Cells[13].Text;
                Label Priority = (row.FindControl("lblSDPriorityFk") as Label);
                Label Category = (row.FindControl("lblSDCategoryFk") as Label);
                if (string.IsNullOrEmpty(Category.Text.ToString()))
                {
                }
                else
                {
                    CategoryFk = Convert.ToInt64((Convert.ToString(Category.Text.ToString())));
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
                    }
                }
                if (ddlPriority.Items.FindByValue(Priority.Text.ToString().Trim()) != null)
                {
                    ddlPriority.SelectedValue = Priority.Text;
                }
                Label Stage = (row.FindControl("lblSDStageFk") as Label);
                if (ddlStageDeskConfig.Items.FindByValue(Stage.Text.ToString().Trim()) != null)
                {
                    ddlStageDeskConfig.SelectedValue = Stage.Text;
                }
                FillStatus();
                Label Status = (row.FindControl("lblSDStatusFk") as Label);
                if (ddlStatus.Items.FindByValue(Status.Text.ToString().Trim()) != null)
                {
                    ddlStatus.SelectedValue = Status.Text;
                }
                Label severity = (row.FindControl("lblSDSeverityFk") as Label);
                if (ddlSeverity.Items.FindByValue(severity.Text.ToString().Trim()) != null)
                {
                    ddlSeverity.SelectedValue = severity.Text;
                }
                Label solution = (row.FindControl("lblsdSolutionTypeFK") as Label);
                if (ddlSolutionType.Items.FindByValue(solution.Text.ToString().Trim()) != null)
                {
                    ddlSolutionType.SelectedValue = solution.Text;
                }

                Label lblSLAid = (row.FindControl("lblSLAid") as Label);
                if (ddlSlA.Items.FindByValue(lblSLAid.Text.ToString().Trim()) != null)
                {
                    ddlSlA.SelectedValue = lblSLAid.Text;
                }
                Label CvrgID = (row.FindControl("lblCvrgID") as Label);
                if (ddlCoverageSch.Items.FindByValue(CvrgID.Text.ToString().Trim()) != null)
                {
                    ddlCoverageSch.SelectedValue = CvrgID.Text;
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
        }
    }
    protected void btnCancel11_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void gvDesk_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (Session["UserScope"].ToString() == "Master")
            {
                e.Row.Cells[0].Visible = true;
                e.Row.Cells[1].Visible = true;
            }

            if (Session["UserScope"].ToString() == "Technician" || Session["UserScope"].ToString() == "Admin")
            {
                e.Row.Cells[0].Visible = true;
                e.Row.Cells[1].Visible = false;

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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ImgBtnExport12_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvDesk.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvDesk.Rows)
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
                Response.AddHeader("content-disposition", "attachment;filename=DeskDetail.xlsx");
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ClearFields()
    {
        try
        {
            ddlRequestType.ClearSelection();
            txtArchiveTime.Text = "";
            txtSDDescription.Text = "";
            txtSDPrefix.Text = "";
            ddlSeverity.ClearSelection();
            ddlPriority.ClearSelection();
            ddlSolutionType.ClearSelection();
            ddlStatus.ClearSelection();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }

    }
    protected void ddlOrgDeskConfig_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillRequestTypeDeskConfig(Convert.ToInt64(ddlOrgDeskConfig.SelectedValue));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ddlStageDeskConfig_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStatus();
    }
    protected void lnkNextCustomFields_Click(object sender, EventArgs e)
    {
        pnlAddEmailConfig.Visible = true;
        pnlAdddeskConfig.Visible = false;
        CurrentStep = 11;
        DataBind();
        ViewState["CurrentStep"] = CurrentStep;
        if (Session["UserScope"] != null)
        {
            FillEmailConfigDetails();
            FillOrganizationEmailConfig();
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        
    }
    protected void lnkPreviousSLA_Click(object sender, EventArgs e)
    {
        pnlAddSLA.Visible = true;
        pnlAdddeskConfig.Visible = false;
        lnkNextSLA_Click(null, null);
    }
    #endregion Add Desk Config End

    #region Add Custom Fields
    //private void FillSDCustomFieldsCustomer()
    //{
    //    try
    //    {
    //        DataTable SD_SDCustomFields = new FillSDFields().FillSDCustomFieldsCustomer(Session["OrgID"].ToString());
    //        if (SD_SDCustomFields.Rows.Count > 0)
    //        {
    //            this.gvSDCustomFields.DataSource = (object)SD_SDCustomFields;
    //            this.gvSDCustomFields.DataBind();
    //        }
    //        else
    //        {
    //            this.gvSDCustomFields.DataSource = (object)null;
    //            this.gvSDCustomFields.DataBind();
    //        }


    //    }
    //    catch (ThreadAbortException e2)
    //    {
    //        Console.WriteLine("Exception message: {0}", e2.Message);
    //        Thread.ResetAbort();
    //    }

    //    catch (Exception ex)
    //    {
    //        if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
    //        {

    //        }
    //        else
    //        {
    //            var st = new StackTrace(ex, true);
    //            // Get the top stack frame
    //            var frame = st.GetFrame(0);
    //            // Get the line number from the stack frame
    //            var line = frame.GetFileLineNumber();
    //            inEr.InsertErrorLogsF(Session["UserName"].ToString()
    //, " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
    //            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

    //        }
    //    }
    //}
    //private void FillOrganizationCustomField()
    //{
    //    try
    //    {
    //        DataTable SD_Org = new FillSDFields().FillOrganization();
    //        ddlOrgCustomField.DataSource = SD_Org;
    //        ddlOrgCustomField.DataTextField = "OrgName";
    //        ddlOrgCustomField.DataValueField = "Org_ID";
    //        ddlOrgCustomField.DataBind();
    //        ddlOrgCustomField.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));
    //    }
    //    catch (ThreadAbortException e2)
    //    {
    //        Console.WriteLine("Exception message: {0}", e2.Message);
    //        Thread.ResetAbort();
    //    }
    //    catch (Exception ex)
    //    {
    //        if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
    //        {

    //        }
    //        else
    //        {
    //            var st = new StackTrace(ex, true);
    //            // Get the top stack frame
    //            var frame = st.GetFrame(0);
    //            // Get the line number from the stack frame
    //            var line = frame.GetFileLineNumber();
    //            inEr.InsertErrorLogsF(Session["UserName"].ToString()
    //, " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
    //            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

    //        }
    //    }
    //}
    //private void FillSDCustomFieldsDetails()
    //{

    //    try
    //    {

    //        DataTable SD_SDCustomFields = new FillSDFields().FillSDCustomFields(); 

    //        if (SD_SDCustomFields.Rows.Count > 0)
    //        {
    //            //  this.lb.Text = dataTable.Rows.Count.ToString();
    //            this.gvSDCustomFields.DataSource = (object)SD_SDCustomFields;
    //            this.gvSDCustomFields.DataBind();
    //        }
    //        else
    //        {
    //            this.gvSDCustomFields.DataSource = (object)null;
    //            this.gvSDCustomFields.DataBind();
    //        }


    //    }
    //    catch (ThreadAbortException e2)
    //    {
    //        Console.WriteLine("Exception message: {0}", e2.Message);
    //        Thread.ResetAbort();
    //    }

    //    catch (Exception ex)
    //    {
    //        if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
    //        {

    //        }
    //        else
    //        {
    //            var st = new StackTrace(ex, true);
    //            // Get the top stack frame
    //            var frame = st.GetFrame(0);
    //            // Get the line number from the stack frame
    //            var line = frame.GetFileLineNumber();
    //            inEr.InsertErrorLogsF(Session["UserName"].ToString()
    //, " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
    //            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

    //        }
    //    }
    //}
    //protected void ddlRequestTypeCustomField_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Session["SDRef"] = ddlRequestTypeCustomField.SelectedValue.ToString();
    //}
    //private void FillRequestTypeCustomField(long OrgID)
    //{

    //    try
    //    {

    //        DataTable RequestType = new SDTemplateFileds().FillRequestType(OrgID);
    //        ddlRequestTypeCustomField.DataSource = RequestType;
    //        ddlRequestTypeCustomField.DataTextField = "ReqTypeRef";
    //        ddlRequestTypeCustomField.DataValueField = "ReqTypeRef";
    //        ddlRequestTypeCustomField.DataBind();
    //        ddlRequestTypeCustomField.Items.Insert(0, new ListItem("----------Select RequestType----------", "0"));
    //    }
    //    catch (ThreadAbortException e2)
    //    {
    //        Console.WriteLine("Exception message: {0}", e2.Message);
    //        Thread.ResetAbort();
    //    }
    //    catch (Exception ex)
    //    {
    //        if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
    //        {

    //        }
    //        else
    //        {
    //            var st = new StackTrace(ex, true);
    //            // Get the top stack frame
    //            var frame = st.GetFrame(0);
    //            // Get the line number from the stack frame
    //            var line = frame.GetFileLineNumber();
    //            inEr.InsertErrorLogsF(Session["UserName"].ToString()
    //, " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
    //            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

    //        }
    //    }
    //}
    //protected void ImgBtnExport13_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {

    //        DataTable dt = new DataTable("GridView_Data");
    //        foreach (System.Web.UI.WebControls.TableCell cell in gvSDCustomFields.HeaderRow.Cells)
    //        {
    //            dt.Columns.Add(cell.Text);
    //        }
    //        foreach (GridViewRow row in gvSDCustomFields.Rows)
    //        {
    //            dt.Rows.Add();
    //            for (int i = 0; i < row.Cells.Count; i++)
    //            {
    //                dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
    //            }
    //        }
    //        using (XLWorkbook wb = new XLWorkbook())
    //        {
    //            wb.Worksheets.Add(dt);

    //            Response.Clear();
    //            Response.Buffer = true;
    //            Response.Charset = "";
    //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //            Response.AddHeader("content-disposition", "attachment;filename=SD_CustomFields.xlsx");
    //            using (MemoryStream MyMemoryStream = new MemoryStream())
    //            {
    //                wb.SaveAs(MyMemoryStream);
    //                MyMemoryStream.WriteTo(Response.OutputStream);
    //                Response.Flush();
    //                Response.End();
    //            }
    //        }

    //    }
    //    catch (ThreadAbortException e2)
    //    {
    //        Console.WriteLine("Exception message: {0}", e2.Message);
    //        Thread.ResetAbort();
    //    }
    //    catch (Exception ex)
    //    {
    //        if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
    //        {

    //        }
    //        else
    //        {
    //            var st = new StackTrace(ex, true);
    //            // Get the top stack frame
    //            var frame = st.GetFrame(0);
    //            // Get the line number from the stack frame
    //            var line = frame.GetFileLineNumber();
    //            inEr.InsertErrorLogsF(Session["UserName"].ToString()
    //, " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
    //            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

    //        }
    //    }
    //}
    //protected void gvSDCustomFields_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        // Handle delete command
    //        if (e.CommandName == "DeleteEx")
    //        {
    //            int rowIndex = Convert.ToInt32(e.CommandArgument);
    //            long ID = Convert.ToInt64(gvSDCustomFields.DataKeys[rowIndex].Values["ID"]);
    //            string Deskref = gvSDCustomFields.Rows[rowIndex].Cells[1].Text;

    //            // SQL Connection & Deletion logic
    //            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
    //            {
    //                con.Open();
    //                using (SqlCommand cmd = new SqlCommand("SD_spCustomFieldCntl", con))
    //                {
    //                    cmd.CommandType = CommandType.StoredProcedure;
    //                    cmd.Parameters.AddWithValue("@ID", ID);
    //                    cmd.Parameters.AddWithValue("@DeskRef", Deskref);
    //                    cmd.Parameters.AddWithValue("@OrgRef", ddlOrgCustomField.SelectedValue.ToString());
    //                    cmd.Parameters.AddWithValue("@Option", "DeleteCustomField");
    //                    cmd.CommandTimeout = 180;
    //                    int res = cmd.ExecuteNonQuery();

    //                    if (res > 0)
    //                    {
    //                        // Flag the session for deletion success
    //                        Session["Popup"] = "Delete";
    //                    }
    //                }
    //                con.Close();
    //            }

    //            // Refetch the data and refresh the GridView
    //            FillSDCustomFieldsDetails();
    //        }

    //        // Handle select/edit command
    //        if (e.CommandName == "SelectState")
    //        {
    //            // Hide Insert, show Update button
    //            btnInsertSDCustomFields.Visible = false;
    //            btnUpdateSDCustomFields.Visible = true;

    //            int rowIndex = Convert.ToInt32(e.CommandArgument);
    //            GridViewRow row = gvSDCustomFields.Rows[rowIndex];

    //            long ID = Convert.ToInt64(gvSDCustomFields.DataKeys[rowIndex].Values["ID"]);

    //            // Get the organization reference from hidden label
    //            Label OrgID = (row.FindControl("lblOrgFk") as Label);

    //            // Set dropdowns and other controls
    //            if (ddlOrgCustomField.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
    //            {
    //                ddlOrgCustomField.SelectedValue = OrgID.Text;
    //                FillRequestTypeCustomField(Convert.ToInt64(OrgID.Text));
    //                ddlRequestTypeCustomField.SelectedValue = gvSDCustomFields.Rows[rowIndex].Cells[1].Text;
    //            }

    //            // Set values in other fields
    //            ddlFieldType.SelectedValue = gvSDCustomFields.Rows[rowIndex].Cells[5].Text;
    //            ddlVisibilty.SelectedValue = (gvSDCustomFields.Rows[rowIndex].Cells[6].Text.Trim() == "True") ? "1" : "0";
    //            ddlRequiredStatus.SelectedValue = (gvSDCustomFields.Rows[rowIndex].Cells[7].Text.Trim() == "True") ? "1" : "0";

    //            ddlFieldType.Enabled = false;
    //            txtFieldName.Text = gvSDCustomFields.Rows[rowIndex].Cells[3].Text;
    //            txtFieldName.Enabled = false;
    //            ddlFieldMode.SelectedValue = gvSDCustomFields.Rows[rowIndex].Cells[4].Text;
    //            ddlFieldScope.SelectedValue = gvSDCustomFields.Rows[rowIndex].Cells[8].Text;
    //        }
    //    }
    //    catch (ThreadAbortException e2)
    //    {
    //        // Handle thread abort exception
    //        Console.WriteLine("Thread Abort: {0}", e2.Message);
    //        Thread.ResetAbort();
    //    }
    //    catch (Exception ex)
    //    {
    //        // Log detailed error and display notification to user
    //        var st = new StackTrace(ex, true);
    //        var frame = st.GetFrame(0);
    //        var line = frame.GetFileLineNumber();

    //        // Log the exception details
    //        inEr.InsertErrorLogsF(Session["UserName"].ToString(),
    //            $"Error in {Request.Url.ToString()}, Line: {line}, Exception: {ex.ToString()}");

    //        // Display the error notification on the frontend
    //        ScriptManager.RegisterStartupScript(this, GetType(),
    //            "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
    //    }
    //}

    //protected void SaveDataCustomField()
    //{
    //    long id = r.Next();
    //    try
    //    {
    //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
    //        {

    //            using (SqlCommand cmd = new SqlCommand("SD_spCustomFieldCntl", con))
    //            {
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.AddWithValue("@ID", id);
    //                cmd.Parameters.AddWithValue("@Deskref", ddlRequestType.SelectedValue);
    //                if (ddlFieldType.SelectedValue.ToString() == "TextBox")
    //                {
    //                    cmd.Parameters.AddWithValue("@FieldID", "txt" + id);
    //                }
    //                else if (ddlFieldType.SelectedValue.ToString() == "DropDown")
    //                {
    //                    cmd.Parameters.AddWithValue("@FieldID", "ddl" + id);

    //                }
    //                cmd.Parameters.AddWithValue("@FieldName", txtFieldName.Text.ToString());
    //                cmd.Parameters.AddWithValue("@FieldValue", txtFieldName.Text.ToString().Replace(" ", "_"));
    //                cmd.Parameters.AddWithValue("@FieldType", ddlFieldType.SelectedValue.ToString());
    //                cmd.Parameters.AddWithValue("@FieldMode", ddlFieldMode.SelectedValue.ToString());
    //                cmd.Parameters.AddWithValue("@Status", ddlVisibilty.SelectedValue.ToString());
    //                cmd.Parameters.AddWithValue("@IsFieldReq", ddlRequiredStatus.SelectedValue.ToString());
    //                cmd.Parameters.AddWithValue("@FieldScope", ddlFieldScope.SelectedValue.ToString());
    //                cmd.Parameters.AddWithValue("@OrgRef", ddlOrgCustomField.SelectedValue.ToString());
    //                cmd.Parameters.AddWithValue("@Option", "AddCustomField");
    //                con.Open();
    //                int res = cmd.ExecuteNonQuery();
    //                if (res > 0)
    //                {
    //                    Session["Popup"] = "Insert";
    //                    Response.Redirect(Request.Url.AbsoluteUri);
    //                }

    //            }
    //        }
    //    }
    //    catch (ThreadAbortException e2)
    //    {
    //        Console.WriteLine("Exception message: {0}", e2.Message);
    //        Thread.ResetAbort();
    //    }
    //    catch (Exception ex)
    //    {
    //        if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
    //        {

    //        }
    //        else
    //        {
    //            var st = new StackTrace(ex, true);
    //            // Get the top stack frame
    //            var frame = st.GetFrame(0);
    //            // Get the line number from the stack frame
    //            var line = frame.GetFileLineNumber();
    //            inEr.InsertErrorLogsF(Session["UserName"].ToString()
    //, " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
    //            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

    //        }
    //    }
    //}
    //protected void btnInsertSDCustomFields_Click(object sender, EventArgs e)
    //{
    //    SaveDataCustomField();
    //}
    //protected void gvSDCustomFields_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    CurrentStep = 13;
    //    ViewState["CurrentStep"] = CurrentStep;
    //    DataBind();
    //    if (Session["UserScope"].ToString() == "Master")
    //    {
    //        e.Row.Cells[10].Visible = true;
    //        e.Row.Cells[11].Visible = true;
    //    }

    //    if (Session["UserScope"].ToString() == "Technician")
    //    {
    //        e.Row.Cells[10].Visible = false;
    //        e.Row.Cells[11].Visible = false;

    //    }
    //    if (Session["UserScope"].ToString() == "Admin")
    //    {
    //        e.Row.Cells[10].Visible = true;
    //        e.Row.Cells[11].Visible = false;

    //    }
    //}
    //protected void btnUpdateSDCustomFields_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
    //        {
    //            using (SqlCommand cmd = new SqlCommand("SD_spCustomFieldCntl", con))
    //            {
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.AddWithValue("@ID", ID);
    //                cmd.Parameters.AddWithValue("@Deskref", ddlRequestType.SelectedValue);
    //                cmd.Parameters.AddWithValue("@FieldMode", ddlFieldMode.SelectedValue);
    //                cmd.Parameters.AddWithValue("@Status", ddlVisibilty.SelectedValue);
    //                cmd.Parameters.AddWithValue("@IsFieldReq", ddlRequiredStatus.SelectedValue);
    //                cmd.Parameters.AddWithValue("@FieldScope", ddlFieldScope.SelectedValue);
    //                cmd.Parameters.AddWithValue("@OrgRef", ddlOrg.SelectedValue.ToString());
    //                cmd.Parameters.AddWithValue("@Option", "UpdateCustomField");
    //                con.Open();
    //                int res = cmd.ExecuteNonQuery();
    //                if (res > 0)
    //                {
    //                    Session["Popup"] = "Update";
    //                    Response.Redirect(Request.Url.AbsoluteUri);
    //                }
    //                //  ErrorMessage(this, "Welcome", "Greeting");
    //                // ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Showalert('success','Data has been updated');", true);
    //            }
    //        }
    //    }
    //    catch (ThreadAbortException e2)
    //    {
    //        Console.WriteLine("Exception message: {0}", e2.Message);
    //        Thread.ResetAbort();
    //    }
    //    catch (Exception ex)
    //    {
    //        if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
    //        {

    //        }
    //        else
    //        {
    //            var st = new StackTrace(ex, true);
    //            var frame = st.GetFrame(0);
    //            var line = frame.GetFileLineNumber();
    //            inEr.InsertErrorLogsF(Session["UserName"].ToString()
    //, " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
    //            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

    //        }
    //    }
    //}
    //protected void btnCancel12_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Request.Url.AbsoluteUri);
    //}
    //protected void ddlOrgCustomField_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    FillRequestTypeCustomField(Convert.ToInt64(ddlOrgCustomField.SelectedValue));
    //}
    //protected void lnkNextEsclation_Click(object sender, EventArgs e)
    //{
    //    pnlExclation.Visible = true;
    //    pnlAdddeskConfig.Visible = false;
    //    cleardata();
    //    CurrentStep = 13;
    //    ViewState["CurrentStep"] = CurrentStep;
    //    DataBind();
    //    if (Session["UserScope"] != null)
    //    {
    //        FillEcslevelDetails();
    //        FillOrganization();
    //    }
    //    else
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //}
    //protected void lnkPreviousDeskConfig_Click(object sender, EventArgs e)
    //{
    //    pnlAddCustomFields.Visible = false;
    //    lnkNextCustomFields_Click(null, null);
    //}
    #endregion End Cutom Fileds


    #region Email Config Start
    protected void GridFormat7(DataTable dt)
    {
        gvEmailConfig.UseAccessibleHeader = true;
        gvEmailConfig.HeaderRow.TableSection = TableRowSection.TableHeader;
        if (gvEmailConfig.TopPagerRow != null)
        {
            gvEmailConfig.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvEmailConfig.BottomPagerRow != null)
        {
            gvEmailConfig.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvEmailConfig.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    private void FillOrganizationEmailConfig()
    {
        try
        {
            DataTable SD_Org = new FillSDFields().FillOrganization();
            ddlOrgEmailConfig.DataSource = SD_Org;
            ddlOrgEmailConfig.DataTextField = "OrgName";
            ddlOrgEmailConfig.DataValueField = "Org_ID";
            ddlOrgEmailConfig.DataBind();
            ddlOrgEmailConfig.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----------Select Organization----------", "0"));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillEmailConfigDetails()
    {
        try
        {
            DataTable SD_EmailConfig = new FillSDFields().FillUserEmailConfigdetails();
            if (SD_EmailConfig.Rows.Count > 0)
            {
                this.gvEmailConfig.DataSource = (object)SD_EmailConfig;
                this.gvEmailConfig.DataBind();
            }
            else
            {
                this.gvEmailConfig.DataSource = (object)null;
                this.gvEmailConfig.DataBind();
            }
            //GridFormat7(SD_EmailConfig);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void ImgBtnExport8_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvEmailConfig.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvEmailConfig.Rows)
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
                Response.AddHeader("content-disposition", "attachment;filename=EmailConfig.xlsx");
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
        }
    }
    static long EmailConfigID;
    protected void gvEmailConfig_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEmailConfig")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                EmailConfigID = Convert.ToInt64(gvEmailConfig.DataKeys[rowIndex].Values["ID"]);

                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spEmailConfig", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", EmailConfigID);
                            cmd.Parameters.AddWithValue("@Option", "DeleteEmailConfig");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}');", true);
                            }
                            con.Close();
                            FillEmailConfigDetails();
                            
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

                    }
                }

            }


            if (e.CommandName == "UpdateEmailConfig")
            {
                rfvtxtPassword.Enabled = false;

                AddEmailConfigPanel();
                btnInsertEmailConfig.Visible = false;
                btnUpdateEmailConfig.Visible = true;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvEmailConfig.Rows[rowIndex];
                EmailConfigID = Convert.ToInt32(gvEmailConfig.DataKeys[rowIndex].Values["ID"]);
                txtHostName.Text = gvEmailConfig.Rows[rowIndex].Cells[1].Text;
                txtPort.Text = gvEmailConfig.Rows[rowIndex].Cells[2].Text;
                txtUserName.Text = gvEmailConfig.Rows[rowIndex].Cells[3].Text;
                txtEmail.Text = gvEmailConfig.Rows[rowIndex].Cells[4].Text;
                txtRetry.Text = gvEmailConfig.Rows[rowIndex].Cells[6].Text;
                txtClientID.Text = gvEmailConfig.Rows[rowIndex].Cells[7].Text;
                txtClientSecretKey.Text = gvEmailConfig.Rows[rowIndex].Cells[8].Text;
                txtTenantID.Text = gvEmailConfig.Rows[rowIndex].Cells[9].Text;
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrgEmailConfig.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrgEmailConfig.SelectedValue = OrgID.Text;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void SaveDataEmailConfig()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SD_spEmailConfig", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@Hostname", txtHostName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Port", txtPort.Text);
                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@ClientID", txtClientID.Text);
                    cmd.Parameters.AddWithValue("@ClientSecretKey", txtClientSecretKey.Text);
                    cmd.Parameters.AddWithValue("@TenantID", txtTenantID.Text);
                    cmd.Parameters.AddWithValue("@OrgRef", ddlOrgEmailConfig.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "AddEmailConfig");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}');", true);
                        FillOrganizationEmailConfig();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void gvEmailConfig_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (Session["UserScope"].ToString() == "Master")
            {
                e.Row.Cells[5].Visible = true;
                e.Row.Cells[6].Visible = true;
            }

            if (Session["UserScope"].ToString() == "Technician")
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnInsertEmailConfig_Click(object sender, EventArgs e)
    {
        SaveDataEmailConfig();
    }
    protected void AddEmailConfigPanel()
    {
        pnlAddEmailConfig.Visible = true;
        txtHostName.Text = "";
        txtPort.Text = "";
        txtUserName.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtRetry.Text = "";
        txtClientID.Text = "";
        txtClientSecretKey.Text = "";
        txtTenantID.Text = "";
        btnInsertEmailConfig.Visible = true;
        btnUpdateEmailConfig.Visible = false;
    }
    protected void btnUpdateEmailConfig_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spEmailConfig", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", EmailConfigID);
                    cmd.Parameters.AddWithValue("@Hostname", txtHostName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Port", txtPort.Text);
                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Retry", txtRetry.Text);
                    cmd.Parameters.AddWithValue("@ClientID", txtClientID.Text);
                    cmd.Parameters.AddWithValue("@ClientSecretKey", txtClientSecretKey.Text);
                    cmd.Parameters.AddWithValue("@TenantID", txtTenantID.Text);
                    cmd.Parameters.AddWithValue("@OrgRef", ddlOrgEmailConfig.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "UpdateEmailConfig");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}');", true);
                        FillOrganizationEmailConfig();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnCancel8_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void lnkPreviousCategory_Click(object sender, EventArgs e)
    {
        pnlAddEmailConfig.Visible = false;
        lnkNextDeskConfig_Click(null, null);
    }
    protected void lnkNextResolution_Click(object sender, EventArgs e)
    {
        pnlExclation.Visible = true;
        pnlAddEmailConfig.Visible = false;
        cleardata();
        CurrentStep = 12;
        ViewState["CurrentStep"] = CurrentStep;
        DataBind();
        if (Session["UserScope"] != null)
        {
            FillEcslevelDetails();
            FillOrganizationEsclationMatrix();
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    }
    #endregion Email Config End



    #region Esclation Matrix Start
    private void FillOrganizationEsclationMatrix()
    {
        try
        {
            DataTable SD_Org = new FillSDFields().FillOrganization();
            ddlOrgEcs.DataSource = SD_Org;
            ddlOrgEcs.DataTextField = "OrgName";
            ddlOrgEcs.DataValueField = "Org_ID";
            ddlOrgEcs.DataBind();
            ddlOrgEcs.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", "0"));
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    private void FillEcslevelDetails()
    {
        try
        {
            DataTable SD_Ecslevel = new FillSDFields().FillUserEcsleveldetails();
            if (SD_Ecslevel.Rows.Count > 0)
            {
                this.gvEcslevel.DataSource = (object)SD_Ecslevel;
                this.gvEcslevel.DataBind();

            }
            else
            {
                this.gvEcslevel.DataSource = (object)null;
                this.gvEcslevel.DataBind();

            }
            if (SD_Ecslevel.Rows.Count > 0)
            {
                //GridFormat(SD_Ecslevel);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
            }
        }
    }
    protected void ImgBtnExport14_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in gvEcslevel.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in gvEcslevel.Rows)
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
                Response.AddHeader("content-disposition", "attachment;filename=EsclatnMatrix.xlsx");
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    static int EcslevelID;
    protected void gvEcslevel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteEcslevel")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                EcslevelID = Convert.ToInt32(gvEcslevel.DataKeys[rowIndex].Values["ID"]);

                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("SD_spAddUserEcslevel", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", EcslevelID);

                            cmd.Parameters.AddWithValue("@Option", "DeleteEcslevel");
                            cmd.CommandTimeout = 180;
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                Session["Popup"] = "Delete";
                                //Response.Redirect(Request.Url.AbsoluteUri);
                                //                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
                                //$"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 2000); }}", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Deleted Successfully!")}');", true);
                                //lnkNextResolution_Click(null,null);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
   $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
                            }
                            con.Close();
                            FillEcslevelDetails();
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
            if (e.CommandName == "UpdateEcslevel")
            {
                btnInsertEcslevel.Visible = false;
                btnUpdateEcslevel.Visible = true;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvEcslevel.Rows[rowIndex];
                EcslevelID = Convert.ToInt32(gvEcslevel.DataKeys[rowIndex].Values["ID"]);
                ddlEsclationLevel.SelectedValue = gvEcslevel.Rows[rowIndex].Cells[1].Text;
                txtUserNameEsc.Text = gvEcslevel.Rows[rowIndex].Cells[2].Text;
                txtEmailEsc.Text = gvEcslevel.Rows[rowIndex].Cells[3].Text;
                txtMobile.Text = gvEcslevel.Rows[rowIndex].Cells[4].Text;
                txttimeforEsclation.Text = gvEcslevel.Rows[rowIndex].Cells[5].Text;
                Label OrgID = (row.FindControl("lblOrgFk") as Label);
                if (ddlOrgEcs.Items.FindByValue(OrgID.Text.ToString().Trim()) != null)
                {
                    ddlOrgEcs.SelectedValue = OrgID.Text;
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void SaveDataEcs()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddUserEcslevel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EsclationLevel", ddlEsclationLevel.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserName", txtUserNameEsc.Text);
                    cmd.Parameters.AddWithValue("@UserEmail", txtEmailEsc.Text);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@TimeForEsclatn", txttimeforEsclation.Text);
                    cmd.Parameters.AddWithValue("@OrgRef", ddlOrgEcs.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "AddEsclationUser");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Insert";
                        //Response.Redirect(Request.Url.AbsoluteUri + "?pnlAddEcslevel=true");
                        //                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
                        //$"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 5000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Saved Successfully!")}');", true);
                        FillEcslevelDetails();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void gvEcslevel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnInsertEcslevel_Click(object sender, EventArgs e)
    {
        SaveDataEcs();
    }
    protected void btnUpdateEcslevel_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddUserEcslevel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", EcslevelID);
                    cmd.Parameters.AddWithValue("@EsclationLevel", ddlEsclationLevel.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserName", txtUserNameEsc.Text);
                    cmd.Parameters.AddWithValue("@UserEmail", txtEmailEsc.Text);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@TimeForEsclatn", txttimeforEsclation.Text);
                    cmd.Parameters.AddWithValue("@OrgRef", ddlOrgEcs.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Option", "UpdateUserEcslevel");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Update";
                        //Response.Redirect(Request.Url.AbsoluteUri + "?pnlAddEcslevel=true");
                        //                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
                        //$"if (window.location.pathname.endsWith('/DeskConfiguration.aspx')) {{ success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}'); setTimeout(function() {{ window.location.reload(); }}, 4000); }}", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"success_noti('{HttpUtility.JavaScriptStringEncode("Updated Successfully!")}');", true);
                        FillEcslevelDetails();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

            }
        }
    }
    protected void btnAddUserEcslevel_Click(object sender, EventArgs e)
    {
        ddlEsclationLevel.ClearSelection();
        txtUserName.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txttimeforEsclation.Text = "";
        ddlOrg.ClearSelection();
        btnInsertEcslevel.Visible = true;
        btnUpdateEcslevel.Visible = false;

    }
    protected void GridFormat(DataTable dt)
    {
        gvEcslevel.UseAccessibleHeader = true;
        gvEcslevel.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (gvEcslevel.TopPagerRow != null)
        {
            gvEcslevel.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvEcslevel.BottomPagerRow != null)
        {
            gvEcslevel.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvEcslevel.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    protected void btnCancel14_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void lnkPreviousCustomField_Click(object sender, EventArgs e)
    {
        pnlExclation.Visible = false;
        lnkNextCustomFields_Click(null, null);
    }
    #endregion Esclation Matrin End
}
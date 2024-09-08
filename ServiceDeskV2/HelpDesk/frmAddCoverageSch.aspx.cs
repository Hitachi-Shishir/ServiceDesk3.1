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

public partial class frmAddCoverageSch : System.Web.UI.Page
{
    InsertErrorLogs inEr = new InsertErrorLogs();
    public enum MessageType { success, error, info, warning };
    protected void ShowMessage(MessageType type, string Message)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "Showalert('" + type + "','" + Message + "');", true);
    }
    protected override void OnInit(EventArgs e)
    {
        try
        {
            //Change your condition here
            if (Session["Popup"] != null)
            {
                if (Session["Popup"].ToString() == "Insert")
                {
                    ShowMessage(MessageType.success, "Record Inserted Successfully!!");


                }
                if (Session["Popup"].ToString() == "Update")
                {
                    ShowMessage(MessageType.success, "Record Updated Successfully!!");


                }
                if (Session["Popup"].ToString() == "Delete")
                {
                    ShowMessage(MessageType.error, "Record Deleted Successfully!!");


                }
                if (Session["Popup"].ToString() == "Warning")
                {
                    ShowMessage(MessageType.warning, "Record Deleted Successfully!!");


                }
                Session.Remove("Popup");
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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserScope"] != null)
            {
                if (!IsPostBack)
                {

                    FillSLADetails();
                    pnlViewSLA.Visible = true;
                    btnViewSLA.CssClass = "btn btn-sm btnEnabled";
                    btnViewSLA.Enabled = false;
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
    private void FillSLADetails()
    {
        try
        {
            DataTable SD_SLA = new FillSDFields().FillCoverageSchdetails(); ;
            if (SD_SLA.Rows.Count > 0)
            {
                this.gvSLA.DataSource = (object)SD_SLA;
                this.gvSLA.DataBind();
            }
            else
            {
                this.gvSLA.DataSource = (object)null;
                this.gvSLA.DataBind();
            }

            GridFormat(SD_SLA);
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
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
    protected void GridFormat(DataTable dt)
    {
        gvSLA.UseAccessibleHeader = true;
        gvSLA.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (gvSLA.TopPagerRow != null)
        {
            gvSLA.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvSLA.BottomPagerRow != null)
        {
            gvSLA.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvSLA.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    private void Modal()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#basicModal').modal('show');");
        //  sb.Append("$('#basicModal').modal.appendTo('body').show('show')");
        sb.Append("$('body').removeClass('modal-open');");
        sb.Append("$('.modal-backdrop').remove();");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ModalScript", sb.ToString(), false);


    }
    protected void ImgBtnExport_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataTable dt = new DataTable("GridView_Data");
            foreach (TableCell cell in gvSLA.HeaderRow.Cells)
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
                Response.AddHeader("content-disposition", "attachment;filename=CoverageSch.xlsx");
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
                SLAID = Convert.ToInt64(gvSLA.DataKeys[rowIndex].Values["ID"]);

                //try
                //{
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SD_spAddCoverageSch", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", SLAID);

                        cmd.Parameters.AddWithValue("@Option", "DeleteDeskCvrgSch");
                        cmd.CommandTimeout = 180;
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            pnlShowRqstType.Visible = false;
                            //	lblsuccess.ForeColor = System.Drawing.Color.Green;
                            //	lblsuccess.Text = PriorityName + " Deleted successfully";
                            Session["Popup"] = "Delete";
                            Response.Redirect(Request.Url.AbsoluteUri);
                        }


                        //	ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Showalert('error','" + PriorityName + " Deleted successfully" + "');", true);

                        //Response.Redirect(Request.Url.AbsoluteUri);
                        con.Close();
                        FillSLADetails();

                    }
                }
                //
                //	}
                //	catch (ThreadAbortException e2)
                //	{
                //		Console.WriteLine("Exception message: {0}", e2.Message);
                //		Thread.ResetAbort();
                //	}
                //	catch (Exception ex)
                //	{
                //		if (ex.ToString().Contains("System.Threading.Thread.AbortInternal()"))
                //		{

                //		}
                //		else
                //		{
                //			var st = new StackTrace(ex, true);
                //			// Get the top stack frame
                //			var frame = st.GetFrame(0);
                //			// Get the line number from the stack frame
                //			var line = frame.GetFileLineNumber();
                //			inEr.InsertErrorLogsF(Session["UserName"].ToString()
                //, " " + Request.Url.ToString() + "Got Exception" + "Line Number :" + line.ToString() + ex.ToString());
                //			Response.Redirect("~/Error/Error.html");
                //		}
                //	}
            }


            if (e.CommandName == "UpdateSLA")
            {
                AddSLAPanel();
                btnInsertSLA.Visible = false;
                btnUpdateSLA.Visible = true;

                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Get the value of column from the DataKeys using the RowIndex.
                SLAID = Convert.ToInt32(gvSLA.DataKeys[rowIndex].Values["ID"]);

                txtCvrgname.Text = gvSLA.Rows[rowIndex].Cells[1].Text;

                //	lstDaysCvrd.Text = gvSLA.Rows[rowIndex].Cells[2].Text;
                string[] arr = Convert.ToString(gvSLA.Rows[rowIndex].Cells[2].Text.ToString()).Split(',');
                foreach (string author in arr)
                {
                    foreach (ListItem item in lstDaysCvrd.Items)
                    {
                        if (item.ToString() == author)
                        {
                            item.Selected = true;
                            //message += item.Value + ",";
                        }
                    }
                }
                string HoursCovered = gvSLA.Rows[rowIndex].Cells[3].Text;
                if (HoursCovered == "UseTheseHours")
                {

                    rdblist.Items.FindByValue("UseTheseHours").Selected = true;
                    txtBeginHour.Enabled = true;
                    txtEndHour.Enabled = true;
                    pnlcvrgSch.Enabled = true;
                    txtBeginHour.Text = gvSLA.Rows[rowIndex].Cells[4].Text;
                    txtEndHour.Text = gvSLA.Rows[rowIndex].Cells[5].Text;
                }
                else if (HoursCovered == "NoCoverage")
                {
                    rdblist.Items.FindByValue("NoCoverage").Selected = true;
                    rfvtxtBeginHour.Enabled = false;
                    rfvtxtEndHour.Enabled = false;
                    txtBeginHour.Enabled = false;
                    txtEndHour.Enabled = false;
                }
                else if (HoursCovered == "24hrCoverage")
                {
                    rdblist.Items.FindByValue("24hrCoverage").Selected = true;
                    rfvtxtBeginHour.Enabled = false;
                    rfvtxtEndHour.Enabled = false;
                    txtBeginHour.Enabled = false;
                    txtEndHour.Enabled = false;
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
    Random r = new Random();
    protected void SaveData()
    {
        try
        {
            string message = "";
            foreach (ListItem item in lstDaysCvrd.Items)
            {
                if (item.Selected)
                {
                    message += item.Value + ",";
                }
            }
            message = message.TrimEnd(',');

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddCoverageSch", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", r.Next());
                    cmd.Parameters.AddWithValue("@ScdhuleName", txtCvrgname.Text.Trim());
                    cmd.Parameters.AddWithValue("@DaysCovered", message);
                    cmd.Parameters.AddWithValue("@HoursCovered", rdblist.SelectedValue);
                    cmd.Parameters.AddWithValue("@BeginHour", txtBeginHour.Text);
                    cmd.Parameters.AddWithValue("@EndHour", txtEndHour.Text);
                    cmd.Parameters.AddWithValue("@Option", "AddDeskCvrgSch");
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Session["Popup"] = "Insert";
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }

                }
            }

            //  Task ignoredAwaitableResult = this.Redirect();
            //    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Showalert('info',' Inserted successfully');window.location.href='" + Request.RawUrl +"';", true);




        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
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
    protected void gvSLA_RowDataBound(object sender, GridViewRowEventArgs e)
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
                Response.Redirect("~/Error/Error.html");
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnInsertSLA_Click(object sender, EventArgs e)
    {
        SaveData();
    }
    protected void btnUpdateSLA_Click(object sender, EventArgs e)
    {
        try
        {
            string message = "";
            foreach (ListItem item in lstDaysCvrd.Items)
            {
                if (item.Selected)
                {
                    message += item.Value + ",";
                }
            }
            message = message.TrimEnd(',');

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SD_spAddCoverageSch", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", SLAID);
                    cmd.Parameters.AddWithValue("@ScdhuleName", txtCvrgname.Text.Trim());
                    cmd.Parameters.AddWithValue("@DaysCovered", message);
                    cmd.Parameters.AddWithValue("@HoursCovered", rdblist.SelectedValue);
                    cmd.Parameters.AddWithValue("@BeginHour", txtBeginHour.Text);
                    cmd.Parameters.AddWithValue("@EndHour", txtEndHour.Text);
                    cmd.Parameters.AddWithValue("@Option", "UpdateDeskCvrgSch");
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
    protected void AddSLAPanel()
    {
        try
        {
            pnlAddSLA.Visible = true;
            btnAddSLA.CssClass = "btn btn-sm btnEnabled";
            pnlViewSLA.Visible = false;
            btnViewSLA.CssClass = "btn btn-sm btnDisabled";
            btnAddSLA.Enabled = false;
            btnViewSLA.Enabled = true;
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
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
    protected void btnViewSLA_Click(object sender, EventArgs e)
    {
        try
        {
            pnlAddSLA.Visible = false;
            btnAddSLA.CssClass = "btn btn-sm btnDisabled";
            pnlViewSLA.Visible = true;
            btnViewSLA.CssClass = "btn btn-sm btnEnabled";
            btnViewSLA.Enabled = false;
            btnAddSLA.Enabled = true;
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
    protected void btnAddSLA_Click(object sender, EventArgs e)
    {
        AddSLAPanel();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void rdblist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdblist.SelectedValue == "NoCoverage" || rdblist.SelectedValue == "24hrCoverage")
            {
                pnlcvrgSch.Enabled = false;
                rfvtxtBeginHour.Visible = false;
                rfvtxtEndHour.Visible = false;
                rfvtxtBeginHour.Enabled = false;
                rfvtxtEndHour.Enabled = false;
            }

            else
            {
                pnlcvrgSch.Enabled = true;
                rfvtxtBeginHour.Enabled = true;
                rfvtxtEndHour.Enabled = true;
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
}
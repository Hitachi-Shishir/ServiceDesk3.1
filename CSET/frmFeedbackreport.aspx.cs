using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CSET_frmFeedbackreport : System.Web.UI.Page
{
    errorMessage msg = new errorMessage();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                ComplianceDetails();
            }
        }
        catch (Exception ex)
        {
            msg.ReportError(ex.Message);

        }
    }
    public override void VerifyRenderingInServerForm(Control control) { }
    protected void btnExport_Click(object sender, ImageClickEventArgs e)
    {


        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Feedback Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvPatchStatus.AllowPaging = false;
            // this.BindGrid();


            foreach (TableCell cell in gvPatchStatus.HeaderRow.Cells)
            {
                cell.BackColor = gvPatchStatus.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvPatchStatus.Rows)
            {

                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvPatchStatus.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvPatchStatus.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvPatchStatus.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    protected void gvPatchStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatchStatus.PageIndex = e.NewPageIndex;
        this.ComplianceDetails();
    }
    private void ComplianceDetails()
    {
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand(@"SELECT *
				FROM
				(SELECT DISTINCT 
					a.TicketID,q.Question, a.Answer,f.Feedback				
				FROM SD_FeedAnswers a INNER JOIN
					SD_FeedQuestions q ON a.QuestionId = q.QuestionId 
					
					INNER JOIN SD_Feedback f ON f.FeedbackID=a.FeedbackID
				WHERE  (q.status = 'Active') ) AS SourceTable
				PIVOT
				(
				 Max(Answer)
				 FOR Question IN (
					 [Are you satisfied with the service ?]
					,[How do you rate timeliness of response ? ]
					,[How do you rate frequency of communication and update ?]
					,[How do you rate the knowledge of the Technician ?]
					,[How do you rate the efficiency of our Service Delivery ?]
					
				 )
				) AS PivotTable 
", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            adp.SelectCommand.CommandTimeout = 180;

                            adp.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {

                                lblTotalRecord.Text = dt.Rows.Count.ToString();
                                gvPatchStatus.DataSource = dt;
                                gvPatchStatus.DataBind();
                                GridFormat(dt);

                            }
                            else
                            {
                                gvPatchStatus.DataSource = null;
                                gvPatchStatus.DataBind();

                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //msg.ReportError(ex.Message);
        }
    }
    protected void GridFormat(DataTable dt)
    {
        gvPatchStatus.UseAccessibleHeader = true;
        gvPatchStatus.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (gvPatchStatus.TopPagerRow != null)
        {
            gvPatchStatus.TopPagerRow.TableSection = TableRowSection.TableHeader;
        }
        if (gvPatchStatus.BottomPagerRow != null)
        {
            gvPatchStatus.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
        if (dt.Rows.Count > 0)
            gvPatchStatus.FooterRow.TableSection = TableRowSection.TableFooter;
    }
}
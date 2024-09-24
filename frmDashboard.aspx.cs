using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ubiety.Dns.Core;

public partial class frmDashboard : System.Web.UI.Page
{
    Util obj = new Util();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            getFilterData("0", "0", Convert.ToString("1900-01-01"), Convert.ToString("1900-01-01"), "", "");
            lblUserName.Text = Convert.ToString(Session["UserName"]).ToUpper() + " " + "!";
            string sql = "SELECT FileData FROM SD_User_Master WHERE FileData IS NOT NULL AND LoginName = '" + Convert.ToString(Session["LoginName"]) + "'";
            byte[] fileData = (byte[])database.GetScalarValue(sql);
            string imageUrl = "";
            if (fileData != null && fileData.Length > 0)
            {
                imageUrl = "data:image/jpg;base64," + Convert.ToBase64String(fileData);
            }
            img.ImageUrl = imageUrl;
            FillRequestType(Convert.ToInt64(Session["OrgID"]));
        }
    }
    public void getFilterData(string ReqType, string Category, string frmDate, string toDate,
        string UserID, string Orgid)
    {
        if (string.IsNullOrEmpty(Convert.ToString(frmDate)) || string.IsNullOrEmpty(Convert.ToString(toDate)))
        {
            frmDate = Convert.ToString("1900-01-01");
            toDate = Convert.ToString("1900-01-01");
        }
        DataSet ds = new DataSet();
        if (Convert.ToString(Session["UserRole"]).ToUpper() == "MASTER")
        {
            ds = GetDataDashboard(ReqType, Category, frmDate,
                toDate, UserID, Orgid);
        }
        else if (Convert.ToString(Session["UserRole"]).ToUpper() == "ADMIN")
        {
            ds = GetDataDashboard(ReqType, Category, frmDate,
                toDate, UserID, Convert.ToString(Session["OrgID"]));
        }
        else
        {
            divlocation.Visible = false;
            divAssigne.Visible = false;
            ds = GetDataDashboard(ReqType, Category, frmDate,
                toDate, Convert.ToString(Session["UserID"]), Convert.ToString(Session["OrgID"]));
        }
        getTicketData(ds);
    }
    private void FillRequestType(long OrgId)
    {
        try
        {
            DataTable RequestType = new SDTemplateFileds().FillRequestType(OrgId);
            ddlRequestType.DataSource = RequestType;
            ddlRequestType.DataTextField = "ReqTypeRef";
            ddlRequestType.DataValueField = "id";
            ddlRequestType.DataBind();
            ddlRequestType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--ALL--", "0"));
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            // msg.ReportError(ex.Message);
        }
    }
    private void FillCategory(string OrgId, string ReqType)
    {
        try
        {
            DataTable RequestType = new SDTemplateFileds().FillCategoryAll(OrgId, ReqType);
            ddlCategory.DataSource = RequestType;
            ddlCategory.DataTextField = "CategoryCodeRef";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--ALL--", "0"));
        }
        catch (ThreadAbortException e2)
        {
            Console.WriteLine("Exception message: {0}", e2.Message);
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            // msg.ReportError(ex.Message);
        }
    }
    public DataSet GetDataDashboard(string ReqType, string Category, string frmDate, string toDate,
        string UserID, string Orgid)
    {
        DataSet ds = new DataSet();
        ds = obj.getDashboardData(ReqType, Category, frmDate, toDate, UserID, Orgid);
        return ds;
    }
    public void getTicketData(DataSet ds)
    {
        DataTable dt = ds.Tables[0];
        DataTable dt1 = ds.Tables[1];
        DataTable dt2 = ds.Tables[2];
        DataTable dt3 = ds.Tables[3];
        DataTable dt4 = ds.Tables[4];
        double Open = 0;
        double Hold = 0;
        double Wip = 0;
        double Closed = 0;
        double Resolved = 0;
        double OpenPer = 0;
        double HoldPer = 0;
        double WipPer = 0;
        double ClosedPer = 0;
        double ResolvedPer = 0;
        double TotalTicket = 0;
        double ServerityS1 = 0;
        double ServerityS2 = 0;
        double ServerityS3 = 0;
        double HighPriority = 0;
        double MediumPriority = 0;
        double LowPriority = 0;

        if (dt.Rows.Count > 0)
        {
            Open = Convert.ToDouble(dt.Rows[0]["OpenTickets"]);
            Hold = Convert.ToDouble(dt.Rows[0]["HoldTickets"]);
            Wip = Convert.ToDouble(dt.Rows[0]["WIPTickets"]);
            Closed = Convert.ToDouble(dt.Rows[0]["ClosedTickets"]);
            Resolved = Convert.ToDouble(dt.Rows[0]["ResolvedTickets"]);
            TotalTicket = Convert.ToDouble(dt.Rows[0]["TotalTickets"]);
            ServerityS1 = Convert.ToDouble(dt.Rows[0]["S1Tickets"]);
            ServerityS2 = Convert.ToDouble(dt.Rows[0]["S2Tickets"]);
            ServerityS3 = Convert.ToDouble(dt.Rows[0]["S3Tickets"]);

            HighPriority = Convert.ToDouble(dt.Rows[0]["HighPriority"]);
            MediumPriority = Convert.ToDouble(dt.Rows[0]["MediumPriority"]);
            LowPriority = Convert.ToDouble(dt.Rows[0]["LowPriority"]);

            OpenPer = (Open / TotalTicket) * 100;
            HoldPer = (Hold / TotalTicket) * 100;
            WipPer = (Wip / TotalTicket) * 100;
            ClosedPer = (Closed / TotalTicket) * 100;
            ResolvedPer = (Resolved / TotalTicket) * 100;

            OpenPer = Math.Round(OpenPer, 2);
            HoldPer = Math.Round(HoldPer, 2);
            WipPer = Math.Round(WipPer, 2);
            ClosedPer = Math.Round(ClosedPer, 2);
            ResolvedPer = Math.Round(ResolvedPer, 2);
        }
        lbltot.Text = Convert.ToString(TotalTicket);
        lblOpen.Text = Convert.ToString(Open);
        lblHold.Text = Convert.ToString(Hold);
        lblWip.Text = Convert.ToString(Wip);
        lblClosed.Text = Convert.ToString(Closed);
        lblResolved.Text = Convert.ToString(Resolved);

        lblOpenPer.Text = Convert.ToString(OpenPer + "%");
        lblHoldPer.Text = Convert.ToString(HoldPer + "%");
        lblWipPer.Text = Convert.ToString(WipPer + "%");
        lblClosedPer.Text = Convert.ToString(ClosedPer + "%");
        lblResolvedPer.Text = Convert.ToString(ResolvedPer + "%");

        hdnSeverityS1.Value = Convert.ToString(ServerityS1);
        hdnSeverityS2.Value = Convert.ToString(ServerityS2);
        hdnSeverityS3.Value = Convert.ToString(ServerityS3);

        hdnLowPriority.Value = Convert.ToString(LowPriority);
        hdnMediumPriority.Value = Convert.ToString(MediumPriority);
        hdnHighPriority.Value = Convert.ToString(HighPriority);


        if (dt1.Rows.Count > 0)
        {
            string chartOptionsScript = GenerateChartOptions(dt1);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "chartScript1", chartOptionsScript, true);
        }
        if (dt2.Rows.Count > 0)
        {
            string chartOptionsScript = GenerateChartLoaction(dt2);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "chartScript2", chartOptionsScript, true);
        }
        if (dt3.Rows.Count > 0)
        {
            string chartOptionsScript = GenerateChartCategory(dt3);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "chartScript3", chartOptionsScript, true);
        }
        if (dt4.Rows.Count > 0)
        {
            string chartOptionsScript = GenerateChartAssigne(dt4);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "chartScript4", chartOptionsScript, true);
        }
    }
    #region Day Wise Ticket Start
    public static string GenerateChartOptions(DataTable dt)
    {
        var chartData = new ChartData
        {
            DayWiseTotTicket = dt.AsEnumerable().Select(row => row.Field<DateTime>("TicketDate").ToString("yyyy-MM-dd")).ToArray(),
            DayTotalTickets = dt.AsEnumerable().Select(row => row.Field<int>("TotalTickets")).ToArray()
        };

        var serializer = new JavaScriptSerializer();
        string daywise = serializer.Serialize(chartData.DayWiseTotTicket);
        string totalTicketsJson = serializer.Serialize(chartData.DayTotalTickets);
        string chartOptions = $@"
var options = {{
    series: [{{
        name: 'Total Tickets',
        data: {totalTicketsJson}
    }}],
    chart: {{
        foreColor: '#9ba7b2',
        height: 250,
        type: 'bar',
        zoom: {{
            enabled: false
        }},
        toolbar: {{
            show: false,
        }}
    }},
    fill: {{
        type: 'gradient',
        gradient: {{
            shade: 'dark',
            gradientToColors: ['#00c6fb'],
            shadeIntensity: 1,
            type: 'vertical',
            stops: [0, 100, 100, 100]
        }},
    }},
    colors: ['#005bea'],
    plotOptions: {{
        bar: {{
            horizontal: false,
            borderRadius: 4,
            borderRadiusApplication: 'around',
            borderRadiusWhenStacked: 'last',
            columnWidth: '35%',
        }}
    }},
    dataLabels: {{
        enabled: false
    }},
    stroke: {{
        show: true,
        width: 4,
        colors: ['transparent']
    }},
    grid: {{
        show: true,
        borderColor: 'rgba(0, 0, 0, 0.15)',
        strokeDashArray: 4,
    }},
    tooltip: {{
        theme: 'dark',
    }},
    xaxis: {{
        categories: {daywise},
 labels: {{
                    show: false  // Hide the x-axis labels
                }}
    }}
}};

var chart = new ApexCharts(document.querySelector('#chart3a'), options);
chart.render();
";

        return chartOptions;
    }
    #endregion Day Wise Ticket End

    #region CategoryWise Start
    public static string GenerateChartCategory(DataTable dt)
    {
        var chartData = new ChartData
        {
            Categories = dt.AsEnumerable().Select(row => row.Field<string>("Category")).ToArray(),
            CategTotalTickets = dt.AsEnumerable().Select(row => row.Field<int>("TotalTickets")).ToArray()
        };
        var serializer = new JavaScriptSerializer();
        string categoriesJson = serializer.Serialize(chartData.Categories);
        string totalTicketsJson = serializer.Serialize(chartData.CategTotalTickets);
        string chartOptions = $@"
 var options = {{
            series: [{{
                name: 'Total Tickets',
                data: {totalTicketsJson}

            }}],
            chart: {{
                foreColor: '#9ba7b2',
                height: 250,
                type: 'bar',
                zoom: {{
                    enabled: false
                }},
                toolbar: {{
                    show: !1,
                }}
            }},
            fill: {{
                type: 'gradient',
                gradient: {{
                    shade: 'dark',
                    gradientToColors: ['#009efd'],
                    shadeIntensity: 1,
                    type: 'vertical',
                    //opacityFrom: 0.8,
                    //opacityTo: 0.1,
                    stops: [0, 100, 100, 100]
                }},
            }},
            colors: ['#2af598'],
            plotOptions: {{
                bar: {{
                    horizontal: false,
                    borderRadius: 4,
                    borderRadiusApplication: 'around',
                    borderRadiusWhenStacked: 'last',
                    columnWidth: '35%',
                }}
            }},
            dataLabels: {{
                enabled: false
            }},
            stroke: {{
                show: !0,
                width: 4,
                colors: ['transparent']
            }},
            grid: {{
                show: true,
                borderColor: 'rgba(0, 0, 0, 0.15)',
                strokeDashArray: 4,
            }},
            tooltip: {{
                theme: 'dark',
            }},
            xaxis: {{
                categories: {categoriesJson},
 labels: {{
                    show: false  // Hide the x-axis labels
                }}
            }}
        }};

        var chart = new ApexCharts(document.querySelector('#chart3'), options);
        chart.render();
";

        return chartOptions;
    }
    #endregion CategoryWise End

    #region LoactionWise Start
    public static string GenerateChartLoaction(DataTable dt)
    {
        var chartData = new ChartData
        {
            LocationName = dt.AsEnumerable().Select(row => row.Field<string>("LocName")).ToArray(),
            LocNameTotalTickets = dt.AsEnumerable().Select(row => row.Field<int>("TotalTickets")).ToArray()
        };
        var serializer = new JavaScriptSerializer();
        string loactionJson = serializer.Serialize(chartData.LocationName);
        string totalTicketsJson = serializer.Serialize(chartData.LocNameTotalTickets);
        string chartOptions = $@"
 var options = {{
            series: [{{
                name: 'Total Tickets',
                data: {totalTicketsJson}

            }}],
            chart: {{
                foreColor: '#9ba7b2',
                height: 250,
                type: 'bar',
                zoom: {{
                    enabled: false
                }},
                toolbar: {{
                    show: !1,
                }}
            }},
            fill: {{
                type: 'gradient',
                gradient: {{
                    shade: 'dark',
                    gradientToColors: ['#7928ca'],
                    shadeIntensity: 1,
                    type: 'vertical',
                    //opacityFrom: 0.8,
                    //opacityTo: 0.1,
                    stops: [0, 100, 100, 100]
                }},
            }},
            colors: ['#ff0080'],
            plotOptions: {{
                bar: {{
                    horizontal: false,
                    borderRadius: 4,
                    borderRadiusApplication: 'around',
                    borderRadiusWhenStacked: 'last',
                    columnWidth: '35%',
                }}
            }},
            dataLabels: {{
                enabled: false
            }},
            stroke: {{
                show: !0,
                width: 4,
                colors: ['transparent']
            }},
            grid: {{
                show: true,
                borderColor: 'rgba(0, 0, 0, 0.15)',
                strokeDashArray: 4,
            }},
            tooltip: {{
                theme: 'dark',
            }},
            xaxis: {{
                categories: {loactionJson},
                labels: {{
                    show: false  // Hide the x-axis labels
                }}
            }}
        }};

        var chart = new ApexCharts(document.querySelector('#chart3b'), options);
        chart.render();
";

        return chartOptions;
    }
    #endregion LoactionWise End

    #region AssigneWise Start
    public static string GenerateChartAssigne(DataTable dt)
    {
        var chartData = new ChartData
        {
            AssigneWise = dt.AsEnumerable().Select(row => row.Field<string>("Technician")).ToArray(),
            AssigneTotalTickets = dt.AsEnumerable().Select(row => row.Field<int>("TotalTickets")).ToArray()
        };
        var serializer = new JavaScriptSerializer();
        string AssigneJson = serializer.Serialize(chartData.AssigneWise);
        string totalTicketsJson = serializer.Serialize(chartData.AssigneTotalTickets);
        string chartOptions = $@"
 var options = {{
            series: [{{
                name: 'Total Tickets',
                data: {totalTicketsJson}

            }}],
            chart: {{
                foreColor: '#9ba7b2',
                height: 250,
                type: 'bar',
                zoom: {{
                    enabled: false
                }},
                toolbar: {{
                    show: !1,
                }}
            }},
            fill: {{
                type: 'gradient',
                gradient: {{
                    shade: 'dark',
                    gradientToColors: ['#ffd200'],
                    shadeIntensity: 1,
                    type: 'vertical',
                    //opacityFrom: 0.8,
                    //opacityTo: 0.1,
                    stops: [0, 100, 100, 100]
                }},
            }},
            colors: ['#ff6a00'],
            plotOptions: {{
                bar: {{
                    horizontal: false,
                    borderRadius: 4,
                    borderRadiusApplication: 'around',
                    borderRadiusWhenStacked: 'last',
                    columnWidth: '35%',
                }}
            }},
            dataLabels: {{
                enabled: false
            }},
            stroke: {{
                show: !0,
                width: 4,
                colors: ['transparent']
            }},
            grid: {{
                show: true,
                borderColor: 'rgba(0, 0, 0, 0.15)',
                strokeDashArray: 4,
            }},
            tooltip: {{
                theme: 'dark',
            }},
            xaxis: {{
                categories: {AssigneJson},
 labels: {{
                    show: false  // Hide the x-axis labels
                }}

            }}
        }};

        var chart = new ApexCharts(document.querySelector('#chart3c'), options);
        chart.render();
";

        return chartOptions;
    }
    #endregion AssigneWise End

    public class ChartData
    {
        public string[] DayWiseTotTicket { get; set; }
        public int[] DayTotalTickets { get; set; }
        public string[] Categories { get; set; }
        public int[] CategTotalTickets { get; set; }
        public string[] LocationName { get; set; }
        public int[] LocNameTotalTickets { get; set; }
        public string[] AssigneWise { get; set; }
        public int[] AssigneTotalTickets { get; set; }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            string fromd = txtfrmDate.Text;
            DateTime frmdate = DateTime.ParseExact(fromd, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            string formattedFromDate = frmdate.ToString("yyyy-MM-dd");
            string to = txttoDate.Text;
            DateTime todate = DateTime.ParseExact(to, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            string formattedToDate = todate.ToString("yyyy-MM-dd");
            string category = ddlCategory.SelectedValue;
            if (string.IsNullOrEmpty(category))
            {
                category = "0";
            }
            getFilterData(ddlRequestType.SelectedValue, category, formattedFromDate, formattedToDate, "", "");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddlRequestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillCategory(Convert.ToString(Session["OrgID"]), Convert.ToString(ddlRequestType.SelectedItem.Text));
            getFilterData("0", "0", Convert.ToString("1900-01-01"), Convert.ToString("1900-01-01"), "", "");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
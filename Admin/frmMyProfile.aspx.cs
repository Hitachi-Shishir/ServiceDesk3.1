using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class Admin_frmMyProfile : System.Web.UI.Page
{
    InsertErrorLogs inEr = new InsertErrorLogs();
    errorMessage msg = new errorMessage();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                if (Session["LoginName"] != null && Session["UserScope"] != null)
                {

                    FillAssetDetails();

                    FillImage();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
    $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);

        }
    }
    protected void FillImage()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select  * from SD_User_Master  where  LoginName=@Username", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Username", Session["UserName"].ToString());
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {

                                if (string.IsNullOrEmpty(dt.Rows[0]["FileData"].ToString()))
                                {
                                    img.ImageUrl = "~/dist/img/user1-128x128.jpg";
                                }

                                else
                                {
                                    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dt.Rows[0]["FileData"]);
                                    //txtAccountManagerEmail.Text = dt.Rows[0]["FileData"].ToString();

                                    if (string.IsNullOrEmpty(imageUrl))
                                    {
                                        img.ImageUrl = "~/dist/img/user1-128x128.jpg";
                                    }
                                    else
                                    {
                                        img.ImageUrl = imageUrl;
                                        showimg.ImageUrl = imageUrl;
                                    }

                                }
                            }
                            else
                            {
                                img.ImageUrl = "~/dist/img/user1-128x128.jpg";

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
    private void FillAssetDetails()
    {
        try
        {

            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(" select *  FROM  SD_vUser where LoginName=@Username", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Username", Session["UserName"].ToString());

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            DetailsCheckInAsset.DataSource = dt;
                            DetailsCheckInAsset.DataBind();
                        }
                        else
                        {
                            DetailsCheckInAsset.DataSource = dt;
                            DetailsCheckInAsset.DataBind();
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification",
     $"error_noti(); setTimeout(function() {{ window.location.reload(); }}, 2000);", true);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Byte[] bytes;
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string contentType = FileUpload1.PostedFile.ContentType;

        string filePath = FileUpload1.PostedFile.FileName;

        System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
        using (System.Drawing.Image thumbnail = image.GetThumbnailImage(120, 120, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                thumbnail.Save(memoryStream, ImageFormat.Png);
                bytes = new Byte[memoryStream.Length];
                memoryStream.Position = 0;
                memoryStream.Read(bytes, 0, (int)bytes.Length);
            }
        }
        //using (Stream fs = FileUpload1.PostedFile.InputStream)
        //{
        //	using (BinaryReader br = new BinaryReader(fs))
        //	{
        //byte[] bytes = br.ReadBytes((Int32)fs.Length);
        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            string query = @"update  SD_User_Master set FileName=@FileName,@FileType=@FileType,   FileData  = @FileData where LoginName=@Username";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@FileName", filename);
                cmd.Parameters.AddWithValue("@FileType", contentType);
                cmd.Parameters.AddWithValue("@FileData", bytes);
                cmd.Parameters.AddWithValue("@Username", Session["UserName"].ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + HttpUtility.JavaScriptStringEncode("Uploaded Successfully !") + "');window.location ='frmMyProfile.aspx';", true);
            }
        }
    }
    public bool ThumbnailCallback()
    {
        return false;
    }

    protected void DetailsCheckInAsset_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
}
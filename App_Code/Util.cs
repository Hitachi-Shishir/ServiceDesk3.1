using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using Nest;
public class Util
{
    InsertErrorLogs inEr = new InsertErrorLogs();
    public string InsertInsertTechLeave(string TechId, string TechName, DateTime LeaveFromdate,
        DateTime LeaveTodate, string AppliedbyUserid)
    {
        string msg = "";
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_InsertTechLeave";
                cmd.Parameters.AddWithValue("@TechId", TechId);
                cmd.Parameters.AddWithValue("@TechName", TechName);
                cmd.Parameters.AddWithValue("@LeaveFromdate", LeaveFromdate);
                cmd.Parameters.AddWithValue("@LeaveTodate", LeaveTodate);
                cmd.Parameters.AddWithValue("@AppliedbyUserid", AppliedbyUserid);
                cmd.ExecuteNonQuery();
                msg = "Success!";
            }
        }
        catch (Exception ex)
        {
            inEr.InsertErrorLogsF(AppliedbyUserid, ex.ToString());
        }
        return msg;
    }
    public void InsertSlaLog(string TableId, string OrgId, string UserID, string SLAName, string SLADesc)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableId", TableId);
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmAddSLA");
                cmd.Parameters.AddWithValue("@SLAName", SLAName);
                cmd.Parameters.AddWithValue("@SLADesc", SLADesc);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertCategoryLog(string OrgId, string UserID, string ReqType, string CategoryRef,
        string CategoryCodeRef)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmAddCategory");
                cmd.Parameters.AddWithValue("@ReqType", ReqType);
                cmd.Parameters.AddWithValue("@CategoryRef", CategoryRef);
                cmd.Parameters.AddWithValue("@CategoryCodeRef", CategoryCodeRef);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertDesktempLog(string TableId, string OrgId, string UserID, string ReqType, string TemplateName,
        string SDPrefix, string DeskDesc, string SDCategory, string StageName, string StatusName, string PriorityName,
        string SeverityName, string ResolutionName, string ArchiveTime, string CoverageSch)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableId", TableId);
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmAddServiceDeskName");
                cmd.Parameters.AddWithValue("@ReqType", ReqType);
                cmd.Parameters.AddWithValue("@TemplateName", TemplateName);
                cmd.Parameters.AddWithValue("@SDPrefix", SDPrefix);
                cmd.Parameters.AddWithValue("@DeskDesc", DeskDesc);
                cmd.Parameters.AddWithValue("@SDCategory", SDCategory);
                cmd.Parameters.AddWithValue("@StageName", StageName);
                cmd.Parameters.AddWithValue("@StatusName", StatusName);
                cmd.Parameters.AddWithValue("@PriorityName", PriorityName);
                cmd.Parameters.AddWithValue("@SeverityName", SeverityName);
                cmd.Parameters.AddWithValue("@ResolutionName", ResolutionName);
                cmd.Parameters.AddWithValue("@ArchiveTime", ArchiveTime);
                cmd.Parameters.AddWithValue("@CoverageSch", CoverageSch);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertEmailConfigLog(string TableId, string OrgId, string UserID, string HostName, string Port,
        string SenderUserName, string SenderEmail, string SenderPWD, string Retry, string ClientID, string ClientSecretKey,
        string TenantID)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableId", TableId);
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmEmailConfigratn");
                cmd.Parameters.AddWithValue("@HostName", HostName);
                cmd.Parameters.AddWithValue("@Port", Port);
                cmd.Parameters.AddWithValue("@SenderUserName", SenderUserName);
                cmd.Parameters.AddWithValue("@SenderEmail", SenderEmail);
                cmd.Parameters.AddWithValue("@SenderPWD", SenderPWD);
                cmd.Parameters.AddWithValue("@Retry", Retry);
                cmd.Parameters.AddWithValue("@ClientID", ClientID);
                cmd.Parameters.AddWithValue("@ClientSecretKey", ClientSecretKey);
                cmd.Parameters.AddWithValue("@TenantID", TenantID);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertOrganizationLog(string OrgId, string UserID, string OrgName, string OrgDesc,
        string ContPersonName, string ContPersonMob, string ContPersonEmail, string ContPersonNameII,
        string ContPersonMobII, string ContPersonEmailII)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmAddOrganization");
                cmd.Parameters.AddWithValue("@OrgName", OrgName);
                cmd.Parameters.AddWithValue("@OrgDesc", OrgDesc);
                cmd.Parameters.AddWithValue("@ContPersonName", ContPersonName);
                cmd.Parameters.AddWithValue("@ContPersonMob", ContPersonMob);
                cmd.Parameters.AddWithValue("@ContPersonEmail", ContPersonEmail);
                cmd.Parameters.AddWithValue("@ContPersonNameII", ContPersonNameII);
                cmd.Parameters.AddWithValue("@ContPersonMobII", ContPersonMobII);
                cmd.Parameters.AddWithValue("@ContPersonEmailII", ContPersonEmailII);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertPriorityLog(string OrgId, string UserID, string ReqType, string PriorityName,
        string PriorityDesc)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmAddSDPriority");
                cmd.Parameters.AddWithValue("@ReqType", ReqType);
                cmd.Parameters.AddWithValue("@PriorityName", PriorityName);
                cmd.Parameters.AddWithValue("@PriorityDesc", PriorityDesc);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertReqTypeLog(string TableId, string OrgId, string UserID, string ReqType, string ReqDef)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableId", TableId);
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmAddRequestType");
                cmd.Parameters.AddWithValue("@ReqType", ReqType);
                cmd.Parameters.AddWithValue("@ReqDef", ReqDef);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertResolutionTypeLog(string OrgId, string UserID, string ReqType, string ResolutionName,
        string ResolutionDesc)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmResolutionType");
                cmd.Parameters.AddWithValue("@ReqType", ReqType);
                cmd.Parameters.AddWithValue("@ResolutionName", ResolutionName);
                cmd.Parameters.AddWithValue("@ResolutionDesc", ResolutionDesc);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertCustomFieldCnrtlLog(string TableId, string OrgId, string UserID, string ReqType, string FieldID,
        string FieldName, string FieldMode, string FieldValue, string FieldType, string IsFieldReq,
        string FieldScope, string Status)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableId", TableId);
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmSDCustomFieldCnrtl");
                cmd.Parameters.AddWithValue("@ReqType", ReqType);
                cmd.Parameters.AddWithValue("@FieldID", FieldID);
                cmd.Parameters.AddWithValue("@FieldName", FieldName);
                cmd.Parameters.AddWithValue("@FieldMode", FieldMode);
                cmd.Parameters.AddWithValue("@FieldValue", FieldValue);
                cmd.Parameters.AddWithValue("@FieldType", FieldType);
                cmd.Parameters.AddWithValue("@IsFieldReq", IsFieldReq);
                cmd.Parameters.AddWithValue("@FieldScope", FieldScope);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertSeverityLog(string TableId, string OrgId, string UserID, string ReqType,
        string SeverityName, string SeverityDesc, string ResponseTimeMin, string ResolutionTimeMin)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableId", TableId);
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmAddSeverity");
                cmd.Parameters.AddWithValue("@ReqType", ReqType);
                cmd.Parameters.AddWithValue("@SeverityName", SeverityName);
                cmd.Parameters.AddWithValue("@SeverityDesc", SeverityDesc);
                cmd.Parameters.AddWithValue("@ResponseTimeMin", ResponseTimeMin);
                cmd.Parameters.AddWithValue("@ResolutionTimeMin", ResolutionTimeMin);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertStageLog(string TableId, string OrgId, string UserID, string ReqType,
            string StageName, string StageDesc)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableId", TableId);
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmAddSDStage");
                cmd.Parameters.AddWithValue("@ReqType", ReqType);
                cmd.Parameters.AddWithValue("@StageName", StageName);
                cmd.Parameters.AddWithValue("@StageDesc", StageDesc);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void InsertStatusLog(string TableId, string OrgId, string UserID, string ReqType,
            string StageName, string StatusName, string StatusDesc, string ColorCode)
    {
        try
        {
            using (SqlConnection cnn = new SqlConnection(database.GetConnectstring()))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandTimeout = 3600;
                cmd.CommandText = "SP_InsertCommonLog";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableId", TableId);
                cmd.Parameters.AddWithValue("@OrgId", OrgId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PageName", "frmAddSDStage");
                cmd.Parameters.AddWithValue("@ReqType", ReqType);
                cmd.Parameters.AddWithValue("@StatusName", StatusName);
                cmd.Parameters.AddWithValue("@StatusDesc", StatusDesc);
                cmd.Parameters.AddWithValue("@ColorCode", ColorCode);
                cmd.Parameters.AddWithValue("@StageName", StageName);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
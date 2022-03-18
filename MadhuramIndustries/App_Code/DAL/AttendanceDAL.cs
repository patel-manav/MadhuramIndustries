using MadhuramIndustries.App_Code;
using MadhuramIndustries.App_Code.ENT;
using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AttendanceDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class AttendanceDAL : DatabaseConfig
    {
        #region Local variables

        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local variables

        #region Constructor
        public AttendanceDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(AttendanceENT entAttendance)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Attendance_Insert";
                        
                        objCmd.Parameters.AddWithValue("@EmployeeID", entAttendance.EmployeeID);
                        objCmd.Parameters.AddWithValue("@InTime", entAttendance.InTime);
                        objCmd.Parameters.AddWithValue("@OutTime", entAttendance.OutTime);
                        objCmd.Parameters.AddWithValue("@AttendanceDate", entAttendance.AttendanceDate);
                        objCmd.Parameters.AddWithValue("@FlagReset", entAttendance.FlagReset);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entAttendance.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entAttendance.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entAttendance.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entAttendance.CreateBy);
                        objCmd.Parameters.AddWithValue("@OverTimeHours", entAttendance.OverTimeHours);
                        objCmd.Parameters.AddWithValue("@TotalWorkedHours", entAttendance.TotalWorkedHours);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entAttendance.AttendanceID = Convert.ToInt32(objCmd.Parameters["@AttendanceID"].Value);

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }

        #endregion Insert Operation

        #region Update Operation

        public Boolean Update(AttendanceENT entAttendance)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Attendance_Update";

                        objCmd.Parameters.AddWithValue("@AttendanceID", entAttendance.AttendanceID);
                        objCmd.Parameters.AddWithValue("@EmployeeID", entAttendance.EmployeeID);
                        objCmd.Parameters.AddWithValue("@InTime", entAttendance.InTime);
                        objCmd.Parameters.AddWithValue("@OutTime", entAttendance.OutTime);
                        objCmd.Parameters.AddWithValue("@AttendanceDate", entAttendance.AttendanceDate);
                        objCmd.Parameters.AddWithValue("@FlagReset", entAttendance.FlagReset);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entAttendance.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entAttendance.ModifyBy);
                        objCmd.Parameters.AddWithValue("@OverTimeHours", entAttendance.OverTimeHours);
                        objCmd.Parameters.AddWithValue("@TotalWorkedHours", entAttendance.TotalWorkedHours);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }

        #endregion Update Operation

        #region Delete Operation

        public Boolean Delete(SqlInt32 AttendanceID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Attendance_Delete";
                        
                        objCmd.Parameters.AddWithValue("@AttendanceID", AttendanceID);            
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Delete Operation

        #region Select Operation
        
        #region Select
        public DataTable Select()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Attendance_Select";

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Select

        #region Select PK
        public AttendanceENT SelectPK(SqlInt32 AttendanceID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Variables
						DataTable dt = new DataTable();
                        AttendanceENT entAttendance = new AttendanceENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Attendance_SelectPK";
                        objCmd.Parameters.AddWithValue("@AttendanceID", AttendanceID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["AttendanceID"].Equals(DBNull.Value))
                            {
                                entAttendance.AttendanceID = Convert.ToInt32(dr["AttendanceID"]);
                            }

                            if (!dr["EmployeeID"].Equals(DBNull.Value))
                            {
                                entAttendance.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                            }

                            if (!dr["InTime"].Equals(DBNull.Value))
                            {
                                entAttendance.InTime = Convert.ToDateTime(dr["InTime"]);
                            }

                            if (!dr["OutTime"].Equals(DBNull.Value))
                            {
                                entAttendance.OutTime = Convert.ToDateTime(dr["OutTime"]);
                            }

                            if (!dr["AttendanceDate"].Equals(DBNull.Value))
                            {
                                entAttendance.AttendanceDate = Convert.ToDateTime(dr["AttendanceDate"]);
                            }

                            if (!dr["FlagReset"].Equals(DBNull.Value))
                            {
                                entAttendance.FlagReset = Convert.ToInt32(dr["FlagReset"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entAttendance.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entAttendance.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entAttendance.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entAttendance.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }

                            if (!dr["OverTimeHours"].Equals(DBNull.Value))
                            {
                                entAttendance.OverTimeHours = Convert.ToInt32(dr["OverTimeHours"]);
                            }

                            if (!dr["TotalWorkedHours"].Equals(DBNull.Value))
                            {
                                entAttendance.TotalWorkedHours = Convert.ToDecimal(dr["TotalWorkedHours"]);
                            }
                        }
						return entAttendance;

                        #endregion Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Select PK
        
        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Attendance_SelectForDropDown";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }

        #endregion Select For Dropdownlist

        //#region SalaryReport For RDLC
        //public DataTable SelectForSalaryReport(SqlDateTime FromDate, SqlDateTime ToDate, SqlInt32 EmployeeID)
        //{
        //    using (SqlConnection objConn = new SqlConnection(ConnectionString))
        //    {
        //        if (objConn.State != ConnectionState.Open)
        //            objConn.Open();

        //        using (SqlCommand objCmd = objConn.CreateCommand())
        //        {
        //            try
        //            {
        //                #region Prepare Command
        //                objCmd.CommandType = CommandType.StoredProcedure;
        //                objCmd.CommandText = "PR_Attandance_SelectForSalaryReport";
        //                objCmd.Parameters.AddWithValue("@FromDate", FromDate);
        //                objCmd.Parameters.AddWithValue("@ToDate", ToDate);
        //                objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);


        //                #endregion Prepare Command

        //                #region ReadData and Set Controls
        //                DataTable dt = new DataTable();
        //                using (SqlDataReader objSDR = objCmd.ExecuteReader())
        //                {
        //                    dt.Load(objSDR);
        //                }
        //                return dt;

        //                #endregion ReadData and Set Controls
        //            }

        //            catch (SqlException sqlex)
        //            {
        //                Message = sqlex.Message.ToString();
        //                return null;
        //            }

        //            catch (Exception ex)
        //            {
        //                Message = ex.Message.ToString();
        //                return null;
        //            }

        //            finally
        //            {
        //                if (objConn.State == ConnectionState.Open)
        //                    objConn.Close();
        //            }
        //        }

        //    }
        //}
        //#endregion SalaryReport For RDLC

        #region SalaryReport Normal
        public DataTable SelectForSalaryReport(SqlDateTime FromDate, SqlDateTime ToDate, SqlInt32 EmployeeID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Attandance_SelectForSalaryReport";
                        objCmd.Parameters.AddWithValue("@FromDate", FromDate);
                        objCmd.Parameters.AddWithValue("@ToDate", ToDate);
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion SalaryReport Normal
        #endregion Select Operation
    }
}

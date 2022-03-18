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
/// Summary description for EmployeeDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class EmployeeDAL : DatabaseConfig
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
        public EmployeeDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(EmployeeENT entEmployee)
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
                        objCmd.CommandText = "PR_Employee_Insert";
                        
                        objCmd.Parameters.AddWithValue("@EmployeeName", entEmployee.EmployeeName);
                        objCmd.Parameters.AddWithValue("@EmployeeCardNumber", entEmployee.EmployeeCardNumber);
                        objCmd.Parameters.AddWithValue("@EmployeeMobileNumber", entEmployee.EmployeeMobileNumber);
                        objCmd.Parameters.AddWithValue("@EmployeeCity", entEmployee.EmployeeCity);
                        objCmd.Parameters.AddWithValue("@EmployeeDOB", entEmployee.EmployeeDOB);
                        objCmd.Parameters.AddWithValue("@EmployeeAddress", entEmployee.EmployeeAddress);
                        objCmd.Parameters.AddWithValue("@EmployeeGender", entEmployee.EmployeeGender);
                        objCmd.Parameters.AddWithValue("@EmployeeSalary", entEmployee.EmployeeSalary);
                        objCmd.Parameters.AddWithValue("@EmployeeWorkTime", entEmployee.EmployeeWorkTime);
                        objCmd.Parameters.AddWithValue("@EmployeeOverTimeSalary", entEmployee.EmployeeOverTimeSalary);
                        objCmd.Parameters.AddWithValue("@DesignationID", entEmployee.DesignationID);
                        objCmd.Parameters.AddWithValue("@EmployeeIDProof", entEmployee.EmployeeIDProof);
                        objCmd.Parameters.AddWithValue("@EmployeeIDProofExtension", entEmployee.EmployeeIDProofExtension);
                        objCmd.Parameters.AddWithValue("@EmployeeIDProofType", entEmployee.EmployeeIDProofType);
                        objCmd.Parameters.AddWithValue("@EmployeeRemark", entEmployee.EmployeeRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entEmployee.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entEmployee.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entEmployee.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entEmployee.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entEmployee.FlagDelete);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entEmployee.EmployeeID = Convert.ToInt32(objCmd.Parameters["@EmployeeID"].Value);

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

        public Boolean Update(EmployeeENT entEmployee)
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
                        objCmd.CommandText = "PR_Employee_Update";

                        objCmd.Parameters.AddWithValue("@EmployeeID", entEmployee.EmployeeID);
                        objCmd.Parameters.AddWithValue("@EmployeeName", entEmployee.EmployeeName);
                        objCmd.Parameters.AddWithValue("@EmployeeCardNumber", entEmployee.EmployeeCardNumber);
                        objCmd.Parameters.AddWithValue("@EmployeeMobileNumber", entEmployee.EmployeeMobileNumber);
                        objCmd.Parameters.AddWithValue("@EmployeeCity", entEmployee.EmployeeCity);
                        objCmd.Parameters.AddWithValue("@EmployeeDOB", entEmployee.EmployeeDOB);
                        objCmd.Parameters.AddWithValue("@EmployeeAddress", entEmployee.EmployeeAddress);
                        objCmd.Parameters.AddWithValue("@EmployeeGender", entEmployee.EmployeeGender);
                        objCmd.Parameters.AddWithValue("@EmployeeSalary", entEmployee.EmployeeSalary);
                        objCmd.Parameters.AddWithValue("@EmployeeWorkTime", entEmployee.EmployeeWorkTime);
                        objCmd.Parameters.AddWithValue("@EmployeeOverTimeSalary", entEmployee.EmployeeOverTimeSalary);
                        objCmd.Parameters.AddWithValue("@DesignationID", entEmployee.DesignationID);
                        objCmd.Parameters.AddWithValue("@EmployeeIDProof", entEmployee.EmployeeIDProof);
                        objCmd.Parameters.AddWithValue("@EmployeeIDProofExtension", entEmployee.EmployeeIDProofExtension);
                        objCmd.Parameters.AddWithValue("@EmployeeIDProofType", entEmployee.EmployeeIDProofType);
                        objCmd.Parameters.AddWithValue("@EmployeeRemark", entEmployee.EmployeeRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entEmployee.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entEmployee.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entEmployee.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entEmployee.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entEmployee.FlagDelete);

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

        public Boolean Delete(SqlInt32 EmployeeID)
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
                        objCmd.CommandText = "PR_Employee_Delete";
                        
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);            
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
                        objCmd.CommandText = "PR_Employee_Select";

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
        public EmployeeENT SelectPK(SqlInt32 EmployeeID)
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
                        EmployeeENT entEmployee = new EmployeeENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Employee_SelectPK";
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["EmployeeID"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                            }

                            if (!dr["EmployeeName"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeName = Convert.ToString(dr["EmployeeName"]);
                            }

                            if (!dr["EmployeeCardNumber"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeCardNumber = Convert.ToString(dr["EmployeeCardNumber"]);
                            }

                            if (!dr["EmployeeMobileNumber"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeMobileNumber = Convert.ToString(dr["EmployeeMobileNumber"]);
                            }

                            if (!dr["EmployeeCity"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeCity = Convert.ToString(dr["EmployeeCity"]);
                            }

                            if (!dr["EmployeeDOB"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeDOB = Convert.ToDateTime(dr["EmployeeDOB"]);
                            }

                            if (!dr["EmployeeAddress"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeAddress = Convert.ToString(dr["EmployeeAddress"]);
                            }

                            if (!dr["EmployeeGender"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeGender = Convert.ToString(dr["EmployeeGender"]);
                            }

                            if (!dr["EmployeeSalary"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeSalary = Convert.ToInt32(dr["EmployeeSalary"]);
                            }

                            if (!dr["EmployeeWorkTime"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeWorkTime = Convert.ToInt32(dr["EmployeeWorkTime"]);
                            }

                            if (!dr["EmployeeOverTimeSalary"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeOverTimeSalary = Convert.ToInt32(dr["EmployeeOverTimeSalary"]);
                            }

                            if (!dr["DesignationID"].Equals(DBNull.Value))
                            {
                                entEmployee.DesignationID = Convert.ToInt32(dr["DesignationID"]);
                            }

                            if (!dr["EmployeeIDProof"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeIDProof = ((byte[])dr["EmployeeIDProof"]);
                            }

                            if (!dr["EmployeeIDProofExtension"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeIDProofExtension = Convert.ToString(dr["EmployeeIDProofExtension"]);
                            }

                            if (!dr["EmployeeIDProofType"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeIDProofType = Convert.ToString(dr["EmployeeIDProofType"]);
                            }

                            if (!dr["EmployeeRemark"].Equals(DBNull.Value))
                            {
                                entEmployee.EmployeeRemark = Convert.ToString(dr["EmployeeRemark"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entEmployee.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entEmployee.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entEmployee.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entEmployee.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }

                            if (!dr["FlagDelete"].Equals(DBNull.Value))
                            {
                                entEmployee.FlagDelete = Convert.ToBoolean(dr["FlagDelete"]);
                            }
						}
						return entEmployee;

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
                        objCmd.CommandText = "PR_Employee_SelectForDropDown";
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

        #region Select
        public DataTable SelectAttendance(DateTime AttendanceDate)
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
                        objCmd.CommandText = "PR_Employee_SelectForAttendance";

                        objCmd.Parameters.AddWithValue("@AttendanceDate", AttendanceDate);
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
        #endregion SelectAttendance
        #endregion Select Operation
    }
}

using MadhuramIndustries;
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
/// Summary description for EmployeeDesignationDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class EmployeeDesignationDAL : DatabaseConfig
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
        public EmployeeDesignationDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(EmployeeDesignationENT entEmployeeDesignation)
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
                        objCmd.CommandText = "PR_EmployeeDesignation_Insert";
                        
                        objCmd.Parameters.AddWithValue("@EmployeeDesignationName", entEmployeeDesignation.EmployeeDesignationName);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entEmployeeDesignation.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entEmployeeDesignation.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entEmployeeDesignation.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entEmployeeDesignation.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entEmployeeDesignation.FlagDelete);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entEmployeeDesignation.EmployeeDesignationID = Convert.ToInt32(objCmd.Parameters["@EmployeeDesignationID"].Value);

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

        public Boolean Update(EmployeeDesignationENT entEmployeeDesignation)
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
                        objCmd.CommandText = "PR_EmployeeDesignation_Update";

                        objCmd.Parameters.AddWithValue("@EmployeeDesignationID", entEmployeeDesignation.EmployeeDesignationID);
                        objCmd.Parameters.AddWithValue("@EmployeeDesignationName", entEmployeeDesignation.EmployeeDesignationName);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entEmployeeDesignation.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entEmployeeDesignation.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entEmployeeDesignation.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entEmployeeDesignation.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entEmployeeDesignation.FlagDelete);

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

        public Boolean Delete(SqlInt32 EmployeeDesignationID)
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
                        objCmd.CommandText = "PR_EmployeeDesignation_Delete";
                        
                        objCmd.Parameters.AddWithValue("@EmployeeDesignationID", EmployeeDesignationID);            
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
                        objCmd.CommandText = "PR_EmployeeDesignation_Select";

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
        public EmployeeDesignationENT SelectPK(SqlInt32 EmployeeDesignationID)
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
                        EmployeeDesignationENT entEmployeeDesignation = new EmployeeDesignationENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_EmployeeDesignation_SelectPK";
                        objCmd.Parameters.AddWithValue("@EmployeeDesignationID", EmployeeDesignationID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["EmployeeDesignationID"].Equals(DBNull.Value))
                            {
                                entEmployeeDesignation.EmployeeDesignationID = Convert.ToInt32(dr["EmployeeDesignationID"]);
                            }

                            if (!dr["EmployeeDesignationName"].Equals(DBNull.Value))
                            {
                                entEmployeeDesignation.EmployeeDesignationName = Convert.ToString(dr["EmployeeDesignationName"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entEmployeeDesignation.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entEmployeeDesignation.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entEmployeeDesignation.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entEmployeeDesignation.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }

                            if (!dr["FlagDelete"].Equals(DBNull.Value))
                            {
                                entEmployeeDesignation.FlagDelete = Convert.ToBoolean(dr["FlagDelete"]);
                            }
						}
						return entEmployeeDesignation;

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
                        objCmd.CommandText = "PR_EmployeeDesignation_SelectForDropDown";
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

        #endregion Select Operation
    }
}

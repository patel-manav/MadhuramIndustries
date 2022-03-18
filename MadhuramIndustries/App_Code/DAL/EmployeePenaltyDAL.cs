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
/// Summary description for EmployeePenaltyDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class EmployeePenaltyDAL : DatabaseConfig
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
        public EmployeePenaltyDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(EmployeePenaltyENT entEmployeePenalty)
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
                        objCmd.CommandText = "PR_EmployeePenalty_Insert";
                        
                        objCmd.Parameters.AddWithValue("@EmployeePenaltyDate", entEmployeePenalty.EmployeePenaltyDate);
                        objCmd.Parameters.AddWithValue("@EmployeeID", entEmployeePenalty.EmployeeID);
                        objCmd.Parameters.AddWithValue("@EmployeePenaltyAmount", entEmployeePenalty.EmployeePenaltyAmount);
                        objCmd.Parameters.AddWithValue("@EmployeePenaltyRemark", entEmployeePenalty.EmployeePenaltyRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entEmployeePenalty.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entEmployeePenalty.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entEmployeePenalty.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entEmployeePenalty.CreateBy);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entEmployeePenalty.EmployeePenaltyID = Convert.ToInt32(objCmd.Parameters["@EmployeePenaltyID"].Value);

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

        public Boolean Update(EmployeePenaltyENT entEmployeePenalty)
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
                        objCmd.CommandText = "PR_EmployeePenalty_Update";

                        objCmd.Parameters.AddWithValue("@EmployeePenaltyID", entEmployeePenalty.EmployeePenaltyID);
                        objCmd.Parameters.AddWithValue("@EmployeePenaltyDate", entEmployeePenalty.EmployeePenaltyDate);
                        objCmd.Parameters.AddWithValue("@EmployeeID", entEmployeePenalty.EmployeeID);
                        objCmd.Parameters.AddWithValue("@EmployeePenaltyAmount", entEmployeePenalty.EmployeePenaltyAmount);
                        objCmd.Parameters.AddWithValue("@EmployeePenaltyRemark", entEmployeePenalty.EmployeePenaltyRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entEmployeePenalty.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entEmployeePenalty.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entEmployeePenalty.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entEmployeePenalty.CreateBy);

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

        public Boolean Delete(SqlInt32 EmployeePenaltyID)
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
                        objCmd.CommandText = "PR_EmployeePenalty_Delete";
                        
                        objCmd.Parameters.AddWithValue("@EmployeePenaltyID", EmployeePenaltyID);            
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
                        objCmd.CommandText = "PR_EmployeePenalty_Select";

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
        public EmployeePenaltyENT SelectPK(SqlInt32 EmployeePenaltyID)
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
                        EmployeePenaltyENT entEmployeePenalty = new EmployeePenaltyENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_EmployeePenalty_SelectPK";
                        objCmd.Parameters.AddWithValue("@EmployeePenaltyID", EmployeePenaltyID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["EmployeePenaltyID"].Equals(DBNull.Value))
                            {
                                entEmployeePenalty.EmployeePenaltyID = Convert.ToInt32(dr["EmployeePenaltyID"]);
                            }

                            if (!dr["EmployeePenaltyDate"].Equals(DBNull.Value))
                            {
                                entEmployeePenalty.EmployeePenaltyDate = Convert.ToDateTime(dr["EmployeePenaltyDate"]);
                            }

                            if (!dr["EmployeeID"].Equals(DBNull.Value))
                            {
                                entEmployeePenalty.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                            }

                            if (!dr["EmployeePenaltyAmount"].Equals(DBNull.Value))
                            {
                                entEmployeePenalty.EmployeePenaltyAmount = Convert.ToInt32(dr["EmployeePenaltyAmount"]);
                            }

                            if (!dr["EmployeePenaltyRemark"].Equals(DBNull.Value))
                            {
                                entEmployeePenalty.EmployeePenaltyRemark = Convert.ToString(dr["EmployeePenaltyRemark"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entEmployeePenalty.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entEmployeePenalty.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entEmployeePenalty.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entEmployeePenalty.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }
						}
						return entEmployeePenalty;

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
                        objCmd.CommandText = "PR_EmployeePenalty_SelectForDropDown";
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

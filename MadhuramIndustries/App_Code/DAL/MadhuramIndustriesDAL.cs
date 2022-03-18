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
/// Summary description for MadhuramIndustriesDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class MadhuramIndustriesDAL : DatabaseConfig
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
        public MadhuramIndustriesDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(MadhuramIndustriesENT entMadhuramIndustries)
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
                        objCmd.CommandText = "PR_MadhuramIndustries_Insert";
                        
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesName", entMadhuramIndustries.MadhuramIndustriesName);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesAddress", entMadhuramIndustries.MadhuramIndustriesAddress);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesGSTNumber", entMadhuramIndustries.MadhuramIndustriesGSTNumber);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesPanCardNumber", entMadhuramIndustries.MadhuramIndustriesPanCardNumber);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesMobileNumber", entMadhuramIndustries.MadhuramIndustriesMobileNumber);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesBankName", entMadhuramIndustries.MadhuramIndustriesBankName);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesBankIFSCCode", entMadhuramIndustries.MadhuramIndustriesBankIFSCCode);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesBankAccountNumber", entMadhuramIndustries.MadhuramIndustriesBankAccountNumber);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesBankBranchAddress", entMadhuramIndustries.MadhuramIndustriesBankBranchAddress);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesRemark", entMadhuramIndustries.MadhuramIndustriesRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entMadhuramIndustries.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entMadhuramIndustries.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entMadhuramIndustries.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entMadhuramIndustries.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entMadhuramIndustries.FlagDelete);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entMadhuramIndustries.MadhuramIndustriesID = Convert.ToInt32(objCmd.Parameters["@MadhuramIndustriesID"].Value);

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

        public Boolean Update(MadhuramIndustriesENT entMadhuramIndustries)
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
                        objCmd.CommandText = "PR_MadhuramIndustries_Update";

                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesID", entMadhuramIndustries.MadhuramIndustriesID);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesName", entMadhuramIndustries.MadhuramIndustriesName);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesAddress", entMadhuramIndustries.MadhuramIndustriesAddress);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesGSTNumber", entMadhuramIndustries.MadhuramIndustriesGSTNumber);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesPanCardNumber", entMadhuramIndustries.MadhuramIndustriesPanCardNumber);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesMobileNumber", entMadhuramIndustries.MadhuramIndustriesMobileNumber);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesBankName", entMadhuramIndustries.MadhuramIndustriesBankName);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesBankIFSCCode", entMadhuramIndustries.MadhuramIndustriesBankIFSCCode);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesBankAccountNumber", entMadhuramIndustries.MadhuramIndustriesBankAccountNumber);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesBankBranchAddress", entMadhuramIndustries.MadhuramIndustriesBankBranchAddress);
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesRemark", entMadhuramIndustries.MadhuramIndustriesRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entMadhuramIndustries.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entMadhuramIndustries.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entMadhuramIndustries.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entMadhuramIndustries.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entMadhuramIndustries.FlagDelete);

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

        public Boolean Delete(SqlInt32 MadhuramIndustriesID)
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
                        objCmd.CommandText = "PR_MadhuramIndustries_Delete";
                        
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesID", MadhuramIndustriesID);            
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
                        objCmd.CommandText = "PR_MadhuramIndustries_Select";

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
        public MadhuramIndustriesENT SelectPK(SqlInt32 MadhuramIndustriesID)
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
                        MadhuramIndustriesENT entMadhuramIndustries = new MadhuramIndustriesENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_MadhuramIndustries_SelectPK";
                        objCmd.Parameters.AddWithValue("@MadhuramIndustriesID", MadhuramIndustriesID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["MadhuramIndustriesID"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesID = Convert.ToInt32(dr["MadhuramIndustriesID"]);
                            }

                            if (!dr["MadhuramIndustriesName"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesName = Convert.ToString(dr["MadhuramIndustriesName"]);
                            }

                            if (!dr["MadhuramIndustriesAddress"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesAddress = Convert.ToString(dr["MadhuramIndustriesAddress"]);
                            }

                            if (!dr["MadhuramIndustriesGSTNumber"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesGSTNumber = Convert.ToString(dr["MadhuramIndustriesGSTNumber"]);
                            }

                            if (!dr["MadhuramIndustriesPanCardNumber"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesPanCardNumber = Convert.ToString(dr["MadhuramIndustriesPanCardNumber"]);
                            }

                            if (!dr["MadhuramIndustriesMobileNumber"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesMobileNumber = Convert.ToString(dr["MadhuramIndustriesMobileNumber"]);
                            }

                            if (!dr["MadhuramIndustriesBankName"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesBankName = Convert.ToString(dr["MadhuramIndustriesBankName"]);
                            }

                            if (!dr["MadhuramIndustriesBankIFSCCode"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesBankIFSCCode = Convert.ToString(dr["MadhuramIndustriesBankIFSCCode"]);
                            }

                            if (!dr["MadhuramIndustriesBankAccountNumber"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesBankAccountNumber = Convert.ToString(dr["MadhuramIndustriesBankAccountNumber"]);
                            }

                            if (!dr["MadhuramIndustriesBankBranchAddress"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesBankBranchAddress = Convert.ToString(dr["MadhuramIndustriesBankBranchAddress"]);
                            }

                            if (!dr["MadhuramIndustriesRemark"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.MadhuramIndustriesRemark = Convert.ToString(dr["MadhuramIndustriesRemark"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }

                            if (!dr["FlagDelete"].Equals(DBNull.Value))
                            {
                                entMadhuramIndustries.FlagDelete = Convert.ToBoolean(dr["FlagDelete"]);
                            }
						}
						return entMadhuramIndustries;

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
                        objCmd.CommandText = "PR_MadhuramIndustries_SelectForDropDown";
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

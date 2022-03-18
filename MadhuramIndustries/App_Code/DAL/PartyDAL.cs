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
/// Summary description for PartyDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class PartyDAL : DatabaseConfig
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
        public PartyDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(PartyENT entParty)
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
                        objCmd.CommandText = "PR_Party_Insert";
                        
                        objCmd.Parameters.AddWithValue("@PartyName", entParty.PartyName);
                        objCmd.Parameters.AddWithValue("@PartyAddress", entParty.PartyAddress);
                        objCmd.Parameters.AddWithValue("@PartyGSTNumber", entParty.PartyGSTNumber);
                        objCmd.Parameters.AddWithValue("@PartyPanCardNumber", entParty.PartyPanCardNumber);
                        objCmd.Parameters.AddWithValue("@PartyMobileNumber", entParty.PartyMobileNumber);
                        objCmd.Parameters.AddWithValue("@PartyBankName", entParty.PartyBankName);
                        objCmd.Parameters.AddWithValue("@PartyBankIFSCCode", entParty.PartyBankIFSCCode);
                        objCmd.Parameters.AddWithValue("@PartyBankAccountNumber", entParty.PartyBankAccountNumber);
                        objCmd.Parameters.AddWithValue("@PartyBankBranchAddress", entParty.PartyBankBranchAddress);
                        objCmd.Parameters.AddWithValue("@PartyRemark", entParty.PartyRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entParty.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entParty.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entParty.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entParty.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entParty.FlagDelete);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entParty.PartyID = Convert.ToInt32(objCmd.Parameters["@PartyID"].Value);

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

        public Boolean Update(PartyENT entParty)
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
                        objCmd.CommandText = "PR_Party_Update";

                        objCmd.Parameters.AddWithValue("@PartyID", entParty.PartyID);
                        objCmd.Parameters.AddWithValue("@PartyName", entParty.PartyName);
                        objCmd.Parameters.AddWithValue("@PartyAddress", entParty.PartyAddress);
                        objCmd.Parameters.AddWithValue("@PartyGSTNumber", entParty.PartyGSTNumber);
                        objCmd.Parameters.AddWithValue("@PartyPanCardNumber", entParty.PartyPanCardNumber);
                        objCmd.Parameters.AddWithValue("@PartyMobileNumber", entParty.PartyMobileNumber);
                        objCmd.Parameters.AddWithValue("@PartyBankName", entParty.PartyBankName);
                        objCmd.Parameters.AddWithValue("@PartyBankIFSCCode", entParty.PartyBankIFSCCode);
                        objCmd.Parameters.AddWithValue("@PartyBankAccountNumber", entParty.PartyBankAccountNumber);
                        objCmd.Parameters.AddWithValue("@PartyBankBranchAddress", entParty.PartyBankBranchAddress);
                        objCmd.Parameters.AddWithValue("@PartyRemark", entParty.PartyRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entParty.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entParty.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entParty.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entParty.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entParty.FlagDelete);

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

        public Boolean Delete(SqlInt32 PartyID)
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
                        objCmd.CommandText = "PR_Party_Delete";
                        
                        objCmd.Parameters.AddWithValue("@PartyID", PartyID);            
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
                        objCmd.CommandText = "PR_Party_Select";

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
        public PartyENT SelectPK(SqlInt32 PartyID)
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
                        PartyENT entParty = new PartyENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Party_SelectPK";
                        objCmd.Parameters.AddWithValue("@PartyID", PartyID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["PartyID"].Equals(DBNull.Value))
                            {
                                entParty.PartyID = Convert.ToInt32(dr["PartyID"]);
                            }

                            if (!dr["PartyName"].Equals(DBNull.Value))
                            {
                                entParty.PartyName = Convert.ToString(dr["PartyName"]);
                            }

                            if (!dr["PartyAddress"].Equals(DBNull.Value))
                            {
                                entParty.PartyAddress = Convert.ToString(dr["PartyAddress"]);
                            }

                            if (!dr["PartyGSTNumber"].Equals(DBNull.Value))
                            {
                                entParty.PartyGSTNumber = Convert.ToString(dr["PartyGSTNumber"]);
                            }

                            if (!dr["PartyPanCardNumber"].Equals(DBNull.Value))
                            {
                                entParty.PartyPanCardNumber = Convert.ToString(dr["PartyPanCardNumber"]);
                            }

                            if (!dr["PartyMobileNumber"].Equals(DBNull.Value))
                            {
                                entParty.PartyMobileNumber = Convert.ToString(dr["PartyMobileNumber"]);
                            }

                            if (!dr["PartyBankName"].Equals(DBNull.Value))
                            {
                                entParty.PartyBankName = Convert.ToString(dr["PartyBankName"]);
                            }

                            if (!dr["PartyBankIFSCCode"].Equals(DBNull.Value))
                            {
                                entParty.PartyBankIFSCCode = Convert.ToString(dr["PartyBankIFSCCode"]);
                            }

                            if (!dr["PartyBankAccountNumber"].Equals(DBNull.Value))
                            {
                                entParty.PartyBankAccountNumber = Convert.ToString(dr["PartyBankAccountNumber"]);
                            }

                            if (!dr["PartyBankBranchAddress"].Equals(DBNull.Value))
                            {
                                entParty.PartyBankBranchAddress = Convert.ToString(dr["PartyBankBranchAddress"]);
                            }

                            if (!dr["PartyRemark"].Equals(DBNull.Value))
                            {
                                entParty.PartyRemark = Convert.ToString(dr["PartyRemark"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entParty.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entParty.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entParty.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entParty.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }

                            if (!dr["FlagDelete"].Equals(DBNull.Value))
                            {
                                entParty.FlagDelete = Convert.ToBoolean(dr["FlagDelete"]);
                            }
						}
						return entParty;

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
                        objCmd.CommandText = "PR_Party_SelectForDropDown";
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

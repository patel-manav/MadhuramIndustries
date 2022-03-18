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
/// Summary description for ExpenseDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class ExpenseDAL : DatabaseConfig
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
        public ExpenseDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(ExpenseENT entExpense)
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
                        objCmd.CommandText = "PR_Expense_Insert";
                        
                        objCmd.Parameters.AddWithValue("@ExpenseDate", entExpense.ExpenseDate);
                        objCmd.Parameters.AddWithValue("@ItemID", entExpense.ItemID);
                        objCmd.Parameters.AddWithValue("@PartyID", entExpense.PartyID);
                        objCmd.Parameters.AddWithValue("@ItemQuantity", entExpense.ItemQuantity);
                        objCmd.Parameters.AddWithValue("@ExpenseRemark", entExpense.ExpenseRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entExpense.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entExpense.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entExpense.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entExpense.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entExpense.FlagDelete);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entExpense.ExpenseID = Convert.ToInt32(objCmd.Parameters["@ExpenseID"].Value);

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

        public Boolean Update(ExpenseENT entExpense)
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
                        objCmd.CommandText = "PR_Expense_Update";

                        objCmd.Parameters.AddWithValue("@ExpenseID", entExpense.ExpenseID);
                        objCmd.Parameters.AddWithValue("@ExpenseDate", entExpense.ExpenseDate);
                        objCmd.Parameters.AddWithValue("@ItemID", entExpense.ItemID);
                        objCmd.Parameters.AddWithValue("@PartyID", entExpense.PartyID);
                        objCmd.Parameters.AddWithValue("@ItemQuantity", entExpense.ItemQuantity);
                        objCmd.Parameters.AddWithValue("@ExpenseRemark", entExpense.ExpenseRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entExpense.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entExpense.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entExpense.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entExpense.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entExpense.FlagDelete);

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

        public Boolean Delete(SqlInt32 ExpenseID)
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
                        objCmd.CommandText = "PR_Expense_Delete";
                        
                        objCmd.Parameters.AddWithValue("@ExpenseID", ExpenseID);            
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
                        objCmd.CommandText = "PR_Expense_Select";

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
        public ExpenseENT SelectPK(SqlInt32 ExpenseID)
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
                        ExpenseENT entExpense = new ExpenseENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Expense_SelectPK";
                        objCmd.Parameters.AddWithValue("@ExpenseID", ExpenseID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["ExpenseID"].Equals(DBNull.Value))
                            {
                                entExpense.ExpenseID = Convert.ToInt32(dr["ExpenseID"]);
                            }

                            if (!dr["ExpenseDate"].Equals(DBNull.Value))
                            {
                                entExpense.ExpenseDate = Convert.ToDateTime(dr["ExpenseDate"]);
                            }

                            if (!dr["ItemID"].Equals(DBNull.Value))
                            {
                                entExpense.ItemID = Convert.ToInt32(dr["ItemID"]);
                            }

                            if (!dr["PartyID"].Equals(DBNull.Value))
                            {
                                entExpense.PartyID = Convert.ToInt32(dr["PartyID"]);
                            }

                            if (!dr["ItemQuantity"].Equals(DBNull.Value))
                            {
                                entExpense.ItemQuantity = Convert.ToInt32(dr["ItemQuantity"]);
                            }

                            if (!dr["ExpenseRemark"].Equals(DBNull.Value))
                            {
                                entExpense.ExpenseRemark = Convert.ToString(dr["ExpenseRemark"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entExpense.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entExpense.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entExpense.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entExpense.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }

                            if (!dr["FlagDelete"].Equals(DBNull.Value))
                            {
                                entExpense.FlagDelete = Convert.ToBoolean(dr["FlagDelete"]);
                            }
						}
						return entExpense;

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
                        objCmd.CommandText = "PR_Expense_SelectForDropDown";
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

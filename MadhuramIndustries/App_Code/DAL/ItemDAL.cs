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
/// Summary description for ItemDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class ItemDAL : DatabaseConfig
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
        public ItemDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(ItemENT entItem)
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
                        objCmd.CommandText = "PR_Item_Insert";
                        
                        objCmd.Parameters.AddWithValue("@ItemName", entItem.ItemName);
                        objCmd.Parameters.AddWithValue("@ItemCode", entItem.ItemCode);
                        objCmd.Parameters.AddWithValue("@ItemGST", entItem.ItemGST);
                        objCmd.Parameters.AddWithValue("@ItemUnit", entItem.ItemUnit);
                        objCmd.Parameters.AddWithValue("@ItemRemark", entItem.ItemRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entItem.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entItem.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entItem.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entItem.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entItem.FlagDelete);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entItem.ItemID = Convert.ToInt32(objCmd.Parameters["@ItemID"].Value);

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

        public Boolean Update(ItemENT entItem)
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
                        objCmd.CommandText = "PR_Item_Update";

                        objCmd.Parameters.AddWithValue("@ItemID", entItem.ItemID);
                        objCmd.Parameters.AddWithValue("@ItemName", entItem.ItemName);
                        objCmd.Parameters.AddWithValue("@ItemCode", entItem.ItemCode);
                        objCmd.Parameters.AddWithValue("@ItemGST", entItem.ItemGST);
                        objCmd.Parameters.AddWithValue("@ItemUnit", entItem.ItemUnit);
                        objCmd.Parameters.AddWithValue("@ItemRemark", entItem.ItemRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entItem.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entItem.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entItem.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entItem.CreateBy);
                        objCmd.Parameters.AddWithValue("@FlagDelete", entItem.FlagDelete);

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

        public Boolean Delete(SqlInt32 ItemID)
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
                        objCmd.CommandText = "PR_Item_Delete";
                        
                        objCmd.Parameters.AddWithValue("@ItemID", ItemID);            
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
                        objCmd.CommandText = "PR_Item_Select";

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
        public ItemENT SelectPK(SqlInt32 ItemID)
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
                        ItemENT entItem = new ItemENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Item_SelectPK";
                        objCmd.Parameters.AddWithValue("@ItemID", ItemID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["ItemID"].Equals(DBNull.Value))
                            {
                                entItem.ItemID = Convert.ToInt32(dr["ItemID"]);
                            }

                            if (!dr["ItemName"].Equals(DBNull.Value))
                            {
                                entItem.ItemName = Convert.ToString(dr["ItemName"]);
                            }

                            if (!dr["ItemCode"].Equals(DBNull.Value))
                            {
                                entItem.ItemCode = Convert.ToString(dr["ItemCode"]);
                            }

                            if (!dr["ItemGST"].Equals(DBNull.Value))
                            {
                                entItem.ItemGST = Convert.ToInt32(dr["ItemGST"]);
                            }

                            if (!dr["ItemUnit"].Equals(DBNull.Value))
                            {
                                entItem.ItemUnit = Convert.ToString(dr["ItemUnit"]);
                            }

                            if (!dr["ItemRemark"].Equals(DBNull.Value))
                            {
                                entItem.ItemRemark = Convert.ToString(dr["ItemRemark"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entItem.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entItem.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entItem.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entItem.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }

                            if (!dr["FlagDelete"].Equals(DBNull.Value))
                            {
                                entItem.FlagDelete = Convert.ToBoolean(dr["FlagDelete"]);
                            }
						}
						return entItem;

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
                        objCmd.CommandText = "PR_Item_SelectForDropDown";
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

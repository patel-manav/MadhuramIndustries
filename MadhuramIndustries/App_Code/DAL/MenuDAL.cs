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
/// Summary description for MenuDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class MenuDAL : DatabaseConfig
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
        public MenuDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(MenuENT entMenu)
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
                        objCmd.CommandText = "PR_Menu_Insert";
                        
                        objCmd.Parameters.AddWithValue("@MenuName", entMenu.MenuName);
                        objCmd.Parameters.AddWithValue("@MenuImagePath", entMenu.MenuImagePath);
                        objCmd.Parameters.AddWithValue("@MenuURL", entMenu.MenuURL);
                        objCmd.Parameters.AddWithValue("@MenuSequence", entMenu.MenuSequence);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entMenu.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entMenu.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entMenu.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entMenu.CreateBy);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entMenu.MenuID = Convert.ToInt32(objCmd.Parameters["@MenuID"].Value);

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

        public Boolean Update(MenuENT entMenu)
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
                        objCmd.CommandText = "PR_Menu_Update";

                        objCmd.Parameters.AddWithValue("@MenuID", entMenu.MenuID);
                        objCmd.Parameters.AddWithValue("@MenuName", entMenu.MenuName);
                        objCmd.Parameters.AddWithValue("@MenuImagePath", entMenu.MenuImagePath);
                        objCmd.Parameters.AddWithValue("@MenuURL", entMenu.MenuURL);
                        objCmd.Parameters.AddWithValue("@MenuSequence", entMenu.MenuSequence);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entMenu.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entMenu.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entMenu.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entMenu.CreateBy);

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

        public Boolean Delete(SqlInt32 MenuID)
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
                        objCmd.CommandText = "PR_Menu_Delete";
                        
                        objCmd.Parameters.AddWithValue("@MenuID", MenuID);            
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
                        objCmd.CommandText = "PR_Menu_Select";

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
        public MenuENT SelectPK(SqlInt32 MenuID)
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
                        MenuENT entMenu = new MenuENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Menu_SelectPK";
                        objCmd.Parameters.AddWithValue("@MenuID", MenuID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["MenuID"].Equals(DBNull.Value))
                            {
                                entMenu.MenuID = Convert.ToInt32(dr["MenuID"]);
                            }

                            if (!dr["MenuName"].Equals(DBNull.Value))
                            {
                                entMenu.MenuName = Convert.ToString(dr["MenuName"]);
                            }

                            if (!dr["MenuImagePath"].Equals(DBNull.Value))
                            {
                                entMenu.MenuImagePath = Convert.ToString(dr["MenuImagePath"]);
                            }

                            if (!dr["MenuURL"].Equals(DBNull.Value))
                            {
                                entMenu.MenuURL = Convert.ToString(dr["MenuURL"]);
                            }

                            if (!dr["MenuSequence"].Equals(DBNull.Value))
                            {
                                entMenu.MenuSequence = Convert.ToDecimal(dr["MenuSequence"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entMenu.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entMenu.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entMenu.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entMenu.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }
						}
						return entMenu;

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
                        objCmd.CommandText = "PR_Menu_SelectForDropDown";
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

        #region FillMenu
        public DataTable FillMenu(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Menu_Fill";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);


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
        #endregion FillMenu

        #endregion Select Operation
    }
}

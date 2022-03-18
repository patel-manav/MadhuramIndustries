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
/// Summary description for InwardDAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.DAL
{
    public class InwardDAL : DatabaseConfig
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
        public InwardDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
    
        #region Insert Operation

        public Boolean Insert(InwardENT entInward)
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
                        objCmd.CommandText = "PR_Inward_Insert";
                        
                        objCmd.Parameters.AddWithValue("@InwardNumber", entInward.InwardNumber);
                        objCmd.Parameters.AddWithValue("@InwardDate", entInward.InwardDate);
                        objCmd.Parameters.AddWithValue("@PartyID", entInward.PartyID);
                        objCmd.Parameters.AddWithValue("@ItemID", entInward.ItemID);
                        objCmd.Parameters.AddWithValue("@InwardQuantity", entInward.InwardQuantity);
                        objCmd.Parameters.AddWithValue("@InwardRemark", entInward.InwardRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entInward.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entInward.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entInward.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entInward.CreateBy);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        //entInward.InwardID = Convert.ToInt32(objCmd.Parameters["@InwardID"].Value);

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

        public Boolean Update(InwardENT entInward)
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
                        objCmd.CommandText = "PR_Inward_Update";

                        objCmd.Parameters.AddWithValue("@InwardID", entInward.InwardID);
                        objCmd.Parameters.AddWithValue("@InwardNumber", entInward.InwardNumber);
                        objCmd.Parameters.AddWithValue("@InwardDate", entInward.InwardDate);
                        objCmd.Parameters.AddWithValue("@PartyID", entInward.PartyID);
                        objCmd.Parameters.AddWithValue("@ItemID", entInward.ItemID);
                        objCmd.Parameters.AddWithValue("@InwardQuantity", entInward.InwardQuantity);
                        objCmd.Parameters.AddWithValue("@InwardRemark", entInward.InwardRemark);
                        objCmd.Parameters.AddWithValue("@ModifyDate", entInward.ModifyDate);
                        objCmd.Parameters.AddWithValue("@ModifyBy", entInward.ModifyBy);
                        objCmd.Parameters.AddWithValue("@CreateDate", entInward.CreateDate);
                        objCmd.Parameters.AddWithValue("@CreateBy", entInward.CreateBy);

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

        public Boolean Delete(SqlInt32 InwardID)
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
                        objCmd.CommandText = "PR_Inward_Delete";
                        
                        objCmd.Parameters.AddWithValue("@InwardID", InwardID);            
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
                        objCmd.CommandText = "PR_Inward_Select";

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
        public InwardENT SelectPK(SqlInt32 InwardID)
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
                        InwardENT entInward = new InwardENT();
                        #endregion Variables

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Inward_SelectPK";
                        objCmd.Parameters.AddWithValue("@InwardID", InwardID);
                        #endregion Prepare Command

                        #region Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
							dt.Load(objSDR);
                        }
						foreach (DataRow dr in dt.Rows)
						{
							if (!dr["InwardID"].Equals(DBNull.Value))
                            {
                                entInward.InwardID = Convert.ToInt32(dr["InwardID"]);
                            }

                            if (!dr["InwardNumber"].Equals(DBNull.Value))
                            {
                                entInward.InwardNumber = Convert.ToString(dr["InwardNumber"]);
                            }

                            if (!dr["InwardDate"].Equals(DBNull.Value))
                            {
                                entInward.InwardDate = Convert.ToDateTime(dr["InwardDate"]);
                            }

                            if (!dr["PartyID"].Equals(DBNull.Value))
                            {
                                entInward.PartyID = Convert.ToInt32(dr["PartyID"]);
                            }

                            if (!dr["ItemID"].Equals(DBNull.Value))
                            {
                                entInward.ItemID = Convert.ToInt32(dr["ItemID"]);
                            }

                            if (!dr["InwardQuantity"].Equals(DBNull.Value))
                            {
                                entInward.InwardQuantity = Convert.ToInt32(dr["InwardQuantity"]);
                            }

                            if (!dr["InwardRemark"].Equals(DBNull.Value))
                            {
                                entInward.InwardRemark = Convert.ToString(dr["InwardRemark"]);
                            }

                            if (!dr["ModifyDate"].Equals(DBNull.Value))
                            {
                                entInward.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                            }

                            if (!dr["ModifyBy"].Equals(DBNull.Value))
                            {
                                entInward.ModifyBy = Convert.ToInt32(dr["ModifyBy"]);
                            }

                            if (!dr["CreateDate"].Equals(DBNull.Value))
                            {
                                entInward.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                            }

                            if (!dr["CreateBy"].Equals(DBNull.Value))
                            {
                                entInward.CreateBy = Convert.ToInt32(dr["CreateBy"]);
                            }
						}
						return entInward;

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
                        objCmd.CommandText = "PR_Inward_SelectForDropDown";
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

using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeDesignationBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class EmployeeDesignationBAL
    {
        #region Local Variable
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

        #endregion Local Variable

        #region Constructor
        public EmployeeDesignationBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(EmployeeDesignationENT entEmployeeDesignation)
        {
            EmployeeDesignationDAL dalEmployeeDesignation = new EmployeeDesignationDAL();
            if (dalEmployeeDesignation.Insert(entEmployeeDesignation))
            {
                return true;
            }
            else
            {
                Message = dalEmployeeDesignation.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 EmployeeDesignationID)
        {
            EmployeeDesignationDAL dalEmployeeDesignation = new EmployeeDesignationDAL();

            if (dalEmployeeDesignation.Delete(EmployeeDesignationID))
            {
                return true;
            }
            else
            {
                Message = dalEmployeeDesignation.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(EmployeeDesignationENT entEmployeeDesignation)
        {
            EmployeeDesignationDAL dalEmployeeDesignation = new EmployeeDesignationDAL();
            if (dalEmployeeDesignation.Update(entEmployeeDesignation))
            {
                return true;
            }
            else
            {
                Message = dalEmployeeDesignation.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            EmployeeDesignationDAL dalEmployeeDesignation = new EmployeeDesignationDAL();
            return dalEmployeeDesignation.Select();
        }
        #endregion Select

        #region SelectPK
        public EmployeeDesignationENT SelectPK(SqlInt32 EmployeeDesignationID)
        {
            EmployeeDesignationDAL dalEmployeeDesignation = new EmployeeDesignationDAL();
            return dalEmployeeDesignation.SelectPK(EmployeeDesignationID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            EmployeeDesignationDAL dalEmployeeDesignation = new EmployeeDesignationDAL();
            return dalEmployeeDesignation.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #endregion Select Operation
    }
}

using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class EmployeeBAL
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
        public EmployeeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(EmployeeENT entEmployee)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            if (dalEmployee.Insert(entEmployee))
            {
                return true;
            }
            else
            {
                Message = dalEmployee.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 EmployeeID)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();

            if (dalEmployee.Delete(EmployeeID))
            {
                return true;
            }
            else
            {
                Message = dalEmployee.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(EmployeeENT entEmployee)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            if (dalEmployee.Update(entEmployee))
            {
                return true;
            }
            else
            {
                Message = dalEmployee.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.Select();
        }
        #endregion Select

        #region SelectPK
        public EmployeeENT SelectPK(SqlInt32 EmployeeID)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectPK(EmployeeID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #region SelectAttendance
        public DataTable SelectAttendance(DateTime AttendanceDate)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectAttendance(AttendanceDate);
        }
        #endregion Select

        #endregion Select Operation
    }
}

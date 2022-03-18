using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AttendanceBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class AttendanceBAL
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
        public AttendanceBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(AttendanceENT entAttendance)
        {
            AttendanceDAL dalAttendance = new AttendanceDAL();
            if (dalAttendance.Insert(entAttendance))
            {
                return true;
            }
            else
            {
                Message = dalAttendance.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 AttendanceID)
        {
            AttendanceDAL dalAttendance = new AttendanceDAL();

            if (dalAttendance.Delete(AttendanceID))
            {
                return true;
            }
            else
            {
                Message = dalAttendance.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(AttendanceENT entAttendance)
        {
            AttendanceDAL dalAttendance = new AttendanceDAL();
            if (dalAttendance.Update(entAttendance))
            {
                return true;
            }
            else
            {
                Message = dalAttendance.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            AttendanceDAL dalAttendance = new AttendanceDAL();
            return dalAttendance.Select();
        }
        #endregion Select

        #region SelectPK
        public AttendanceENT SelectPK(SqlInt32 AttendanceID)
        {
            AttendanceDAL dalAttendance = new AttendanceDAL();
            return dalAttendance.SelectPK(AttendanceID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            AttendanceDAL dalAttendance = new AttendanceDAL();
            return dalAttendance.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #region SalaryReport
        public DataTable SelectForSalaryReport(SqlDateTime FromDate,SqlDateTime ToDate,SqlInt32 EmployeeID)
        {
            AttendanceDAL dalAttendance = new AttendanceDAL();
            return dalAttendance.SelectForSalaryReport(FromDate,ToDate,EmployeeID);
        }
        #endregion SalaryReport

        #endregion Select Operation
    }
}

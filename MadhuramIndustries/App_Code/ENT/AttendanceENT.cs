using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AttendanceENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class AttendanceENT
    {
        #region Constructor
        public AttendanceENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        #region AttendanceID
        protected SqlInt32 _AttendanceID;

        public SqlInt32 AttendanceID
        {
            get
            {
                return _AttendanceID;
            }
            set
            {
                _AttendanceID = value;
            }
        }
        #endregion AttendanceID

        #region EmployeeID
        protected SqlInt32 _EmployeeID;

        public SqlInt32 EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }
        #endregion EmployeeID

        #region InTime
        protected SqlDateTime _InTime;

        public SqlDateTime InTime
        {
            get
            {
                return _InTime;
            }
            set
            {
                _InTime = value;
            }
        }
        #endregion FlagIn

        #region OutTime
        protected SqlDateTime _OutTime;

        public SqlDateTime OutTime
        {
            get
            {
                return _OutTime;
            }
            set
            {
                _OutTime = value;
            }
        }
        #endregion FlagOut

        #region AttendanceDate
        protected SqlDateTime _AttendanceDate;

        public SqlDateTime AttendanceDate
        {
            get
            {
                return _AttendanceDate;
            }
            set
            {
                _AttendanceDate = value;
            }
        }
        #endregion AttendanceDate

        #region FlagReset
        protected SqlInt32 _FlagReset;

        public SqlInt32 FlagReset
        {
            get
            {
                return _FlagReset;
            }
            set
            {
                _FlagReset = value;
            }
        }
        #endregion FlagReset

        #region ModifyDate
        protected SqlDateTime _ModifyDate;

        public SqlDateTime ModifyDate
        {
            get
            {
                return _ModifyDate;
            }
            set
            {
                _ModifyDate = value;
            }
        }
        #endregion ModifyDate

        #region ModifyBy
        protected SqlInt32 _ModifyBy;

        public SqlInt32 ModifyBy
        {
            get
            {
                return _ModifyBy;
            }
            set
            {
                _ModifyBy = value;
            }
        }
        #endregion ModifyBy

        #region CreateDate
        protected SqlDateTime _CreateDate;

        public SqlDateTime CreateDate
        {
            get
            {
                return _CreateDate;
            }
            set
            {
                _CreateDate = value;
            }
        }
        #endregion CreateDate

        #region CreateBy
        protected SqlInt32 _CreateBy;

        public SqlInt32 CreateBy
        {
            get
            {
                return _CreateBy;
            }
            set
            {
                _CreateBy = value;
            }
        }
        #endregion CreateBy

        #region OverTimeHours
        protected SqlInt32 _OverTimeHours;

        public SqlInt32 OverTimeHours
        {
            get
            {
                return _OverTimeHours;
            }
            set
            {
                _OverTimeHours = value;
            }
        }
        #endregion OverTimeHours

        #region TotalWorkedHours
        protected SqlDecimal _TotalWorkedHours;

        public SqlDecimal TotalWorkedHours
        {
            get
            {
                return _TotalWorkedHours;
            }
            set
            {
                _TotalWorkedHours = value;
            }
        }
        #endregion TotalWorkedHours
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeePenaltyENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class EmployeePenaltyENT
    {
        #region Constructor
        public EmployeePenaltyENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        #region EmployeePenaltyID
        protected SqlInt32 _EmployeePenaltyID;

        public SqlInt32 EmployeePenaltyID
        {
            get
            {
                return _EmployeePenaltyID;
            }
            set
            {
                _EmployeePenaltyID = value;
            }
        }
        #endregion EmployeePenaltyID

        #region EmployeePenaltyDate
        protected SqlDateTime _EmployeePenaltyDate;

        public SqlDateTime EmployeePenaltyDate
        {
            get
            {
                return _EmployeePenaltyDate;
            }
            set
            {
                _EmployeePenaltyDate = value;
            }
        }
        #endregion EmployeePenaltyDate

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

        #region EmployeePenaltyAmount
        protected SqlInt32 _EmployeePenaltyAmount;

        public SqlInt32 EmployeePenaltyAmount
        {
            get
            {
                return _EmployeePenaltyAmount;
            }
            set
            {
                _EmployeePenaltyAmount = value;
            }
        }
        #endregion EmployeePenaltyAmount

        #region EmployeePenaltyRemark
        protected SqlString _EmployeePenaltyRemark;

        public SqlString EmployeePenaltyRemark
        {
            get
            {
                return _EmployeePenaltyRemark;
            }
            set
            {
                _EmployeePenaltyRemark = value;
            }
        }
        #endregion EmployeePenaltyRemark

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

    }
}

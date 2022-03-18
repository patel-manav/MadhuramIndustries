using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeDesignationENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class EmployeeDesignationENT
    {
        #region Constructor
        public EmployeeDesignationENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        #region EmployeeDesignationID
        protected SqlInt32 _EmployeeDesignationID;

        public SqlInt32 EmployeeDesignationID
        {
            get
            {
                return _EmployeeDesignationID;
            }
            set
            {
                _EmployeeDesignationID = value;
            }
        }
        #endregion EmployeeDesignationID

        #region EmployeeDesignationName
        protected SqlString _EmployeeDesignationName;

        public SqlString EmployeeDesignationName
        {
            get
            {
                return _EmployeeDesignationName;
            }
            set
            {
                _EmployeeDesignationName = value;
            }
        }
        #endregion EmployeeDesignationName

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

        #region FlagDelete
        protected SqlBoolean _FlagDelete;

        public SqlBoolean FlagDelete
        {
            get
            {
                return _FlagDelete;
            }
            set
            {
                _FlagDelete = value;
            }
        }
        #endregion FlagDelete

    }
}

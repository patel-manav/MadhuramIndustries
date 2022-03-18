using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class EmployeeENT
    {
        #region Constructor
        public EmployeeENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
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

        #region EmployeeName
        protected SqlString _EmployeeName;

        public SqlString EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        #endregion EmployeeName

        #region EmployeeCardNumber
        protected SqlString _EmployeeCardNumber;

        public SqlString EmployeeCardNumber
        {
            get
            {
                return _EmployeeCardNumber;
            }
            set
            {
                _EmployeeCardNumber = value;
            }
        }
        #endregion EmployeeCardNumber

        #region EmployeeMobileNumber
        protected SqlString _EmployeeMobileNumber;

        public SqlString EmployeeMobileNumber
        {
            get
            {
                return _EmployeeMobileNumber;
            }
            set
            {
                _EmployeeMobileNumber = value;
            }
        }
        #endregion EmployeeMobileNumber

        #region EmployeeCity
        protected SqlString _EmployeeCity;

        public SqlString EmployeeCity
        {
            get
            {
                return _EmployeeCity;
            }
            set
            {
                _EmployeeCity = value;
            }
        }
        #endregion EmployeeCity

        #region EmployeeDOB
        protected SqlDateTime _EmployeeDOB;

        public SqlDateTime EmployeeDOB
        {
            get
            {
                return _EmployeeDOB;
            }
            set
            {
                _EmployeeDOB = value;
            }
        }
        #endregion EmployeeDOB

        #region EmployeeAddress
        protected SqlString _EmployeeAddress;

        public SqlString EmployeeAddress
        {
            get
            {
                return _EmployeeAddress;
            }
            set
            {
                _EmployeeAddress = value;
            }
        }
        #endregion EmployeeAddress

        #region EmployeeGender
        protected SqlString _EmployeeGender;

        public SqlString EmployeeGender
        {
            get
            {
                return _EmployeeGender;
            }
            set
            {
                _EmployeeGender = value;
            }
        }
        #endregion EmployeeGender

        #region EmployeeSalary
        protected SqlInt32 _EmployeeSalary;

        public SqlInt32 EmployeeSalary
        {
            get
            {
                return _EmployeeSalary;
            }
            set
            {
                _EmployeeSalary = value;
            }
        }
        #endregion EmployeeSalary

        #region EmployeeWorkTime
        protected SqlInt32 _EmployeeWorkTime;

        public SqlInt32 EmployeeWorkTime
        {
            get
            {
                return _EmployeeWorkTime;
            }
            set
            {
                _EmployeeWorkTime = value;
            }
        }
        #endregion EmployeeWorkTime

        #region EmployeeOverTimeSalary
        protected SqlInt32 _EmployeeOverTimeSalary;

        public SqlInt32 EmployeeOverTimeSalary
        {
            get
            {
                return _EmployeeOverTimeSalary;
            }
            set
            {
                _EmployeeOverTimeSalary = value;
            }
        }
        #endregion EmployeeOverTimeSalary

        #region DesignationID
        protected SqlInt32 _DesignationID;

        public SqlInt32 DesignationID
        {
            get
            {
                return _DesignationID;
            }
            set
            {
                _DesignationID = value;
            }
        }
        #endregion DesignationID

        #region EmployeeIDProof
        protected SqlBinary _EmployeeIDProof;

        public SqlBinary EmployeeIDProof
        {
            get
            {
                return _EmployeeIDProof;
            }
            set
            {
                _EmployeeIDProof = value;
            }
        }
        #endregion EmployeeIDProof

        #region EmployeeIDProofExtension
        protected SqlString _EmployeeIDProofExtension;

        public SqlString EmployeeIDProofExtension
        {
            get
            {
                return _EmployeeIDProofExtension;
            }
            set
            {
                _EmployeeIDProofExtension = value;
            }
        }
        #endregion EmployeeIDProofExtension

        #region EmployeeIDProofType
        protected SqlString _EmployeeIDProofType;

        public SqlString EmployeeIDProofType
        {
            get
            {
                return _EmployeeIDProofType;
            }
            set
            {
                _EmployeeIDProofType = value;
            }
        }
        #endregion EmployeeIDProofType

        #region EmployeeRemark
        protected SqlString _EmployeeRemark;

        public SqlString EmployeeRemark
        {
            get
            {
                return _EmployeeRemark;
            }
            set
            {
                _EmployeeRemark = value;
            }
        }
        #endregion EmployeeRemark

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

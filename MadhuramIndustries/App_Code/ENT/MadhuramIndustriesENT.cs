using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MadhuramIndustriesENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class MadhuramIndustriesENT
    {
        #region Constructor
        public MadhuramIndustriesENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        #region MadhuramIndustriesID
        protected SqlInt32 _MadhuramIndustriesID;

        public SqlInt32 MadhuramIndustriesID
        {
            get
            {
                return _MadhuramIndustriesID;
            }
            set
            {
                _MadhuramIndustriesID = value;
            }
        }
        #endregion MadhuramIndustriesID

        #region MadhuramIndustriesName
        protected SqlString _MadhuramIndustriesName;

        public SqlString MadhuramIndustriesName
        {
            get
            {
                return _MadhuramIndustriesName;
            }
            set
            {
                _MadhuramIndustriesName = value;
            }
        }
        #endregion MadhuramIndustriesName

        #region MadhuramIndustriesAddress
        protected SqlString _MadhuramIndustriesAddress;

        public SqlString MadhuramIndustriesAddress
        {
            get
            {
                return _MadhuramIndustriesAddress;
            }
            set
            {
                _MadhuramIndustriesAddress = value;
            }
        }
        #endregion MadhuramIndustriesAddress

        #region MadhuramIndustriesGSTNumber
        protected SqlString _MadhuramIndustriesGSTNumber;

        public SqlString MadhuramIndustriesGSTNumber
        {
            get
            {
                return _MadhuramIndustriesGSTNumber;
            }
            set
            {
                _MadhuramIndustriesGSTNumber = value;
            }
        }
        #endregion MadhuramIndustriesGSTNumber

        #region MadhuramIndustriesPanCardNumber
        protected SqlString _MadhuramIndustriesPanCardNumber;

        public SqlString MadhuramIndustriesPanCardNumber
        {
            get
            {
                return _MadhuramIndustriesPanCardNumber;
            }
            set
            {
                _MadhuramIndustriesPanCardNumber = value;
            }
        }
        #endregion MadhuramIndustriesPanCardNumber

        #region MadhuramIndustriesMobileNumber
        protected SqlString _MadhuramIndustriesMobileNumber;

        public SqlString MadhuramIndustriesMobileNumber
        {
            get
            {
                return _MadhuramIndustriesMobileNumber;
            }
            set
            {
                _MadhuramIndustriesMobileNumber = value;
            }
        }
        #endregion MadhuramIndustriesMobileNumber

        #region MadhuramIndustriesBankName
        protected SqlString _MadhuramIndustriesBankName;

        public SqlString MadhuramIndustriesBankName
        {
            get
            {
                return _MadhuramIndustriesBankName;
            }
            set
            {
                _MadhuramIndustriesBankName = value;
            }
        }
        #endregion MadhuramIndustriesBankName

        #region MadhuramIndustriesBankIFSCCode
        protected SqlString _MadhuramIndustriesBankIFSCCode;

        public SqlString MadhuramIndustriesBankIFSCCode
        {
            get
            {
                return _MadhuramIndustriesBankIFSCCode;
            }
            set
            {
                _MadhuramIndustriesBankIFSCCode = value;
            }
        }
        #endregion MadhuramIndustriesBankIFSCCode

        #region MadhuramIndustriesBankAccountNumber
        protected SqlString _MadhuramIndustriesBankAccountNumber;

        public SqlString MadhuramIndustriesBankAccountNumber
        {
            get
            {
                return _MadhuramIndustriesBankAccountNumber;
            }
            set
            {
                _MadhuramIndustriesBankAccountNumber = value;
            }
        }
        #endregion MadhuramIndustriesBankAccountNumber

        #region MadhuramIndustriesBankBranchAddress
        protected SqlString _MadhuramIndustriesBankBranchAddress;

        public SqlString MadhuramIndustriesBankBranchAddress
        {
            get
            {
                return _MadhuramIndustriesBankBranchAddress;
            }
            set
            {
                _MadhuramIndustriesBankBranchAddress = value;
            }
        }
        #endregion MadhuramIndustriesBankBranchAddress

        #region MadhuramIndustriesRemark
        protected SqlString _MadhuramIndustriesRemark;

        public SqlString MadhuramIndustriesRemark
        {
            get
            {
                return _MadhuramIndustriesRemark;
            }
            set
            {
                _MadhuramIndustriesRemark = value;
            }
        }
        #endregion MadhuramIndustriesRemark

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

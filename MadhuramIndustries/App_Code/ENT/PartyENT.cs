using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PartyENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class PartyENT
    {
        #region Constructor
        public PartyENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        
        #region PartyID
        protected SqlInt32 _PartyID;

        public SqlInt32 PartyID
        {
            get
            {
                return _PartyID;
            }
            set
            {
                _PartyID = value;
            }
        }
        #endregion PartyID

        #region PartyName
        protected SqlString _PartyName;

        public SqlString PartyName
        {
            get
            {
                return _PartyName;
            }
            set
            {
                _PartyName = value;
            }
        }
        #endregion PartyName

        #region PartyAddress
        protected SqlString _PartyAddress;

        public SqlString PartyAddress
        {
            get
            {
                return _PartyAddress;
            }
            set
            {
                _PartyAddress = value;
            }
        }
        #endregion PartyAddress

        #region PartyGSTNumber
        protected SqlString _PartyGSTNumber;

        public SqlString PartyGSTNumber
        {
            get
            {
                return _PartyGSTNumber;
            }
            set
            {
                _PartyGSTNumber = value;
            }
        }
        #endregion PartyGSTNumber

        #region PartyPanCardNumber
        protected SqlString _PartyPanCardNumber;

        public SqlString PartyPanCardNumber
        {
            get
            {
                return _PartyPanCardNumber;
            }
            set
            {
                _PartyPanCardNumber = value;
            }
        }
        #endregion PartyPanCardNumber

        #region PartyMobileNumber
        protected SqlString _PartyMobileNumber;

        public SqlString PartyMobileNumber
        {
            get
            {
                return _PartyMobileNumber;
            }
            set
            {
                _PartyMobileNumber = value;
            }
        }
        #endregion PartyMobileNumber

        #region PartyBankName
        protected SqlString _PartyBankName;

        public SqlString PartyBankName
        {
            get
            {
                return _PartyBankName;
            }
            set
            {
                _PartyBankName = value;
            }
        }
        #endregion PartyBankName

        #region PartyBankIFSCCode
        protected SqlString _PartyBankIFSCCode;

        public SqlString PartyBankIFSCCode
        {
            get
            {
                return _PartyBankIFSCCode;
            }
            set
            {
                _PartyBankIFSCCode = value;
            }
        }
        #endregion PartyBankIFSCCode

        #region PartyBankAccountNumber
        protected SqlString _PartyBankAccountNumber;

        public SqlString PartyBankAccountNumber
        {
            get
            {
                return _PartyBankAccountNumber;
            }
            set
            {
                _PartyBankAccountNumber = value;
            }
        }
        #endregion PartyBankAccountNumber

        #region PartyBankBranchAddress
        protected SqlString _PartyBankBranchAddress;

        public SqlString PartyBankBranchAddress
        {
            get
            {
                return _PartyBankBranchAddress;
            }
            set
            {
                _PartyBankBranchAddress = value;
            }
        }
        #endregion PartyBankBranchAddress

        #region PartyRemark
        protected SqlString _PartyRemark;

        public SqlString PartyRemark
        {
            get
            {
                return _PartyRemark;
            }
            set
            {
                _PartyRemark = value;
            }
        }
        #endregion PartyRemark

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

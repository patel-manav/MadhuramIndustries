using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class ItemENT
    {
        #region Constructor
        public ItemENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        #region ItemID
        protected SqlInt32 _ItemID;

        public SqlInt32 ItemID
        {
            get
            {
                return _ItemID;
            }
            set
            {
                _ItemID = value;
            }
        }
        #endregion ItemID

        #region ItemName
        protected SqlString _ItemName;

        public SqlString ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
            }
        }
        #endregion ItemName

        #region ItemCode
        protected SqlString _ItemCode;

        public SqlString ItemCode
        {
            get
            {
                return _ItemCode;
            }
            set
            {
                _ItemCode = value;
            }
        }
        #endregion ItemCode

        #region ItemGST
        protected SqlInt32 _ItemGST;

        public SqlInt32 ItemGST
        {
            get
            {
                return _ItemGST;
            }
            set
            {
                _ItemGST = value;
            }
        }
        #endregion ItemGST

        #region ItemUnit
        protected SqlString _ItemUnit;

        public SqlString ItemUnit
        {
            get
            {
                return _ItemUnit;
            }
            set
            {
                _ItemUnit = value;
            }
        }
        #endregion ItemUnit

        #region ItemRemark
        protected SqlString _ItemRemark;

        public SqlString ItemRemark
        {
            get
            {
                return _ItemRemark;
            }
            set
            {
                _ItemRemark = value;
            }
        }
        #endregion ItemRemark

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

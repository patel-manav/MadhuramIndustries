using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExpenseENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class ExpenseENT
    {
        #region Constructor
        public ExpenseENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        
        #region ExpenseID
        protected SqlInt32 _ExpenseID;

        public SqlInt32 ExpenseID
        {
            get
            {
                return _ExpenseID;
            }
            set
            {
                _ExpenseID = value;
            }
        }
        #endregion ExpenseID

        #region ExpenseDate
        protected SqlDateTime _ExpenseDate;

        public SqlDateTime ExpenseDate
        {
            get
            {
                return _ExpenseDate;
            }
            set
            {
                _ExpenseDate = value;
            }
        }
        #endregion ExpenseDate

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

        #region ItemQuantity
        protected SqlInt32 _ItemQuantity;

        public SqlInt32 ItemQuantity
        {
            get
            {
                return _ItemQuantity;
            }
            set
            {
                _ItemQuantity = value;
            }
        }
        #endregion ItemQuantity

        #region ExpenseRemark
        protected SqlString _ExpenseRemark;

        public SqlString ExpenseRemark
        {
            get
            {
                return _ExpenseRemark;
            }
            set
            {
                _ExpenseRemark = value;
            }
        }
        #endregion ExpenseRemark

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

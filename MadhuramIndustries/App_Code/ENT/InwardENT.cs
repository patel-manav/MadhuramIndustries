using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InwardENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class InwardENT
    {
        #region Constructor
        public InwardENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        #region InwardID
        protected SqlInt32 _InwardID;

        public SqlInt32 InwardID
        {
            get
            {
                return _InwardID;
            }
            set
            {
                _InwardID = value;
            }
        }
        #endregion InwardID

        #region InwardNumber
        protected SqlString _InwardNumber;

        public SqlString InwardNumber
        {
            get
            {
                return _InwardNumber;
            }
            set
            {
                _InwardNumber = value;
            }
        }
        #endregion InwardNumber

        #region InwardDate
        protected SqlDateTime _InwardDate;

        public SqlDateTime InwardDate
        {
            get
            {
                return _InwardDate;
            }
            set
            {
                _InwardDate = value;
            }
        }
        #endregion InwardDate

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

        #region InwardQuantity
        protected SqlInt32 _InwardQuantity;

        public SqlInt32 InwardQuantity
        {
            get
            {
                return _InwardQuantity;
            }
            set
            {
                _InwardQuantity = value;
            }
        }
        #endregion InwardQuantity

        #region InwardRemark
        protected SqlString _InwardRemark;

        public SqlString InwardRemark
        {
            get
            {
                return _InwardRemark;
            }
            set
            {
                _InwardRemark = value;
            }
        }
        #endregion InwardRemark

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

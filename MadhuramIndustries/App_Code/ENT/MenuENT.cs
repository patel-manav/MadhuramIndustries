using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MenuENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class MenuENT
    {
        #region Constructor
        public MenuENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        
        #region MenuID
        protected SqlInt32 _MenuID;

        public SqlInt32 MenuID
        {
            get
            {
                return _MenuID;
            }
            set
            {
                _MenuID = value;
            }
        }
        #endregion MenuID

        #region MenuName
        protected SqlString _MenuName;

        public SqlString MenuName
        {
            get
            {
                return _MenuName;
            }
            set
            {
                _MenuName = value;
            }
        }
        #endregion MenuName

        #region MenuImagePath
        protected SqlString _MenuImagePath;

        public SqlString MenuImagePath
        {
            get
            {
                return _MenuImagePath;
            }
            set
            {
                _MenuImagePath = value;
            }
        }
        #endregion MenuImagePath

        #region MenuURL
        protected SqlString _MenuURL;

        public SqlString MenuURL
        {
            get
            {
                return _MenuURL;
            }
            set
            {
                _MenuURL = value;
            }
        }
        #endregion MenuURL

        #region MenuSequence
        protected SqlDecimal _MenuSequence;

        public SqlDecimal MenuSequence
        {
            get
            {
                return _MenuSequence;
            }
            set
            {
                _MenuSequence = value;
            }
        }
        #endregion MenuSequence

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

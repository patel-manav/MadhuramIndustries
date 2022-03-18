using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserWiseMenuENT
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.ENT
{
    public class UserWiseMenuENT
    {
        #region Constructor
        public UserWiseMenuENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor
        
        
        #region UserWiseMenuID
        protected SqlInt32 _UserWiseMenuID;

        public SqlInt32 UserWiseMenuID
        {
            get
            {
                return _UserWiseMenuID;
            }
            set
            {
                _UserWiseMenuID = value;
            }
        }
        #endregion UserWiseMenuID

        #region UserID
        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        #endregion UserID

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

    }
}

using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserWiseMenuBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class UserWiseMenuBAL
    {
        #region Local Variable
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local Variable

        #region Constructor
        public UserWiseMenuBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(SqlInt32 UserID, SqlInt32 MenuID)
        {
            UserWiseMenuDAL dalUserWiseMenu = new UserWiseMenuDAL();
            if (dalUserWiseMenu.Insert(UserID,MenuID))
            {
                return true;
            }
            else
            {
                Message = dalUserWiseMenu.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 UserID)
        {
            UserWiseMenuDAL dalUserWiseMenu = new UserWiseMenuDAL();

            if (dalUserWiseMenu.Delete(UserID))
            {
                return true;
            }
            else
            {
                Message = dalUserWiseMenu.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(UserWiseMenuENT entUserWiseMenu)
        {
            UserWiseMenuDAL dalUserWiseMenu = new UserWiseMenuDAL();
            if (dalUserWiseMenu.Update(entUserWiseMenu))
            {
                return true;
            }
            else
            {
                Message = dalUserWiseMenu.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select(SqlInt32 UserID)
        {
            UserWiseMenuDAL dalUserWiseMenu = new UserWiseMenuDAL();
            return dalUserWiseMenu.Select(UserID);
        }
        #endregion Select

        #region SelectPK
        public UserWiseMenuENT SelectPK(SqlInt32 UserWiseMenuID)
        {
            UserWiseMenuDAL dalUserWiseMenu = new UserWiseMenuDAL();
            return dalUserWiseMenu.SelectPK(UserWiseMenuID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            UserWiseMenuDAL dalUserWiseMenu = new UserWiseMenuDAL();
            return dalUserWiseMenu.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #endregion Select Operation
    }
}

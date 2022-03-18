using System;
using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class UserBAL
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
        public UserBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.Insert(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Delete(UserID))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.Update(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.Select();
        }
        #endregion Select

        #region SelectPK
        public UserENT SelectPK(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectPK(UserID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #endregion Select Operation

        #region UserSignIn
        public DataTable UserSignIn(String UserName, String UserPassword)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.UserSignIn(UserName, UserPassword);
        }
        #endregion UserSignIn
    }
}

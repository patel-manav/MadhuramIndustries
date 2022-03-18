using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MenuBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class MenuBAL
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
        public MenuBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(MenuENT entMenu)
        {
            MenuDAL dalMenu = new MenuDAL();
            if (dalMenu.Insert(entMenu))
            {
                return true;
            }
            else
            {
                Message = dalMenu.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 MenuID)
        {
            MenuDAL dalMenu = new MenuDAL();

            if (dalMenu.Delete(MenuID))
            {
                return true;
            }
            else
            {
                Message = dalMenu.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(MenuENT entMenu)
        {
            MenuDAL dalMenu = new MenuDAL();
            if (dalMenu.Update(entMenu))
            {
                return true;
            }
            else
            {
                Message = dalMenu.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            MenuDAL dalMenu = new MenuDAL();
            return dalMenu.Select();
        }
        #endregion Select

        #region SelectPK
        public MenuENT SelectPK(SqlInt32 MenuID)
        {
            MenuDAL dalMenu = new MenuDAL();
            return dalMenu.SelectPK(MenuID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            MenuDAL dalMenu = new MenuDAL();
            return dalMenu.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #region FillMenu
        public DataTable FillMenu(SqlInt32 UserID)
        {
            MenuDAL dalMenu = new MenuDAL();
            return dalMenu.FillMenu(UserID);
        }

        #endregion SelectPK

        #endregion Select Operation
    }
}

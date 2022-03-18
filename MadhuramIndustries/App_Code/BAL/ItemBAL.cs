using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class ItemBAL
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
        public ItemBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ItemENT entItem)
        {
            ItemDAL dalItem = new ItemDAL();
            if (dalItem.Insert(entItem))
            {
                return true;
            }
            else
            {
                Message = dalItem.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 ItemID)
        {
            ItemDAL dalItem = new ItemDAL();

            if (dalItem.Delete(ItemID))
            {
                return true;
            }
            else
            {
                Message = dalItem.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(ItemENT entItem)
        {
            ItemDAL dalItem = new ItemDAL();
            if (dalItem.Update(entItem))
            {
                return true;
            }
            else
            {
                Message = dalItem.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            ItemDAL dalItem = new ItemDAL();
            return dalItem.Select();
        }
        #endregion Select

        #region SelectPK
        public ItemENT SelectPK(SqlInt32 ItemID)
        {
            ItemDAL dalItem = new ItemDAL();
            return dalItem.SelectPK(ItemID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            ItemDAL dalItem = new ItemDAL();
            return dalItem.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #endregion Select Operation
    }
}

using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InwardBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class InwardBAL
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
        public InwardBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(InwardENT entInward)
        {
            InwardDAL dalInward = new InwardDAL();
            if (dalInward.Insert(entInward))
            {
                return true;
            }
            else
            {
                Message = dalInward.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 InwardID)
        {
            InwardDAL dalInward = new InwardDAL();

            if (dalInward.Delete(InwardID))
            {
                return true;
            }
            else
            {
                Message = dalInward.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(InwardENT entInward)
        {
            InwardDAL dalInward = new InwardDAL();
            if (dalInward.Update(entInward))
            {
                return true;
            }
            else
            {
                Message = dalInward.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            InwardDAL dalInward = new InwardDAL();
            return dalInward.Select();
        }
        #endregion Select

        #region SelectPK
        public InwardENT SelectPK(SqlInt32 InwardID)
        {
            InwardDAL dalInward = new InwardDAL();
            return dalInward.SelectPK(InwardID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            InwardDAL dalInward = new InwardDAL();
            return dalInward.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #endregion Select Operation
    }
}

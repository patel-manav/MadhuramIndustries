using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MadhuramIndustriesBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class MadhuramIndustriesBAL
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
        public MadhuramIndustriesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(MadhuramIndustriesENT entMadhuramIndustries)
        {
            MadhuramIndustriesDAL dalMadhuramIndustries = new MadhuramIndustriesDAL();
            if (dalMadhuramIndustries.Insert(entMadhuramIndustries))
            {
                return true;
            }
            else
            {
                Message = dalMadhuramIndustries.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 MadhuramIndustriesID)
        {
            MadhuramIndustriesDAL dalMadhuramIndustries = new MadhuramIndustriesDAL();

            if (dalMadhuramIndustries.Delete(MadhuramIndustriesID))
            {
                return true;
            }
            else
            {
                Message = dalMadhuramIndustries.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(MadhuramIndustriesENT entMadhuramIndustries)
        {
            MadhuramIndustriesDAL dalMadhuramIndustries = new MadhuramIndustriesDAL();
            if (dalMadhuramIndustries.Update(entMadhuramIndustries))
            {
                return true;
            }
            else
            {
                Message = dalMadhuramIndustries.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            MadhuramIndustriesDAL dalMadhuramIndustries = new MadhuramIndustriesDAL();
            return dalMadhuramIndustries.Select();
        }
        #endregion Select

        #region SelectPK
        public MadhuramIndustriesENT SelectPK(SqlInt32 MadhuramIndustriesID)
        {
            MadhuramIndustriesDAL dalMadhuramIndustries = new MadhuramIndustriesDAL();
            return dalMadhuramIndustries.SelectPK(MadhuramIndustriesID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            MadhuramIndustriesDAL dalMadhuramIndustries = new MadhuramIndustriesDAL();
            return dalMadhuramIndustries.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #endregion Select Operation
    }
}

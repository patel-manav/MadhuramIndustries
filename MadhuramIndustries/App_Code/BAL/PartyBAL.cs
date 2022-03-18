using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PartyBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class PartyBAL
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
        public PartyBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(PartyENT entParty)
        {
            PartyDAL dalParty = new PartyDAL();
            if (dalParty.Insert(entParty))
            {
                return true;
            }
            else
            {
                Message = dalParty.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 PartyID)
        {
            PartyDAL dalParty = new PartyDAL();

            if (dalParty.Delete(PartyID))
            {
                return true;
            }
            else
            {
                Message = dalParty.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(PartyENT entParty)
        {
            PartyDAL dalParty = new PartyDAL();
            if (dalParty.Update(entParty))
            {
                return true;
            }
            else
            {
                Message = dalParty.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            PartyDAL dalParty = new PartyDAL();
            return dalParty.Select();
        }
        #endregion Select

        #region SelectPK
        public PartyENT SelectPK(SqlInt32 PartyID)
        {
            PartyDAL dalParty = new PartyDAL();
            return dalParty.SelectPK(PartyID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            PartyDAL dalParty = new PartyDAL();
            return dalParty.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #endregion Select Operation
    }
}

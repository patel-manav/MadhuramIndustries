using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeePenaltyBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class EmployeePenaltyBAL
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
        public EmployeePenaltyBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(EmployeePenaltyENT entEmployeePenalty)
        {
            EmployeePenaltyDAL dalEmployeePenalty = new EmployeePenaltyDAL();
            if (dalEmployeePenalty.Insert(entEmployeePenalty))
            {
                return true;
            }
            else
            {
                Message = dalEmployeePenalty.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 EmployeePenaltyID)
        {
            EmployeePenaltyDAL dalEmployeePenalty = new EmployeePenaltyDAL();

            if (dalEmployeePenalty.Delete(EmployeePenaltyID))
            {
                return true;
            }
            else
            {
                Message = dalEmployeePenalty.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(EmployeePenaltyENT entEmployeePenalty)
        {
            EmployeePenaltyDAL dalEmployeePenalty = new EmployeePenaltyDAL();
            if (dalEmployeePenalty.Update(entEmployeePenalty))
            {
                return true;
            }
            else
            {
                Message = dalEmployeePenalty.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            EmployeePenaltyDAL dalEmployeePenalty = new EmployeePenaltyDAL();
            return dalEmployeePenalty.Select();
        }
        #endregion Select

        #region SelectPK
        public EmployeePenaltyENT SelectPK(SqlInt32 EmployeePenaltyID)
        {
            EmployeePenaltyDAL dalEmployeePenalty = new EmployeePenaltyDAL();
            return dalEmployeePenalty.SelectPK(EmployeePenaltyID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            EmployeePenaltyDAL dalEmployeePenalty = new EmployeePenaltyDAL();
            return dalEmployeePenalty.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #endregion Select Operation
    }
}

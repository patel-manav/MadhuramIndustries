using MadhuramIndustries.App_Code.DAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExpenseBAL
/// </summary>
/// 
namespace MadhuramIndustries.App_Code.BAL
{
    public class ExpenseBAL
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
        public ExpenseBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ExpenseENT entExpense)
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            if (dalExpense.Insert(entExpense))
            {
                return true;
            }
            else
            {
                Message = dalExpense.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Delele Operation
        public Boolean Delete(SqlInt32 ExpenseID)
        {
            ExpenseDAL dalExpense = new ExpenseDAL();

            if (dalExpense.Delete(ExpenseID))
            {
                return true;
            }
            else
            {
                Message = dalExpense.Message;
                return false;
            }
        }

        #endregion Delele Operation

        #region Update Operation
        public Boolean Update(ExpenseENT entExpense)
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            if (dalExpense.Update(entExpense))
            {
                return true;
            }
            else
            {
                Message = dalExpense.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Select Operation

        #region Select
        public DataTable Select()
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            return dalExpense.Select();
        }
        #endregion Select

        #region SelectPK
        public ExpenseENT SelectPK(SqlInt32 ExpenseID)
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            return dalExpense.SelectPK(ExpenseID);
        }

        #endregion SelectPK

        #region Select For Dropdown
        public DataTable SelectForDropDown()
        {
            ExpenseDAL dalExpense = new ExpenseDAL();
            return dalExpense.SelectForDropDown();
        }
        #endregion Select For Dropdown

        #endregion Select Operation
    }
}

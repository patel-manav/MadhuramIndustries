using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;

namespace MadhuramIndustries.App_Code
{
    public class DatabaseConfig
    {

        #region Constructor
        public DatabaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region ConnectionString
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MadhuramIndustriesConnectionString"].ConnectionString.ToString();
        #endregion ConnectionString
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTest
{
    /// <summary>
    /// The Application Constant Class
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The Connection String
        /// </summary>
        public static string CONNECTIONSTRING = "Data Source=(LocalDb)\\v11.0;Initial Catalog=SignalRTest;Integrated Security=True";

        public static string DBTABLE_MESSAGE_SELECT_ALL = "SELECT [Id],[MessageTest],[UserId],[IsSend] FROM [SignalRTest].[dbo].[Messages]";
        
    }
}

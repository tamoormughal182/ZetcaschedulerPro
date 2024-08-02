using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler
{
    public class DBHelper
    {
        public static string Connectionstring()
        {
            var builder = SqlConfig.ConnectionString;

        
            return builder;
        }
    }
}

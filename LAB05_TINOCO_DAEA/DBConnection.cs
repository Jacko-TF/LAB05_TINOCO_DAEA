using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB05_TINOCO_DAEA
{
    public static class DBConnection
    {
        public static string getCadenaConexion()
        {
            string connectionString = "Data Source=LAB1504-16\\SQLEXPRESS;Initial Catalog=NeptunoDB;User Id=jacko;Password=admin123";
            return connectionString;
        }
    }
}

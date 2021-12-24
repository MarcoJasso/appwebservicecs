using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace appapi.Server
{
    public class Conexion
    {
        private SqlConnection connection = new SqlConnection("Server=DESKTOP-G2CMMEE\\SQLEXPRESS;DataBase=evaluaciondb;Integrated Security=true");

        protected SqlConnection OpenServer()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            return connection;
        }

        protected SqlConnection CloseServer()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();

            return connection;
        }
    }
}

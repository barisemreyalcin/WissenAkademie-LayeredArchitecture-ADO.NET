using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    // DB ile haberleşecek layer
    public class DataAccessLayer
    {
        // Bunlara BusinessLayer erişecek

        // DB'ye connection nesnesi tanımlamam gerek öncelikle
        // Bunları EF kendi yapar ama ADO ile benim yapmam gerek.
        public SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection
                ("Data Source=DESKTOP-6QTPFUC;Initial Catalog=NORTHWIND;User Id=sa;Password=mssqlserverbey;TrustServerCertificate=true");
            // Normalde daha dinamik olması için bu string bir configuration dosyamda olmalı

            if(conn.State == ConnectionState.Closed)
                conn.Open();

            return conn;
        }

        public void CloseConnection(SqlConnection conn) { 
            if(conn.State == ConnectionState.Open)
                conn.Close();
        }

        // SqlServer'da bir komut çalıştırabilmem için
        public SqlCommand ExecuteCommand(string command)
        {
            SqlConnection conn = OpenConnection();
            SqlCommand cmd = new SqlCommand(command, conn);
            //CloseConnection(conn); bunu uygulama seviyesinde yapacam.
            return cmd;
        }

        // Burada mantık; connection başlar, command çalışır, connection kapanır
    }
}
